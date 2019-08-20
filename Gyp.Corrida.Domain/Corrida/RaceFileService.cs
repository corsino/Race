using Gyp.Corrida.Application.UseCases.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Domain.Corrida
{
    public class RaceFileService:IRaceFileService
    {
        public RaceFileService() { }

        public RaceFileResult UploadRaceFile(RaceFileRequest request)
        {
            var resultado = new RaceFileResult();

            if (request == null)
                resultado.AddNotification("Arquivo", "Arquivo inválido");

            return resultado;
        }
    }
}
