using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            if (ModelState.GetValidationState(nameof(Compromisso.Data))
                == ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(Compromisso.NomeCliente))
                == ModelValidationState.Valid
                && compromisso.NomeCliente.Equals("Alice", StringComparison.OrdinalIgnoreCase)
                && compromisso.Data.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("",
                "Alice não pode ser agendada na segunda-feira");
            }

            if (ModelState.IsValid)
            {
                return View("Completo", compromisso);
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Compra()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Compra(Compra compra)
        { 
            if (ModelState.IsValid)
            {
                return View("CompraConfirmado", compra);
            }
            else
            {
                return View(compra);
            }
        }
    }
}
