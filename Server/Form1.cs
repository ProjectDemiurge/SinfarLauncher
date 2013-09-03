using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace Server
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectBaseHak_Click(object sender, EventArgs e)
        {
            dialogFolderSelector.ShowDialog();
            txtbxNWNDIR.Text = dialogFolderSelector.SelectedPath;
            dialogFolderSelector.Reset();
        }


        private void btnGenerateManifest_Click(object sender, EventArgs e)
        {
            var dir = txtbxNWNDIR.Text;

            // Add NWNCX
            if (File.Exists(dir + "\\sinfarx.exe"))
            {
                Log(dir + "\\sinfarx.exe");
            }
            else
            {
                throw new FileNotFoundException("sinfarx.exe not found");
            }
            if (File.Exists(dir + "\\nwncx_sinfar.dll"))
            {
                Log(dir + "\\nwncx_sinfar.dll");
            }
            else
            {
                throw new Exception("nwncx_sinfar.dll not found");
            }
            
            // Add tlk
            if (File.Exists(dir + "\\tlk\\sinfar_10.tlk"))
            {
                Log(dir + "\\tlk\\sinfar_10.tlk");
            }
            else
            {
                throw new Exception("sinfar_10.tlk not found");
            }

            // Add Haks
            foreach (var hak in Directory.GetFiles(dir + "\\hak"))
            {
                Log(hak);
            }

            // Add overrides
            foreach (var hak in Directory.GetFiles(dir + "\\override"))
            {
                Log(hak);
            }
            
        }

        private void Log(string message)
        {
            lstbxLog.Items.Add(message);
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            for (int i = lstbxLog.SelectedItems.Count - 1; i >= 0; i--)
            {
                lstbxLog.Items.Remove(lstbxLog.SelectedItems[i]);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var manifest = new Dictionary<string, string>();

            lblLog.Text = @"Starting...";
            lblLog.Update();
    
            foreach (string item in lstbxLog.Items)
            {
                lblLog.Text = @"Processing: " + item;
                lblLog.Update();
                using (var stream = File.OpenRead(item))
                {
                    var sha = new SHA1Managed();
                    var hash = sha.ComputeHash(stream);
                    manifest.Add(BitConverter.ToString(hash), item.Remove(0, txtbxNWNDIR.Text.Length));
                }
            }

            lblLog.Text = @"Done";
            lblLog.Update();

            SaveManifest(manifest);
        }

        private void SaveManifest(Dictionary<string, string> manifest)
        {
            File.Delete(txtbxNWNDIR.Text + "\\sinfar.manifest");
            
            using (var writer = File.AppendText(txtbxNWNDIR.Text + "\\sinfar.manifest"))
            {
                foreach (var item in manifest)
                {
                    var fileInfo = new FileInfo(txtbxNWNDIR.Text + item.Value);

                    writer.WriteLine(item.Value + ";" + item.Key + ";" + fileInfo.Length + ";" + fileInfo.LastWriteTime);
                }
            }

            var version = 0;
            if (File.Exists(txtbxNWNDIR.Text + "\\sinfar.manifest.v") == true)
            {
                var manifestVersion = File.ReadAllText(txtbxNWNDIR.Text + "\\sinfar.manifest.v");
                version = Convert.ToInt32(manifestVersion);
            }
            File.WriteAllText(txtbxNWNDIR.Text + "\\sinfar.manifest.v", (version + 1).ToString(CultureInfo.InvariantCulture));
        }
    }
}
