using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Gyp.Corrida.Application;

namespace Gyp.Corrida.API
{
   /// <summary>
   /// ApiError configure application Errors
   /// </summary>
    public class ApiError
    {
        /// <summary>
        /// ApiError Class constructor
        /// </summary>
        public ApiError()
        {
        }

        /// <summary>
        /// ApiError Class constructor
        /// </summary>
        /// <param name="errors">Hold all error notification in application</param>
        /// <param name="error">Hold error code</param>
        public ApiError(IEnumerable<Notification> errors, ErrorCode? error = null)
        {
            this.ErrorType = error;
            this.Errors = errors;
        }

        /// <summary>
        /// Enum ErrorType, define the application error when in runtime.
        /// </summary>
        public ErrorCode? ErrorType { get; private set; }

        /// <summary>
        /// IEnumerable with notification error detail from application
        /// </summary>
        public IEnumerable<Notification> Errors { get; private set; }

        /// <summary>
        /// Convert a object result to ApiError Class Object Type
        /// </summary>
        /// <param name="result">Result from UseCase Process</param>
        /// <returns></returns>
        public static ApiError FromResult(Result result)
        {
            return new ApiError(result.Notifications, result.Error);
        }
    }
}
