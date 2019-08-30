using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Race.Domain.Race
{
    public class BestLapDetail
    {
        public BestLapDetail(string pilot, TimeSpan lapTime, int lapNumber)
        {
            Pilot = pilot;
            LapTime = lapTime;
            LapNumber = lapNumber;

        }
        public string Pilot { get; set; }
        public TimeSpan LapTime { get; set; }
        public int LapNumber { get; set; }
    }
}
