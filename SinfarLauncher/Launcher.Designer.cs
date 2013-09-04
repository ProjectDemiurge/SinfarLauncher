namespace SinfarLauncher
{
    partial class Launcher
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
            this.components = new System.ComponentModel.Container();
            this.webControl1 = new Awesomium.Windows.Forms.WebControl(this.components);
            this.pbProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnLaunchSinfar = new System.Windows.Forms.Button();
            this.btnLaunchSSI = new System.Windows.Forms.Button();
            this.btnLaunchDread = new System.Windows.Forms.Button();
            this.chkDM = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLaunchArchTerre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webControl1
            // 
            this.webControl1.Location = new System.Drawing.Point(0, 0);
            this.webControl1.Size = new System.Drawing.Size(820, 450);
            this.webControl1.Source = new System.Uri("http://sinfar.net/blog/oocnews", System.UriKind.Absolute);
            this.webControl1.TabIndex = 0;
            // 
            // pbProgressBar
            // 
            this.pbProgressBar.Location = new System.Drawing.Point(12, 456);
            this.pbProgressBar.MarqueeAnimationSpeed = 50;
            this.pbProgressBar.Name = "pbProgressBar";
            this.pbProgressBar.Size = new System.Drawing.Size(474, 23);
            this.pbProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgressBar.TabIndex = 1;
            // 
            // btnLaunchSinfar
            // 
            this.btnLaunchSinfar.Enabled = false;
            this.btnLaunchSinfar.Location = new System.Drawing.Point(493, 456);
            this.btnLaunchSinfar.Name = "btnLaunchSinfar";
            this.btnLaunchSinfar.Size = new System.Drawing.Size(75, 34);
            this.btnLaunchSinfar.TabIndex = 2;
            this.btnLaunchSinfar.Text = "Sinfar Isles";
            this.btnLaunchSinfar.UseVisualStyleBackColor = true;
            this.btnLaunchSinfar.Click += new System.EventHandler(this.btnLaunchSinfar_Click);
            // 
            // btnLaunchSSI
            // 
            this.btnLaunchSSI.Enabled = false;
            this.btnLaunchSSI.Location = new System.Drawing.Point(574, 456);
            this.btnLaunchSSI.Name = "btnLaunchSSI";
            this.btnLaunchSSI.Size = new System.Drawing.Size(75, 34);
            this.btnLaunchSSI.TabIndex = 3;
            this.btnLaunchSSI.Text = "Serpent Sea Isles";
            this.btnLaunchSSI.UseVisualStyleBackColor = true;
            this.btnLaunchSSI.Click += new System.EventHandler(this.btnLaunchSSI_Click);
            // 
            // btnLaunchDread
            // 
            this.btnLaunchDread.Enabled = false;
            this.btnLaunchDread.Location = new System.Drawing.Point(655, 456);
            this.btnLaunchDread.Name = "btnLaunchDread";
            this.btnLaunchDread.Size = new System.Drawing.Size(75, 34);
            this.btnLaunchDread.TabIndex = 4;
            this.btnLaunchDread.Text = "Dreaded Lands";
            this.btnLaunchDread.UseVisualStyleBackColor = true;
            this.btnLaunchDread.Click += new System.EventHandler(this.btnLaunchDread_Click);
            // 
            // chkDM
            // 
            this.chkDM.AutoSize = true;
            this.chkDM.Location = new System.Drawing.Point(414, 481);
            this.chkDM.Name = "chkDM";
            this.chkDM.Size = new System.Drawing.Size(72, 17);
            this.chkDM.TabIndex = 5;
            this.chkDM.Text = "DM Client";
            this.chkDM.UseVisualStyleBackColor = true;
            this.chkDM.Click += new System.EventHandler(this.chkDM_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 482);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 6;
            // 
            // btnLaunchArchTerre
            // 
            this.btnLaunchArchTerre.Enabled = false;
            this.btnLaunchArchTerre.Location = new System.Drawing.Point(736, 456);
            this.btnLaunchArchTerre.Name = "btnLaunchArchTerre";
            this.btnLaunchArchTerre.Size = new System.Drawing.Size(75, 34);
            this.btnLaunchArchTerre.TabIndex = 7;
            this.btnLaunchArchTerre.Text = "Arche Terre (French)";
            this.btnLaunchArchTerre.UseVisualStyleBackColor = true;
            this.btnLaunchArchTerre.Click += new System.EventHandler(this.btnLaunchArchTerre_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 502);
            this.Controls.Add(this.btnLaunchArchTerre);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkDM);
            this.Controls.Add(this.btnLaunchDread);
            this.Controls.Add(this.btnLaunchSSI);
            this.Controls.Add(this.btnLaunchSinfar);
            this.Controls.Add(this.pbProgressBar);
            this.Controls.Add(this.webControl1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(835, 540);
            this.MinimumSize = new System.Drawing.Size(835, 540);
            this.Name = "Launcher";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sinfar Launcher";
            this.Load += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Awesomium.Windows.Forms.WebControl webControl1;
        private System.Windows.Forms.ProgressBar pbProgressBar;
        private System.Windows.Forms.Button btnLaunchSinfar;
        private System.Windows.Forms.Button btnLaunchSSI;
        private System.Windows.Forms.Button btnLaunchDread;
        private System.Windows.Forms.CheckBox chkDM;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLaunchArchTerre;
    }
}

