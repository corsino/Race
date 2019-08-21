using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using System.IO;

namespace Gyp.Corrida.Application.UseCases.File
{
    public class RaceFileUseCase: IRaceFileUseCase
    {
        public RaceFileResult ValidateInputFile(RaceFileRequest request)
        {
            var result = new RaceFileResult()
            {
                Success = true
            };

            if (request == null || request.File == null || request.File.Length <=0)
            { 
                result.AddNotification("Arquivo", "Arquivo inválido");
                result.Error = ErrorCode.Invalid;
                result.Success = false;
                return result;
            }
            if(!request.File.FileName.ToUpper().Contains(".TXT"))
            {
                result.AddNotification("Arquivo", "Extensão de arquivo não permitida");
                result.Error = ErrorCode.Invalid;
                result.Success = false;
                return result;
            }

            return result;
        }

        public StreamReader GetRaceContentFileStream(IFormFile file)
        {
            return new StreamReader(file.OpenReadStream());
        }
    }
}
