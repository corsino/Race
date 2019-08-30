using Gyp.Race.Application.UseCases.Race;
using Gyp.Race.Domain.Race;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gyp.Race.API.Controllers
{
    public class RacePresenter:BasePresenter<RaceResult<Metrics>>
    {
        public new IActionResult ViewModel { get; protected set; }
        protected override void OnPopulate(RaceResult<Metrics> result)
        {
                ViewModel = new CreatedResult("/", new { success= result.Success,data=result.Data,messages=result.Notifications });
        }
    }
}
