using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Race.Application.UseCases.Race
{
    public static class FileRace
    {
        public static bool IsValid(IFormFile file)
        {
            return file != null && file.Length > 0 && file.FileName.ToUpper().Contains(".TXT");
        }
    }
}
