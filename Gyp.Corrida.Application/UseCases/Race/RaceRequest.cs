using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Application.UseCases.Race
{
    public class RaceRequest
    {
        public RaceRequest(IFormFile file)
        {
            this.File = file;
        }
        public IFormFile File { get; set; }
    }
}
