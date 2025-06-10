using System;
using System.Windows.Forms;

namespace ScheduleEditor
{
    public partial class EditLessonForm : Form
    {
        public string LessonName { get; set; }
        public string Teacher { get; set; }
        public TLesson LessonType { get; set; }
        public TWeek WeekType { get; set; }
        public string Classroom { get; set; }

        public EditLessonForm()
        {
            InitializeComponent();
        }

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
            string lessonType = LessonType == TLesson.LECTURE ? "Лекция" :
                          LessonType == TLesson.SEMINAR ? "Семинар" :
                          "Лаборатория";

            if (string.IsNullOrEmpty(LessonName) && lessonType == "Лекция") return "";

            string weekType = WeekType == TWeek.EVEN ? "Четная" :
                          WeekType == TWeek.ODD ? "Нечетная" :
                          "Оба";
            return $"{LessonName} {Classroom} {Teacher} {lessonType} {weekType}";
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
