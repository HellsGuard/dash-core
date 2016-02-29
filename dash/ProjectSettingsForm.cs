using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Dash.Properties;

namespace Dash
{
    public partial class ProjectSettingsForm : Form
    {
        public ProjectSettingsForm()
        {
            InitializeComponent();
        }

        private void ProjectSettingsForm_Load(object sender, EventArgs e)
        {
            // Set texts
            txtProjectsDir.Text = Settings.Default.Projects_Dir;
            txtProjectName.Text = Settings.Default.Project_Name;
            txtProjectWebsite.Text = Settings.Default.Project_Website;

            // Fill LB
            PopulateLB();
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            NewProjectForm NewProject = new NewProjectForm();
            NewProject.ShowDialog();
        }

        public void btnSetProjectFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowser.ShowDialog();

            if (result == DialogResult.OK)
            {
                Settings.Default.Projects_Dir = folderBrowser.SelectedPath;
                Settings.Default.Save();
                Settings.Default.Reload();

                txtProjectsDir.Text = folderBrowser.SelectedPath;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            Settings.Default.Reload();
            this.Close();
        }

        private void ProjectSettingsForm_Activated(object sender, EventArgs e)
        {
            PopulateLB();
        }

        public void PopulateLB()
        {
            if (Settings.Default.Projects_Dir != "")
            {
                // Populate listbox for existing Projects
                string path = Settings.Default.Projects_Dir;
                string[] dirs = Directory.GetDirectories(path);

                lbProjects.Items.Clear();

                foreach (string dir in dirs)
                {
                    string dirName = new DirectoryInfo(@dir).Name;
                    lbProjects.Items.Add(dirName);
                }
            }
            else
            {
                MessageBox.Show("Project folder has not been set, please do so now.");
                btnSetProjectFolder.PerformClick();
            }
        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.Project_Name = txtProjectName.Text;
        }

        private void txtProjectWebsite_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.Project_Website = txtProjectWebsite.Text;
        }
    }
}
