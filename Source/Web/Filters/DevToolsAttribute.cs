using HappyWords.Web.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyWords.Web.Filters
{
    public class DevToolsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.Name != "DevTools")
            {
                throw new UnauthorizedException("Current user is not 'DevTools'");
            }
        }
    }
}
