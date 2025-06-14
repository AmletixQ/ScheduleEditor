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

        public EditLessonForm() => InitializeComponent();
        public EditLessonForm(Lesson lesson) : this()
        {
            InputLessonName.Text = lesson.Name;
            InputTeacher.Text = lesson.Teacher;
            LessonTypeDropBox.SelectedItem = lesson.LessonType;
            WeekTypeDropBox.SelectedIndex = (int)lesson.WeekType;
            InputClassroom.Text = lesson.Classroom;
        }

        public string GetLessonString()
        {
            return $"{LessonName}|{Classroom}|{Teacher}|{LessonType}|{WeekType}";
        }

        public string GetViewLessonString()
        {
            
            return $"{LessonName} {Classroom} {Teacher} {LessonType} {WeekType}".Trim();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
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
