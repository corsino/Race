using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Race
{
    public static class Race
    {
        public static int GetCompletedLaps(List<Lap> lapPilotObject)
        {
            return lapPilotObject.Count;
        }

        public static List<Metrics> SetPosition(List<Metrics> metrics)
        {
            metrics = metrics.OrderBy(u => u.PilotTotalTime).ToList();
            for (int i = 0; i < metrics.Count; i++)
            {
                metrics[i].Position = i + 1;
            }

            return metrics;
        }
    }
}
