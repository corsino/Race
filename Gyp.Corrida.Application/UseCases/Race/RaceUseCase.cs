using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using System.IO;
using Gyp.Corrida.Domain.Race.Services;
using Gyp.Corrida.Domain.Race;

namespace Gyp.Corrida.Application.UseCases.Race
{
    public class RaceUseCase: IRaceUseCase
    {
        public readonly IRaceService _raceService;
        public RaceUseCase(IRaceService raceService)
        {
            _raceService = raceService;
        }
        public RaceResult<List<Metrics>> ProcessRaceResult(RaceRequest request)
        {
            var raceResult = new RaceResult<List<Metrics>>()
            {
                Success = true
            };

            if(FileRace.IsValid(request.File))
            {
                raceResult.AddNotification("Arquivo", "Arquivo inválido");
                raceResult.Error = ErrorCode.Invalid;
                raceResult.Success = false;
                return raceResult;
            }

            var raceMetrics = _raceService.GetdRaceMetrics(GetRaceContentFileStream(request.File));
            raceResult.Data = raceMetrics;
            return raceResult;
        }

        public StreamReader GetRaceContentFileStream(IFormFile file)
        {
            return new StreamReader(file.OpenReadStream());
        }

    }
}
