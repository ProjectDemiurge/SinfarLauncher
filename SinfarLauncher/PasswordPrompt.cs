using System;
using System.Windows.Forms;

namespace SinfarLauncher
{
    public partial class PasswordPrompt : Form
    {
        public PasswordPrompt()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                Launcher.Password = txtPassword.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show(@"Please enter a password");
            }
        }
    }
}
