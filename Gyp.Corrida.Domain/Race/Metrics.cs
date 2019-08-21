using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Race
{
    public class Metrics
    {
        public string Position { get; set; }
        public string PilotCode { get; set; }
        public string PilotName { get; set; }
        public string QuantityCompletedLap { get; set; }
        public string TotalTime { get; set; }
    }
}
