using HappyWords.Data.Exceptions;
using HappyWords.Web.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace HappyWords.Web.Attributes
{
    public class HandleApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpResponseMessage errorResponse = null;
            var exception = context.Exception;

            if (exception is HappyWordsException)
            {
                errorResponse = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, _CreateErrorMessage(exception.Message, exception));
            }
            else
            {
                errorResponse = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, _CreateErrorMessage("Thre is an unhandled server error", exception));
            }

            throw new HttpResponseException(errorResponse);
        }

        private HttpError _CreateErrorMessage(string message, Exception exception)
        {
            var error = new HttpError(message);
#if DEBUG
            if (exception != null)
            {
                error.MessageDetail = exception.ToString();
            }
#endif
            return error;
        }
    }
}
