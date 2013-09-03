using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace SinfarLauncher
{
    public partial class Launcher : Form
    {
        public int Remoteversion;
        public int Localversion;
        public Manifest Manifest;
        private const string NwnRoot = "D:\\NWN";
        public static string Password;

        public Launcher()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            pbProgressBar.Minimum = 0;
            pbProgressBar.Maximum = 100;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Show();
            var credentials = new NetworkCredential("anonymous", "anonymous");

            Remoteversion = GetRemoteVersion(credentials);
            pbProgressBar.Value = 5;
            Localversion = GetLocalVersion(credentials);
            pbProgressBar.Value = 10;

            // If remote file set is newer than local file set - get full manifest
            if (Remoteversion > Localversion)
            {
                
                var updateNeeded = MessageBox.Show(@"Would you like to update?", @"Updates are available", MessageBoxButtons.YesNo);
                if (updateNeeded == DialogResult.Yes)
                {
                    Manifest = GetFullManifest(credentials);
                    pbProgressBar.Value = 15;
                    if (Manifest != null) Manifest.Compare(NwnRoot);
                    pbProgressBar.Value = 20;
                }
            }
            pbProgressBar.Value = 100;
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

            nwn.FileName = NwnRoot + "\\sinfarx.exe";

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
            StatusUpdate("Downloading manifest...");

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
            if (File.Exists(NwnRoot + "\\sinfar.manifest.v") == true)
            {
                var manifestVersion = File.ReadAllText(NwnRoot + "\\sinfar.manifest.v");
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
