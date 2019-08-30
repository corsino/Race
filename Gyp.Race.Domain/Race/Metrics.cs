using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Race.Domain.Race
{
    public class Metrics
    {
        public List<PrincipalMetrics> PrincipalMetrics { get; set; }
        public AdicionalMetrics AdicionalMetrics { get; set; }
    }
}
