using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Application.UseCases.File
{
    public class RaceFileRequest
    {
        public RaceFileRequest(IFormFile file)
        {
            this.File = file;
        }
        public IFormFile File { get; set; }
    }
}
