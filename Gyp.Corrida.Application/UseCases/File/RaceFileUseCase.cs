using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;

namespace Gyp.Corrida.Application.UseCases.File
{
    public class RaceFileUseCase: IRaceFileUseCase
    {

        public RaceFileResult UploadRaceFile(RaceFileRequest request)
        {
            var resultado = new RaceFileResult()
            {
                Success = true
            };

            if (request == null || request.File == null || request.File.Length <=0)
            { 
                resultado.AddNotification("Arquivo", "Arquivo inválido");
                resultado.Error = ErrorCode.Invalid;
                resultado.Success = false;


                return resultado;
            }

            return resultado;
        }
    }
}
