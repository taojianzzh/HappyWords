using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HappyWords.Web.Controllers
{
    [Authorize]
    public class DevToolsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
