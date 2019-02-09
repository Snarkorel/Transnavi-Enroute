using System;
using System.Windows.Forms;

namespace Snarkorel.transnavi.enroute
{
    public partial class CredentialsForm : Form
    {
        public string Login;
        public string Password;

        public CredentialsForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Login = loginTextBox.Text;
            Password = passwordTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
