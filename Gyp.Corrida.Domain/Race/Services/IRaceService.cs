using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Race.Services
{
    public interface IRaceService
    {
        List<Metrics> GetdRaceMetrics(StreamReader raceStreamReader);
    }
}
