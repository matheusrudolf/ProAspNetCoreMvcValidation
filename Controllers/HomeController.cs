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
            if (string.IsNullOrEmpty(compromisso.NomeCliente))
            {
                ModelState.AddModelError(nameof(compromisso.NomeCliente),
                    "Informe seu nome");
            }

            if (ModelState.IsValid)
            {
                return View("Completo", compromisso);
            }
            else
            {
                return View();
            }

            if (ModelState.GetValidationState("Data") == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid && DateTime.Now > compromisso.Data)
            {
                ModelState.AddModelError(nameof(compromisso.Data),
                "Informe uma data futura");
            }

            if (!compromisso.AceitaTermos)
            {
                ModelState.AddModelError(nameof(compromisso.AceitaTermos),
                "Você deve aceitar os termos");
            }

            return View("Completo", compromisso);
        }
    }
}
