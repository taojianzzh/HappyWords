using HappyWords.Data.Exceptions;
using HappyWords.Web.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HappyWords.Web.Attributes
{
    public class HandleApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //var exception = context.Exception;

            //if (exception is HappyWordsException)
            //{
            //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    context.Exception = new Exception(_CreateErrorMessage(exception.Message, exception), exception);
            //}
            //else
            //{
            //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //    context.Exception = new Exception(_CreateErrorMessage("Thre is an unhandled server error", exception), exception);
            //}

            //base.OnException(context);
        }

//        private HttpError _CreateErrorMessage(string message, Exception exception)
//        {
//            var error = new HttpError(message);
//#if DEBUG
//            if (exception != null)
//            {
//                error.MessageDetail = exception.ToString();
//            }
//#endif
//            return error;
//        }
    }
}
