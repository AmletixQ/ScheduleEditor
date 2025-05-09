using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ScheduleEditor
{
    public partial class ScheduleForm : Form
    {
        private List<string> BreadCrumbs;

        public ScheduleForm()
        {
            InitializeComponent();
        }

        public ScheduleForm(string facultyName) : this()
        {
            BreadCrumbs = new List<string>() { "database", "Факультеты", facultyName };
            UpdateNavigation();
        }

        private void UpdateNavigation()
        {
            BackButton.Enabled = BreadCrumbs.Count > 3;

            FlowNavigation.Controls.Clear();
            List<string> folders = GetFolders();

            foreach (string file in folders)
            {
                Control control;

                if (file.Contains(".txt"))
                {
                    control = new LinkLabel()
                    {
                        Text = file,
                        BorderStyle = BorderStyle.FixedSingle,
                        Padding = new Padding(0, 0, 0, 10)
                    };
                }
                else
                {
                    control = new Button()
                    {
                        Text = file,
                        Width = FlowNavigation.Width - 5
                    };
                    control.Click += (object sender, EventArgs e) =>
                    {
                        BreadCrumbs.Add(file);
                        UpdateNavigation();
                    };
                }

                FlowNavigation.Controls.Add(control);
            }
        }

        private string BuildPath(int outDir = 0)
        {
            string path = string.Empty;
            int size = BreadCrumbs.Count - outDir;

            for (int i = 0; i < size; ++i)
                path += BreadCrumbs[i] + ((i < size - 1) ? "\\" : "");

            return path;
        }

        private List<string> GetFolders()
        {
            string path = BuildPath();

            List<string> folders = 
                Directory
                .GetDirectories(path)
                .Select(x => Path.GetFileName(x))
                .ToList();

            if (folders.Count == 0)
                folders = Directory
                .GetFiles(path)
                .Select(x => Path.GetFileName(x))
                .ToList();

            return folders;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            BreadCrumbs.RemoveAt(BreadCrumbs.Count - 1);
            UpdateNavigation();
        }
    }
}
