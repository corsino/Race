using Gyp.Corrida.Application.UseCases.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Corrida
{
    public interface IRaceFileService
    {
        RaceFileResult UploadRaceFile(RaceFileRequest request);
    }
}
