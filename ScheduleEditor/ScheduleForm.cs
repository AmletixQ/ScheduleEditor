using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            ScheduleDataGrid.Rows[0].Cells[0].Value = "9:00-10:30";
            ScheduleDataGrid.Rows[1].Cells[0].Value = "10:40-12:10";
            ScheduleDataGrid.Rows[2].Cells[0].Value = "12:50-14:20";
            ScheduleDataGrid.Rows[3].Cells[0].Value = "14:30-16:00";
        }

        public ScheduleForm(string facultyName) : this()

        {
            BreadCrumbs = new List<string>() { "database", "Факультеты", facultyName };
            UpdateNavigation();

            //weeklySchedule.AddLesson(
            //    TDay.MONDAY, "Математический анализ", "301", "Кулаев", TLesson.LECTURE, TWeek.ODD
            //);
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

                    control.DoubleClick += (object sender, EventArgs e) =>
                    {
                        if (BreadCrumbs.Contains(file)) return;

                        string current = e.ToString();
                        if (BreadCrumbs.Contains(current)) return;


                        if (BreadCrumbs[BreadCrumbs.Count - 1].Contains(".json"))
                            BreadCrumbs[BreadCrumbs.Count - 1] = file;
                            
                        BreadCrumbs.Add(file);
                        ScheduleDataGrid.Visible = true;

                        weeklySchedule.ReadFromJson(BuildPath());
                        UpdateScheduleGrid();
                    };
                }
                else
                {
                    control = new Label
                    {
                        Text = file,
                        BorderStyle = BorderStyle.FixedSingle,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = SystemColors.ControlLight
                    };

                    control.DoubleClick += (object sender, EventArgs e) =>
                    {
                        BreadCrumbs.Add(file);
                        UpdateNavigation();
                    };
                }

                FlowNavigation.Controls.Add(control);
            }

            ScheduleDataGrid.Visible = BreadCrumbs[BreadCrumbs.Count - 1].Contains(".json");
        }

        private void UpdateScheduleGrid()
        {
            ScheduleDataGrid.Rows.Clear();
            ScheduleDataGrid.RowCount = 4;
            ScheduleDataGrid.Rows[0].Cells[0].Value = "9:00-10:30";
            ScheduleDataGrid.Rows[1].Cells[0].Value = "10:40-12:10";
            ScheduleDataGrid.Rows[2].Cells[0].Value = "12:50-14:20";
            ScheduleDataGrid.Rows[3].Cells[0].Value = "14:30-16:00";

            for (int i = 0; i < 4; ++i)
                for (int j = 1; j <= 6; ++j)
                    if (weeklySchedule.Schedule[(TDay)(j - 1)].Count > i)
                    {
                        MessageBox.Show(weeklySchedule.Schedule[(TDay)(j - 1)]?[i].ToString());
                        ScheduleDataGrid.Rows[i].Cells[j].Value = weeklySchedule.Schedule[(TDay)(j - 1)]?[i].ToString() ?? "";
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

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string path = BuildPath();
            if (!path.Contains(".json")) return;
        }

        private void ScheduleDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (rowIndex < 0 || columnIndex < 1) return;

            string lessonData = ScheduleDataGrid.Rows[rowIndex].Cells[columnIndex].Value?.ToString() ?? "";

            Lesson lesson;

            if (string.IsNullOrEmpty(lessonData))
            {
                EditLessonForm editLessonForm = new EditLessonForm();
                editLessonForm.ShowDialog();

                lesson = editLessonForm.GetLesson();

                ScheduleDataGrid.Rows[rowIndex].Cells[columnIndex].Value = lesson.ToString();
            } else
            {
                lesson = Lesson.LoadFromString(lessonData);
                if (lesson == null) return;

                EditLessonForm editLessonForm = new EditLessonForm(lesson);
                editLessonForm.ShowDialog();

                lesson = editLessonForm.GetLesson();
                ScheduleDataGrid.Rows[rowIndex].Cells[columnIndex].Value = lesson.ToString();
            }

            weeklySchedule.AddLesson((TDay)(columnIndex - 1), lesson);
            //MessageBox.Show(BuildPath());
            weeklySchedule.WriteToJson(BuildPath());
        }
    }
}
