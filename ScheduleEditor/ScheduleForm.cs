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
            WeeklySchedule weeklySchedule = new WeeklySchedule();

        public ScheduleForm()
        {
            InitializeComponent();
            ScheduleDataGrid.RowCount = 4;
            ScheduleDataGrid.Rows[0].Cells[0].Value = "9:00";
            ScheduleDataGrid.Rows[1].Cells[0].Value = "10:40";
            ScheduleDataGrid.Rows[2].Cells[0].Value = "12:50";
            ScheduleDataGrid.Rows[3].Cells[0].Value = "14:20";
        }

        public ScheduleForm(string facultyName) : this()

        {
            BreadCrumbs = new List<string>() { "database", "Факультеты", facultyName };
            UpdateNavigation();

            weeklySchedule.AddLesson(
                TDay.MONDAY, "Математический анализ", "301", "Кулаев", TLesson.LECTURE, TWeek.ODD
            );
        }

        private void UpdateNavigation()
        {

            BackButton.Enabled = BreadCrumbs.Count > 3;

            FlowNavigation.Controls.Clear();
            List<string> folders = GetFolders();

            foreach (string file in folders)
            {
                Control control;

                if (file.Contains(".json"))
                {
                    control = new LinkLabel()
                    {
                        Text = Path.GetFileNameWithoutExtension(file),
                        Font = new System.Drawing.Font("", 10),
                        AutoSize = true,
                        Margin = new Padding(0, 0, 0, 4),
                    };

                    control.Click += (object sender, EventArgs e) =>
                    {
                        if (BreadCrumbs.Contains(file)) return;

                        string current = e.ToString();
                        if (BreadCrumbs.Contains(current)) return;
                        if (BreadCrumbs[BreadCrumbs.Count - 1].Contains(".json")) return;
                        ScheduleDataGrid.Visible = true;

                        BreadCrumbs.Add(file);
                        weeklySchedule.WriteToJson("./database/test.json");

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

            ScheduleDataGrid.Visible = BreadCrumbs[BreadCrumbs.Count - 1].Contains(".json");
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

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string path = BuildPath();
            if (!path.Contains(".json")) return;

            //Lesson lesson = new Lesson(
            //    "Математический анализ",
            //    "Кулаев Руслан Черменович",
            //    "301",
            //    new TimeSpan(9, 0, 0),
            //    new TimeSpan(10, 30, 0),
            //    TLesson.LECTURE,
            //    TWeek.BOTH
            //);
        }
    }
}
