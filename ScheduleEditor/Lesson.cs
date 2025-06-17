using System;
using System.Collections.Generic;
using System.Linq;

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
        public int Order { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public string Classroom { get; set; }
        public TLesson LessonType { get; set; }
        public TWeek WeekType { get; set; } = TWeek.BOTH;

        public Lesson() { }

        public Lesson(
            int order,
            string name,
            string teacher,
            string classroom
        )
        {
            Order = order;
            Name = name;
            Teacher = teacher;
            Classroom = classroom;
        }

        public Lesson(
            int order,
            string name,
            string teacher,
            string classroom,
            int lessonTypeIndex,
            int weekTypeIndex
        ) : this(order, name, teacher, classroom)
        {
            LessonType = (TLesson)(lessonTypeIndex - 1);
            WeekType = (TWeek)(weekTypeIndex - 1);
        }

        public Lesson(
            int order,
            string name,
            string teacher,
            string classroom,
            TLesson lessonType,
            TWeek week
        ) : this(order, name, teacher, classroom)
        {
            WeekType = week;
            LessonType = lessonType;
        }
        
        public static Lesson LoadFromString(string lessonString)
        {
            string[] parts = lessonString.Split(',');
            if (parts.Length < 4) throw new ArgumentException("Invalid lesson string format.");

            List<string> tlessons = new List<string>() { "Лекция", "Семинар", "Лабораторная" };
            List<string> tweeks = new List<string>() { "Четная", "Нечетная", "Обе" };

            string name = parts[0];
            string teacher = parts[1];
            string classroom = parts[2];
            TLesson lessonType = (TLesson)tlessons.IndexOf(parts[3]);
            TWeek weekType = (TWeek)tweeks.IndexOf(parts[4]);

            return new Lesson(0, name, teacher, classroom, lessonType, weekType);
        }

        public override string ToString()
        {
            string lessonType, weekType;
            switch (LessonType)
            {
                case TLesson.LECTURE:
                    lessonType = "Лекция"; break;
                case TLesson.SEMINAR:
                    lessonType = "Семинар"; break;
                case TLesson.LABORATORY:
                    lessonType = "Лабораторная"; break;
                default:
                    throw new InvalidOperationException("Неизвестный тип занятия.");
            }

            switch (WeekType)
            {
                case TWeek.EVEN:
                    weekType = "Четная"; break;
                case TWeek.ODD:
                    weekType = "Нечетная"; break;
                case TWeek.BOTH:
                    weekType = "Обе"; break;
                default:
                    throw new InvalidOperationException("Неизвестный тип недели.");
            }

            return $"{Name},{Teacher},{Classroom},{lessonType},{weekType}";
        }
    }
}
