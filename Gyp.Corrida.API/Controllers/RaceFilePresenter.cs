using Gyp.Corrida.Application.UseCases.File;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gyp.Corrida.API.Controllers
{
    public class RaceFilePresenter:BasePresenter<RaceFileResult>
    {
        public IActionResult ViewModel { get; protected set; }
        protected override void OnPopulate(RaceFileResult result)
        {
            ViewModel = new CreatedResult("/", new { result.Success, messages=result.Notifications });
        }
    }
}
