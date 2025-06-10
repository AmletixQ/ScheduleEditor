using System;

namespace ScheduleEditor
{
    public enum TLesson
    {
        LECTURE,
        SEMINAR,
        LABORATORY
    }

    public enum TWeek
    {
        EVEN,
        ODD,
        BOTH,
    }

    public class Lesson
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Classroom { get; set; }
        public string LessonType { get; set; }
        public TWeek WeekType { get; set; } = TWeek.BOTH;

        public Lesson(
            string name,
            string teacher,
            string classroom,
            TLesson lessonType,
            TWeek week
        )
        {
            Name = name;
            Teacher = teacher;
            Classroom = classroom;
            WeekType = week;

            switch (lessonType)
            {
                case TLesson.LECTURE:
                    LessonType = "Лекция"; break;
                case TLesson.SEMINAR:
                    LessonType = "Практика"; break;
                case TLesson.LABORATORY:
                    LessonType = "Лабораторная"; break;
            }
        }

        public static Lesson LoadFromString(string lessonString)
        {
            string[] parts = lessonString.Split('|');
            if (parts.Length < 4) throw new ArgumentException("Invalid lesson string format.");

            string name = parts[0];
            string teacher = parts[1];
            string classroom = parts[2];
            TLesson lessonType = (TLesson)Enum.Parse(typeof(TLesson), parts[3], true);
            TWeek weekType = (TWeek)Enum.Parse(typeof(TWeek), parts[4], true);

            return new Lesson(name, teacher, classroom, lessonType, weekType);
        }

        public override string ToString()
        {
            return $"{LessonType} {Name} {Teacher} {WeekType}";
        }
    }
}
