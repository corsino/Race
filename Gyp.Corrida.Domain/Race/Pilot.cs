using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Race
{
    public static class Pilot
    {

        public static string GetPilotNumber(List<Lap> lapObject)
        {
            if (lapObject.GroupBy(u => u.PilotNumber).Count() > 1)
                throw new ArgumentOutOfRangeException(paramName: "PilotNumber", message: "Código do piloto inválido");

            return lapObject.FirstOrDefault().PilotNumber.ToString().PadLeft(3, '0');
        }

        public static string GetPilotName(List<Lap> lapObject)
        {
            return lapObject.FirstOrDefault().PilotName;
        }
        public static TimeSpan GetPilotTotalTime(List<TimeSpan> pilotLapTimeList)
        {
            TimeSpan pilotTotalTime = new TimeSpan(pilotLapTimeList.Sum(r => r.Ticks));

            return pilotTotalTime;
        }

        public static string GetPilotBestLap(List<Lap> lapPilotList)
        {
            Dictionary<int, TimeSpan> bestLap = new Dictionary<int, TimeSpan>();

            foreach (var lap in lapPilotList.Where(u=>u.LapNumber<=4))
            {
                bestLap.Add(lap.LapNumber, Lap.GetTimeSpanFromLapString(lap.LapTime));
            }

            var filterBestLap = bestLap.OrderBy(u => u.Value).First();

            return $"Melhor volta { filterBestLap.Key } - Tempo: { filterBestLap.Value}";
        }
    }
}
