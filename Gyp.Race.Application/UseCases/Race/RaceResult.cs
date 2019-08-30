using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Race.Application.UseCases.Race
{
    public class RaceResult<T>:Result
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
