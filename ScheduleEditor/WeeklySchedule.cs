using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.IO;

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
        public Dictionary<TDay, List<Lesson>> Schedule = new Dictionary<TDay, List<Lesson>>();

        public void WriteToJson(string filename)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            };

            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filename, jsonString);
        }
    }
}
