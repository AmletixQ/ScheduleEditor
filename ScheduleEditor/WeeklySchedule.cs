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
        public Dictionary<TDay, Lesson[]> Schedule;

        public WeeklySchedule() => Clear();

        public void Clear()
        {
            Schedule = new Dictionary<TDay, Lesson[]>()
            {
                { TDay.MONDAY, new Lesson[4] },
                { TDay.TUESDAY, new Lesson[4] },
                { TDay.WEDNESDAY, new Lesson[4] },
                { TDay.THURSDAY, new Lesson[4] },
                { TDay.FRIDAY, new Lesson[4] },
                { TDay.SATURDAY, new Lesson[4] },
            };
        }


        public void AddLesson(TDay day, Lesson lesson)
        {
            Schedule[day][lesson.Order] = lesson;
        }

        public void AddLesson(TDay day, int order, string name, string classroom, string teacher, TLesson type, TWeek week)
        {
            Schedule[day][order] = new Lesson(order, name, teacher, classroom, type, week);
        }

        public void RemoveLesson(TDay day, Lesson lesson) => Schedule[day][lesson.Order] = null;

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
            if (!File.Exists(filename)) return;

            string jsonString = File.ReadAllText(filename, Encoding.UTF8);
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = false,
                //Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };

            var stringSchedule = JsonSerializer.Deserialize<Dictionary<string, Lesson[]>>(jsonString);

            foreach (var kvp in stringSchedule)
                if (Enum.TryParse<TDay>(kvp.Key, ignoreCase: true, out var day))
                    Schedule[day] = kvp.Value;
        }
    }
}
