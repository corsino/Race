using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gyp.Race.Domain.Race.Services
{
    public class RaceService : IRaceService
    {
        public RaceService() { }

        public Metrics GetRaceMetrics(StreamReader raceStreamReader)
        {
            var metrics = new Metrics();
            metrics.PrincipalMetrics = new List<PrincipalMetrics>();
            string line = raceStreamReader.ReadLine();
            List<Lap> lapObject = new List<Lap>();
            List<Lap> lapPilotList;
            int pilotNumber;
            BestLapDetail bestPilotLap;
            BestLapDetail bestRaceLap;
            List<decimal> averageSpeed;

            while ((line = raceStreamReader.ReadLine()) != null)
            {
                lapObject.Add(Lap.BuildLapObject(line));
            }

            bestRaceLap = Lap.GetBestLap(lapObject);
            foreach (var pilotNumberIterator in lapObject.GroupBy(u => u.PilotNumber))
            {
                pilotNumber = pilotNumberIterator.Key;
                lapPilotList = lapObject.Where(u => u.PilotNumber.Equals(pilotNumber)).ToList();
                bestPilotLap = Lap.GetBestLap(lapPilotList);
                averageSpeed = lapPilotList.Select(u => u.LapAVG).ToList();

                metrics.PrincipalMetrics.Add(
                    new PrincipalMetrics()
                    {
                        QuantityCompletedLap = Race.GetCompletedLaps(lapPilotList),
                        PilotTotalTime = Pilot.GetPilotTotalTime(Lap.GetTotalValidLaps(lapPilotList)
                    .Select(u => Lap.GetTimeSpanFromLapString(u.LapTime)).ToList()),
                        PilotNumber = Pilot.GetPilotNumber(lapPilotList),
                        PilotName = Pilot.GetPilotName(lapPilotList),
                        BestLap = $"Melhor volta do piloto: {bestPilotLap.LapNumber}, Tempo: {bestPilotLap.LapTime}",
                        AverageSpeed = Pilot.GetPilotAverageSpeed(averageSpeed)
                    });
            }

            metrics.AdicionalMetrics = new AdicionalMetrics()
            {
                BestRaceLap = $"Melhor volta da corrida: {bestRaceLap.LapNumber}, Tempo: {bestRaceLap.LapTime}, Piloto: {bestRaceLap.Pilot}"
            };

            Race.SetPosition(metrics.PrincipalMetrics);

            return metrics;
        }
    }
}
