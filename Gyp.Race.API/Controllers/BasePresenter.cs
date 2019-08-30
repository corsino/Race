using Gyp.Race.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gyp.Race.API.Controllers
{
    /// <summary>
    /// Base Class to define error type from application
    /// </summary>
    /// <typeparam name="T">Generic class type associated to base class</typeparam>
    public abstract class BasePresenter<T> where T : Result
    {
        /// <summary>
        /// ViewModel is an IActionResult
        /// </summary>
        public IActionResult ViewModel { get; protected set; }
        /// <summary>
        /// Populate ViewModel IActionResult according to usecase process return
        /// </summary>
        /// <param name="result">Result from UseCase Process</param>
        public void Populate(T result)
        {
            if (result == null || result.Error == ErrorCode.NotFound)
            {
                ViewModel = new NotFoundObjectResult(ApiError.FromResult(result));
                //return;
            }

            if (result.Invalid)
            {
                ViewModel = new UnprocessableEntityObjectResult(ApiError.FromResult(result));
                //return;
            }

            OnPopulate(result);
        }

        /// <summary>
        /// Abstract method OnOpPulate to be override in presenter layer
        /// </summary>
        /// <param name="result">Result that define a return from UseCase process</param>
        protected abstract void OnPopulate(T result);
    }
}
