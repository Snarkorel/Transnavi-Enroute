using System;
using System.Windows.Forms;

namespace Snarkorel.transnavi.enroute
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            //TODO: request routes tree
        }

        private void transportTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: switch transport type
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            //TODO: search route
        }

        private void routesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //TODO: search fleet for route
        }

        private void vehiclesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //TODO: show info
        }
    }
}
