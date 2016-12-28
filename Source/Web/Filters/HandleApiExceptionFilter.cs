using HappyWords.Data.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HappyWords.Web.Filters
{
    public class HandleApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is HappyWordsException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Exception = exception;
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Exception = new Exception("There is an unhandled server error", exception);
            }

            context.Result = new JsonResult(new {
                status = context.HttpContext.Response.StatusCode,
                message = context.Exception.Message
            });
        }
    }
}
