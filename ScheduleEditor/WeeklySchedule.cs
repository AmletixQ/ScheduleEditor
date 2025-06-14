using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.IO;
using System.Windows.Forms;

namespace ScheduleEditor
{
    public enum TDay
    {
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
        SATURDAY,
        SUNDAY,
    }

    internal class WeeklySchedule
    {
        public Dictionary<TDay, List<Lesson>> Schedule = new Dictionary<TDay, List<Lesson>>()
        {
            { TDay.MONDAY, new List<Lesson>() },
            { TDay.TUESDAY, new List<Lesson>() },
            { TDay.WEDNESDAY, new List<Lesson>() },
            { TDay.THURSDAY, new List<Lesson>() },
            { TDay.FRIDAY, new List<Lesson>() },
            { TDay.SATURDAY, new List<Lesson>() },
        };

        public void AddLesson(TDay day, string name, string classroom, string teacher, TLesson type, TWeek week)
        {
            Schedule[day].Add(
                new Lesson(name, teacher, classroom, type, week)
            );
        }

        public void RemoveLesson(TDay day, Lesson lesson) => Schedule[day].Remove(lesson);

        public void WriteToJson(string filename)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };

            string jsonString = JsonSerializer.Serialize(Schedule, options);
            File.WriteAllText(filename, jsonString);
        }

        public void ReadFromJson(string filename)
        {
            string jsonString = File.ReadAllText(filename);
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };

            Schedule = JsonSerializer.Deserialize<Dictionary<TDay, List<Lesson>>>(jsonString, options)
                ?? new Dictionary<TDay, List<Lesson>>()
            {
                { TDay.MONDAY, new List<Lesson>() },
                { TDay.TUESDAY, new List<Lesson>() },
                { TDay.WEDNESDAY, new List<Lesson>() },
                { TDay.THURSDAY, new List<Lesson>() },
                { TDay.FRIDAY, new List<Lesson>() },
                { TDay.SATURDAY, new List<Lesson>() },
            };
        }
    }
}
