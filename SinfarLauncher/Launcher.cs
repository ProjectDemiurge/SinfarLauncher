using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.ComponentModel;

namespace SinfarLauncher
{
    public partial class Launcher : Form
    {
        public int Remoteversion;
        public int Localversion;
        public Manifest Manifest;
        private static string _nwnRoot;
        public static string Password;
        readonly NetworkCredential _credentials = new NetworkCredential("anonymous", "anonymous");

        public Launcher()
        {
            InitializeComponent();
        }



        private void Form1_Shown(object sender, EventArgs e)
        {
            _nwnRoot = Environment.CurrentDirectory;
            Show();

            // Compare versions
            StatusUpdate("Checking versions...");
            Remoteversion = GetRemoteVersion(_credentials);
            Localversion = GetLocalVersion(_credentials);

            // If remote file set is newer than local file set - get full manifest

            if (Remoteversion > Localversion)
            {
                var updateNeeded = MessageBox.Show(@"Would you like to update?", @"Updates are available", MessageBoxButtons.YesNo);

                if (updateNeeded == DialogResult.Yes)
                {
                    StatusUpdate("Downloading manifest...");
                    Manifest = GetFullManifest(_credentials);
                    StatusUpdate("Comparing files to manifest");
                    if (Manifest != null) Manifest.Compare(_nwnRoot);

                    if (Manifest != null)
                        foreach (var hak in Manifest.NeedsUpdate)
                        {
                            var url = "ftp://dev.projectdemiurge.net/" + hak.Path.Replace('\\', '/');
                            Download(hak, url, _credentials, GetFileSize(hak, url, _credentials));
                        }
                    UpdateVersion(Remoteversion);
                }
            }
            ActivateButtons();
        }

        private static void UpdateVersion(int remoteversion)
        {
            File.WriteAllText(_nwnRoot + "\\sinfar.manifest.v", remoteversion.ToString(CultureInfo.InvariantCulture));
        }

        private void ActivateButtons()
        {
            StatusUpdate("Ready to play!");
            btnLaunchArchTerre.Enabled = true;
            btnLaunchDread.Enabled = true;
            btnLaunchSSI.Enabled = true;
            btnLaunchSinfar.Enabled = true;
        }

        private static Int64 GetFileSize(UpdateFile hak, string url, NetworkCredential credentials)
        {
            var request = (FtpWebRequest) WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.Credentials = credentials;

            var response = (FtpWebResponse) request.GetResponse();

            var length = response.ContentLength;

            response.Close();

            return length;

        }

        private void Download(UpdateFile hak, string url, NetworkCredential credentials, Int64 filesize)
        {
            var request = (FtpWebRequest) WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = credentials;

            var response = (FtpWebResponse) request.GetResponse();
            var responsestream = response.GetResponseStream();
            if (responsestream != null)
            {
                var file = File.Create(_nwnRoot + hak.Path);
                var buffer = new byte[32*1024];
                int read;
                Int64 downloaded = 0;
                while ((read = responsestream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    file.Write(buffer, 0, read);
                    downloaded = downloaded + read;
                    StatusUpdate("Downloading " + hak.Path + " Received: " + downloaded + " of " + filesize);
                    Application.DoEvents();
                }
                file.Close();
                responsestream.Close();

            }
            response.Close();
        }


        private void btnLaunchSinfar_Click(object sender, EventArgs e)
        {
            Launch("5121");
        }

        private void btnLaunchSSI_Click(object sender, EventArgs e)
        {
            Launch("5123");
        }

        private void btnLaunchDread_Click(object sender, EventArgs e)
        {
            Launch("5122");
        }

        private void btnLaunchArchTerre_Click(object sender, EventArgs e)
        {
            Launch("5124");
        }

        private void Launch(string port)
        {
            var nwn = new ProcessStartInfo();

            if (chkDM.Checked == true)
            {
                nwn.Arguments = "-dmc +connect play.sinfar.net:" + port + " +password " + Password;
            }
            else
            {
                nwn.Arguments = "+connect play.sinfar.net:" + port;
            }

            nwn.FileName = _nwnRoot + "\\sinfarx.exe";

            using (Process proc = Process.Start(nwn))
            {
                proc.WaitForExit();

                var exitcode = proc.ExitCode;
            }
        }

        private void chkDM_Click(object sender, EventArgs e)
        {
            if (chkDM.Checked == true)
            {
                var prompt = new PasswordPrompt();
                prompt.ShowDialog();
            }
            else
            {
                chkDM.Checked = false;
            }
        }

        private Manifest GetFullManifest(NetworkCredential credentials)
        {
            Manifest manifest = null;
            var request = (FtpWebRequest)WebRequest.Create("ftp://dev.projectdemiurge.net/sinfar.manifest");
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = credentials;

            var response = (FtpWebResponse)request.GetResponse();
            var responsestream = response.GetResponseStream();
            if (responsestream != null)
            {
                var reader = new StreamReader(responsestream);
                string result = reader.ReadToEnd();
                manifest = new Manifest(result);
                reader.Close();
            }

            response.Close();
            return manifest;
        }

        private  int GetLocalVersion(NetworkCredential credentials)
        {
            StatusUpdate("Checking local version...");

            var localversion = 0;
            if (File.Exists(_nwnRoot + "\\sinfar.manifest.v") == true)
            {
                var manifestVersion = File.ReadAllText(_nwnRoot + "\\sinfar.manifest.v");
                localversion = Convert.ToInt32(manifestVersion);
            }
            return localversion;
        }

        private int GetRemoteVersion(NetworkCredential credentials)
        {
            StatusUpdate("Checking latest version...");

            var remoteversion = 0;
            var requestVersion = (FtpWebRequest)WebRequest.Create("ftp://dev.projectdemiurge.net/sinfar.manifest.v");
            requestVersion.Method = WebRequestMethods.Ftp.DownloadFile;
            requestVersion.Credentials = credentials;

            var responseVersion = (FtpWebResponse)requestVersion.GetResponse();
            var responseVersionStream = responseVersion.GetResponseStream();
            if (responseVersionStream != null)
            {
                var reader = new StreamReader(responseVersionStream);
                string result = reader.ReadToEnd();
                remoteversion = Convert.ToInt32(result);
                reader.Close();
            }
            if (responseVersionStream != null) responseVersionStream.Close();
            return remoteversion;
        }

        private void StatusUpdate(string message)
        {
            lblStatus.Text = message;
            lblStatus.Update();
        }
    }
}
