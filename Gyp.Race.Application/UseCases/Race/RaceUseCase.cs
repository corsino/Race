using Gyp.Race.Domain.Race;
using Gyp.Race.Domain.Race.Services;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Gyp.Race.Application.UseCases.Race
{
    public class RaceUseCase : IRaceUseCase
    {
        public readonly IRaceService _raceService;
        public RaceUseCase(IRaceService raceService)
        {
            _raceService = raceService;
        }
        public RaceResult<Metrics> ProcessRaceResult(RaceRequest request)
        {
            var raceResult = new RaceResult<Metrics>()
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
