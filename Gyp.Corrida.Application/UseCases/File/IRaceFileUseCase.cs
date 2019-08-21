using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Application.UseCases.File
{
    public interface IRaceFileUseCase
    {
        RaceFileResult ValidateInputFile(RaceFileRequest request);
        StreamReader GetRaceContentFileStream(IFormFile file);
    }
}
