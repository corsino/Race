using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Corrida
{
    public class RaceService:IRaceService
    {
        public RaceService()
        {

        }

        public int CalculaVolta()
        {
            return 4;
        }
    }
}
