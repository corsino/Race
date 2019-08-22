using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Race.Services
{
    public class Pilot
    {
        public Pilot(string number, string name)
        {
            this.Number = number;
            this.Name = name;
        }
        public string Number { get; set; }
        public string Name { get; set; }

    }
}
