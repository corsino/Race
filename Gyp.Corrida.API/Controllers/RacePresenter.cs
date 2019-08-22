using Gyp.Corrida.Application.UseCases.Race;
using Gyp.Corrida.Domain.Race;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gyp.Corrida.API.Controllers
{
    public class RacePresenter:BasePresenter<RaceResult<List<Metrics>>>
    {
        public IActionResult ViewModel { get; protected set; }
        protected override void OnPopulate(RaceResult<List<Metrics>> result)
        {
                ViewModel = new CreatedResult("/", new { success= result.Success,data=result.Data,messages=result.Notifications });
        }
    }
}
