using Gyp.Corrida.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gyp.Corrida.API.Controllers
{
    public abstract class BasePresenter<T> where T : Result
    {
        public IActionResult ViewModel { get; protected set; }
        public void Populate(T result)
        {
            if (result == null || result.Error == ErrorCode.NotFound)
            {
                ViewModel = new NotFoundObjectResult(ApiError.FromResult(result));
            }

            if (result.Invalid)
            {
                ViewModel = new UnprocessableEntityObjectResult(ApiError.FromResult(result));
            }

            OnPopulate(result);
        }

        protected abstract void OnPopulate(T resultado);
    }
}
