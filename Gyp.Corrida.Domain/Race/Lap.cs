using Gyp.Corrida.Domain.Race.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gyp.Corrida.Domain.Race
{
    public class Lap
    {
        public DateTime Hour { get; set; }
        public int PilotNumber { get; set; }
        public string PilotName { get; set; }
        public int LapNumber { get; set; }
        public string LapTime { get; set; }
        public decimal LapAVG { get; set; }

        public static Lap BuildLapObject(string lineOfFile)
        {
            var lap = new Lap();
            var lapPropertyNames = typeof(Lap).GetProperties().Select(p => p.Name).ToList();

            var splitedRaceData = new List<string>(lineOfFile.Split(new string[] { " ", "\t" }, StringSplitOptions.None));
            splitedRaceData.RemoveAll(x => x == "" || x == "–");

            for (int i = 0; i < splitedRaceData.Count; i++)
            {
                PropertyInfo propertyInfo = lap.GetType().GetProperty(lapPropertyNames[i]);
                propertyInfo.SetValue(lap, Convert.ChangeType(splitedRaceData[i], propertyInfo.PropertyType), null);
            }

            return lap;
        }

        public static TimeSpan GetTimeSpanFromLapString(string dateTime)
        {
            string pattern = "m:ss.fff";
            return DateTime.ParseExact(dateTime, pattern, null).TimeOfDay;
        }

        public static IEnumerable<Lap> GetTotalValidLaps(List<Lap> laps)
        {
            return laps.Where(u => u.LapNumber <= 4);
        }
    }
}
