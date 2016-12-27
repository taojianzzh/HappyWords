using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HappyWords.Web.Controllers
{
    public class DevToolsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
