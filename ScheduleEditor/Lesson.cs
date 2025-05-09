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
        BOTH,
        EVEN,
        ODD,
    }

    internal class Lesson
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Classroom { get; set; }
        public string LessonType { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TWeek WeekType { get; set; } = TWeek.BOTH;

        public Lesson(
            string name,
            string teacher,
            string classroom,
            TimeSpan startTime,
            TimeSpan endTime,
            TLesson lessonType,
            TWeek week
        )
        {
            Name = name;
            Teacher = teacher;
            Classroom = classroom;
            StartTime = startTime;
            EndTime = endTime;
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
    }
}
