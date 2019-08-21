﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Gyp.Corrida.Application.UseCases.Race;
using Gyp.Corrida.Domain.Race;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gyp.Corrida.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        
        private readonly IRaceUseCase _raceUseCase;
        public RaceController(IRaceUseCase raceFileUseCase)
        {
            _raceUseCase = raceFileUseCase;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(IEnumerable<Notification>), 422)]
        public IActionResult Post([FromForm]IFormFile file)
        {
            RaceRequest requestRaceResult = new RaceRequest(file);

            RaceResult<List<Metrics>> raceResult = _raceUseCase.ProcessRaceResult(requestRaceResult);

            var presenter = new RacePresenter();
            presenter.Populate(raceResult);
            return presenter.ViewModel;

        }
    }
}
