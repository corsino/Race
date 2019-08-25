using Gyp.Corrida.Domain.Race;
using Gyp.Corrida.Domain.Race.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Gyp.Corrida.Application.UseCases.Race
{
    public class RaceUseCase : IRaceUseCase
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

            if (!FileRace.IsValid(request.File))
            {
                raceResult.AddNotification("Arquivo", "Arquivo inválido");
                raceResult.Error = ErrorCode.Invalid;
                raceResult.Success = false;
                return raceResult;
            }

            try
            {
                raceResult.Data = _raceService.GetRaceMetrics(GetRaceContentFileStream(request.File));
            }
            catch
            {
                raceResult.AddNotification("Arquivo", "Conteúdo do arquivo inválido ou mal formatado");
                raceResult.Error = ErrorCode.Invalid;
                raceResult.Success = false;
                return raceResult;
            }

            return raceResult;
        }

        public StreamReader GetRaceContentFileStream(IFormFile file)
        {
            return new StreamReader(file.OpenReadStream());
        }

    }
}
