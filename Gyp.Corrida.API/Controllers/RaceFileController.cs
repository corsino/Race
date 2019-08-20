using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Gyp.Corrida.Application.UseCases.File;
using Gyp.Corrida.Domain.Corrida;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gyp.Corrida.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceFileController : ControllerBase
    {
        
        private readonly IRaceFileUseCase _raceFileUseCase;
        public RaceFileController(IRaceFileUseCase raceFileUseCase)
        {
            _raceFileUseCase = raceFileUseCase;
        }
        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    int volta =_raceService.CalculaVolta();
        //    return new string[] { volta.ToString(), "value2" };
        //}

        // POST api/values
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(IEnumerable<Notification>), 422)]
        public IActionResult Post([FromForm]IFormFile file)
        {
            var request = new RaceFileRequest(file);

            var resultado = _raceFileUseCase.UploadRaceFile(request);

            var presenter = new RaceFilePresenter();
            presenter.Populate(resultado);
            return presenter.ViewModel;

        }
    }
}
