using Gyp.Race.Domain.Race;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Race.Application.UseCases.Race
{
    public interface IRaceUseCase
    {
        RaceResult<Metrics> ProcessRaceResult(RaceRequest request);
        StreamReader GetRaceContentFileStream(IFormFile file);
    }
}
