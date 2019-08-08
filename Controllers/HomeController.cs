using Microsoft.AspNetCore.Mvc;
using ProAspNetCoreMvcValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAspNetCoreMvcValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Agenda", new Compromisso { Data = DateTime.Now });
        }

        [HttpPost]
        public ViewResult Agenda(Compromisso compromisso)
        {
            return View("Completo", compromisso);
        }
    }
}
