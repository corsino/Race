using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Race.Services
{
    public class RaceService:IRaceService
    {
        public RaceService() { }

        public List<Metrics> GetdRaceMetrics(StreamReader raceStreamReader)
        {
            var metrics = new List<Metrics>();
            return metrics;
        }
    }
}
