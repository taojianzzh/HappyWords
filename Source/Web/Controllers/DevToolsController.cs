using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HappyWords.Web.Filters;

namespace HappyWords.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DevToolsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
