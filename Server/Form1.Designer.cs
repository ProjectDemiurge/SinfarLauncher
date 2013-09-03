namespace Server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbxNWNDIR = new System.Windows.Forms.TextBox();
            this.dialogFolderSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectNWNDir = new System.Windows.Forms.Button();
            this.btnFindfiles = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstbxLog = new System.Windows.Forms.ListBox();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblLog = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbxNWNDIR
            // 
            this.txtbxNWNDIR.Location = new System.Drawing.Point(12, 15);
            this.txtbxNWNDIR.Name = "txtbxNWNDIR";
            this.txtbxNWNDIR.Size = new System.Drawing.Size(388, 20);
            this.txtbxNWNDIR.TabIndex = 1;
            // 
            // btnSelectNWNDir
            // 
            this.btnSelectNWNDir.Location = new System.Drawing.Point(406, 15);
            this.btnSelectNWNDir.Name = "btnSelectNWNDir";
            this.btnSelectNWNDir.Size = new System.Drawing.Size(106, 23);
            this.btnSelectNWNDir.TabIndex = 2;
            this.btnSelectNWNDir.Text = "Select NWN Dir";
            this.btnSelectNWNDir.UseVisualStyleBackColor = true;
            this.btnSelectNWNDir.Click += new System.EventHandler(this.btnSelectBaseHak_Click);
            // 
            // btnFindfiles
            // 
            this.btnFindfiles.Location = new System.Drawing.Point(418, 151);
            this.btnFindfiles.Name = "btnFindfiles";
            this.btnFindfiles.Size = new System.Drawing.Size(106, 23);
            this.btnFindfiles.TabIndex = 8;
            this.btnFindfiles.Text = "Find Files";
            this.btnFindfiles.UseVisualStyleBackColor = true;
            this.btnFindfiles.Click += new System.EventHandler(this.btnGenerateManifest_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtbxNWNDIR);
            this.panel1.Controls.Add(this.btnSelectNWNDir);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 52);
            this.panel1.TabIndex = 9;
            // 
            // lstbxLog
            // 
            this.lstbxLog.BackColor = System.Drawing.SystemColors.Info;
            this.lstbxLog.FormattingEnabled = true;
            this.lstbxLog.Location = new System.Drawing.Point(24, 79);
            this.lstbxLog.Name = "lstbxLog";
            this.lstbxLog.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstbxLog.Size = new System.Drawing.Size(388, 95);
            this.lstbxLog.TabIndex = 8;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(418, 79);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(106, 23);
            this.btnRemoveItem.TabIndex = 3;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(418, 180);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(106, 23);
            this.btnGenerate.TabIndex = 10;
            this.btnGenerate.Text = "Generate Manifest";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblLog.Location = new System.Drawing.Point(21, 185);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(24, 13);
            this.lblLog.TabIndex = 11;
            this.lblLog.Text = "test";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 209);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.lstbxLog);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFindfiles);
            this.Name = "Form1";
            this.Text = "Manifest Generator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxNWNDIR;
        private System.Windows.Forms.FolderBrowserDialog dialogFolderSelector;
        private System.Windows.Forms.Button btnSelectNWNDir;
        private System.Windows.Forms.Button btnFindfiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstbxLog;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblLog;
    }
}

