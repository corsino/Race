using System.Collections.Generic;
using System.IO;

namespace Gyp.Corrida.Domain.Race.Services
{
    public class RaceService : IRaceService
    {
        public RaceService() { }

        public List<Metrics> GetRaceMetrics(StreamReader raceStreamReader)
        {
            var metrics = new List<Metrics>();

            var line = raceStreamReader.ReadLine();
            while ((line = raceStreamReader.ReadLine()) != null)
            {
                var lapObject = Lap.BuildLapObject(line);

                //metrics.Add(new Metrics() { PilotName = raceStreamReader.ReadLine() });
                //Posição Chegada
                //Codigo Piloto
                //Nome Piloto
                //Qtd Voltas Completadas
                //Tempo total de prova
            }

            return metrics;
        }
    }
}
