using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Violet.Controllers
{
    public class HomeController : CrudController
    {
        public override IActionResult Index()
        {
            return View();
        }
    }
}
