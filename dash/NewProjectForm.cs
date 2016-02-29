using System;
using System.IO;
using System.Windows.Forms;
using Dash.Properties;

namespace Dash
{
    public partial class NewProjectForm : Form
    {
        public NewProjectForm()
        {
            InitializeComponent();
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            string path = Settings.Default.Projects_Dir;

            Directory.CreateDirectory(@path + "\\" + txtProjectName.Text);
            this.Close();
        }
    }
}
