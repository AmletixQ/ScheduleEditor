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

        Control _selected = null;
        bool _selecterIsFolder = false;

        public ScheduleForm()
        {
            InitializeComponent();
            UpdateScheduleGrid();
        }

        public ScheduleForm(string facultyName) : this()
        {
            BreadCrumbs = new List<string>() { "database", "Факультеты", facultyName };
            UpdateNavigation();
        }

        public void UpdateRemoveButton()
        {
            RemoveButton.Enabled = _selected != null;
        }

        private void UpdateNavigation()
        {
            BackButton.Enabled = BreadCrumbs.Count > 3;

            FlowNavigation.Controls.Clear();
            List<string> folders = GetFolders();

            EmptyFolderLabel.Visible = folders.Count == 0;

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
                        string current = e.ToString();
                        if (BreadCrumbs.Contains(current)) return;


                        if (BreadCrumbs[BreadCrumbs.Count - 1].Contains(".json"))
                        {
                            weeklySchedule.Schedule.Clear();
                            BreadCrumbs.RemoveAt(BreadCrumbs.Count - 1);
                        }

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
                        BackColor = SystemColors.ControlLight,
                        Margin = new Padding(0, 0, 0, 4)
                    };

                    control.DoubleClick += (object sender, EventArgs e) =>
                    {
                        BreadCrumbs.Add(file);
                        UpdateNavigation();
                    };
                }

                control.Click += (object sender, EventArgs e) =>
                {
                    _selecterIsFolder = !(sender is LinkLabel);

                    _selected = (Control)sender;
                    _selected.BackColor = Color.LightBlue;

                    foreach (Control c in FlowNavigation.Controls)
                        if (c != _selected)
                            c.BackColor = SystemColors.ControlLight;

                    UpdateRemoveButton();
                };



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
                    if (weeklySchedule.Schedule.ContainsKey((TDay)(j - 1)))
                        if (weeklySchedule.Schedule[(TDay)(j - 1)].Count > i)
                            ScheduleDataGrid.Rows[i].Cells[j].Value = weeklySchedule.Schedule[(TDay)(j - 1)]?[i].ToString() ?? "";
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
            int outDir = 0;
            if (BreadCrumbs.Last().Contains(".json"))
                outDir = 1;

            string path = BuildPath(outDir);
            CreateNewFolderOrFile form = new CreateNewFolderOrFile(path);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
                MessageBox.Show("Успешный успех при создании!");
            else if (form.DialogResult == DialogResult.Cancel)
                return;

            UpdateNavigation();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (_selected == null) return;

            string path = BuildPath();
            if (_selecterIsFolder)
            {
                string folderPath = Path.Combine(path, _selected.Text);

                if (MessageBox.Show("Вы действительно хотите удалить папку " + _selected.Text + "?", "Удаление папки", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Directory.Delete(folderPath, true);
                    MessageBox.Show("Папка успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string folderPath = Path.Combine(path, _selected.Text + ".json");

                if (MessageBox.Show("Вы действительно хотите удалить файл " + _selected.Text + "?", "Удаление файла", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    File.Delete(folderPath);
                    MessageBox.Show("Файл успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            UpdateNavigation();
            _selected = null;
            UpdateRemoveButton();
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
            }
            else
            {
                lesson = Lesson.LoadFromString(lessonData);
                if (lesson == null) return;

                EditLessonForm editLessonForm = new EditLessonForm(lesson);
                editLessonForm.ShowDialog();

                lesson = editLessonForm.GetLesson();
                ScheduleDataGrid.Rows[rowIndex].Cells[columnIndex].Value = lesson.ToString();
            }

            weeklySchedule.AddLesson((TDay)(columnIndex - 1), lesson);
            weeklySchedule.WriteToJson(BuildPath());
        }

    }
}
