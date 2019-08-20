using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Application.UseCases.File
{
    public interface IRaceFileUseCase
    {
        RaceFileResult UploadRaceFile(RaceFileRequest request);
    }
}
