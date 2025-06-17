using System;
using System.Windows.Forms;

namespace ScheduleEditor
{
    public partial class EditLessonForm : Form
    {
        public string LessonName { get; set; } = null;
        public string Teacher { get; set; } = null;
        public TLesson? LessonType { get; set; } = null;
        public TWeek? WeekType { get; set; } = null;
        public string Classroom { get; set; } = null;

        int order;

        public EditLessonForm() => InitializeComponent();

        public EditLessonForm(int order) : this() => this.order = order;

        public EditLessonForm(int order, Lesson lesson) : this()
        {
            this.order = order;

            InputLessonName.Text = lesson.Name;
            InputTeacher.Text = lesson.Teacher;
            LessonTypeDropBox.SelectedIndex = (int)lesson.LessonType;
            WeekTypeDropBox.SelectedIndex = (int)lesson.WeekType;
            InputClassroom.Text = lesson.Classroom;
        }

        public Lesson GetLesson()
        {
            return new Lesson(
                order,
                InputLessonName.Text,
                InputTeacher.Text,
                InputClassroom.Text,
                (TLesson)LessonTypeDropBox.SelectedIndex,
                (TWeek)WeekTypeDropBox.SelectedIndex
            );
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (InputLessonName.Text == null || label.Text == null || LessonTypeDropBox.SelectedIndex == -1 || WeekTypeDropBox.SelectedIndex == -1 || InputClassroom.Text == null)
            {
                this.Close();
                return;
            }

            LessonName = InputLessonName.Text;
            Teacher = label.Text;
            LessonType = (TLesson)LessonTypeDropBox.SelectedIndex;
            WeekType = (TWeek)WeekTypeDropBox.SelectedIndex;
            Classroom = InputClassroom.Text;

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
