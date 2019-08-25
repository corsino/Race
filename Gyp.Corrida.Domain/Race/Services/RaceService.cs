using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gyp.Corrida.Domain.Race.Services
{
    public class RaceService : IRaceService
    {
        public RaceService() { }

        public List<Metrics> GetRaceMetrics(StreamReader raceStreamReader)
        {
            var metrics = new List<Metrics>();

            string line = raceStreamReader.ReadLine();
            List<Lap> lapObject = new List<Lap>();
            List<Lap> lapPilotList;
            int pilotNumber;
            while ((line = raceStreamReader.ReadLine()) != null)
            {
                lapObject.Add(Lap.BuildLapObject(line));
            }

            foreach (var pilotNumberIterator in lapObject.GroupBy(u=>u.PilotNumber))
            {
                pilotNumber = pilotNumberIterator.Key;
                lapPilotList = lapObject.Where(u => u.PilotNumber.Equals(pilotNumber)).ToList();

                metrics.Add(new Metrics()
                {
                    QuantityCompletedLap = GetCompletedLaps(lapPilotList),
                    PilotTotalTime = Pilot.GetPilotTotalTime(Lap.GetTotalValidLaps(lapPilotList)
                    .Select(u => Lap.GetTimeSpanFromLapString(u.LapTime)).ToList()),
                    PilotNumber = Pilot.GetPilotNumber(lapPilotList),
                    PilotName = Pilot.GetPilotName(lapPilotList),
                    BestLap = Pilot.GetPilotBestLap(lapPilotList)
                });
            }

            return SetPosition(metrics);
        }

        public int GetCompletedLaps(List<Lap> lapPilotObject)
        {
            return lapPilotObject.Count;
        }

        public List<Metrics> SetPosition(List<Metrics> metrics)
        {
            metrics = metrics.OrderBy(u => u.PilotTotalTime).ToList();
            for (int i = 0; i < metrics.Count; i++)
            {
                metrics[i].Position = i+1;
            }

            return metrics;
        }
    }
}
