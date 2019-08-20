using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Gyp.Corrida.Application;

namespace Gyp.Corrida.API
{
    public class ApiError
    {
        public ApiError()
        {
        }

        public ApiError(IEnumerable<Notification> errors, ErrorCode? error = null)
        {
            this.ErrorType = error;
            this.Errors = errors;
        }

        public ErrorCode? ErrorType { get; private set; }
        public IEnumerable<Notification> Errors { get; private set; }

        public static ApiError FromResult(Result result)
        {
            return new ApiError(result.Notifications, result.Error);
        }
    }
}
