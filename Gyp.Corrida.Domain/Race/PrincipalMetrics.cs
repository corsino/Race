using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Race
{
    public class PrincipalMetrics
    {

        public int Position { get; set; }
        public string PilotNumber { get; set; }
        public string PilotName { get; set; }
        public int QuantityCompletedLap { get; set; }
        public TimeSpan PilotTotalTime { get; set; }
        public string BestLap { get; set; }
        public decimal AverageSpeed { get; set; }
    }
}
