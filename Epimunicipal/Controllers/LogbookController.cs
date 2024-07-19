using Epimunicipal.Service;
using Microsoft.AspNetCore.Mvc;

namespace Epimunicipal.Controllers
{
    /// <summary>
    /// Controller per la gestione del logbook.
    /// </summary>
    public class LogbookController : Controller
    {
        private readonly IVerbalSvc _verbalSvc;

        /// <summary>
        /// Costruttore del controller Logbook.
        /// </summary>
        /// <param name="verbalSvc">Servizio per la gestione dei verbali.</param>
        public LogbookController(IVerbalSvc verbalSvc)
        {
            _verbalSvc = verbalSvc;
        }

        /// <summary>
        /// Visualizza la pagina principale del logbook.
        /// </summary>
        /// <returns>La vista della pagina principale del logbook.</returns>
        public IActionResult Index()
        {
            var verbals = _verbalSvc.GetVerbalsDetails();
            return View(verbals);
        }

        /// <summary>
        /// Recupera i verbali e visualizza la partial view dei verbali.
        /// </summary>
        /// <returns>La partial view dei verbali.</returns>
        public IActionResult GetVerbals()
        {
            var verbals = _verbalSvc.GetVerbalsDetails();
            return PartialView("~/Views/Logbook/_Verbals.cshtml", verbals);
        }

        /// <summary>
        /// Recupera i verbali dei trasgressori e visualizza la partial view dei verbali dei trasgressori.
        /// </summary>
        /// <returns>La partial view dei verbali dei trasgressori.</returns>
        public IActionResult GetTransgressorVerbals()
        {
            var transgressorVerbals = _verbalSvc.GetVerbalsByTrasgressor();
            return PartialView("~/Views/Logbook/_TransgressorVerbals.cshtml", transgressorVerbals);
        }

        /// <summary>
        /// Recupera i punti decurtati dei trasgressori e visualizza la partial view dei punti decurtati.
        /// </summary>
        /// <returns>La partial view dei punti decurtati.</returns>
        public IActionResult GetTransgressorPointsDeducted()
        {
            var transgressorPointsDeducted = _verbalSvc.GetTransgressorPointsDeducted();
            return PartialView("~/Views/Logbook/_TransgressorPointsDeducted.cshtml", transgressorPointsDeducted);
        }

        /// <summary>
        /// Recupera i verbali con decurtazione punti superiori a dieci e visualizza la partial view dei verbali con decurtazione punti superiori a dieci.
        /// </summary>
        /// <returns>La partial view dei verbali con decurtazione punti superiori a dieci.</returns>
        public IActionResult GetVerbalsPointsDeductionOverTen()
        {
            var verbalsPointsDeductionOverTen = _verbalSvc.GetVerbalsPointsDeductedOverTen();
            return PartialView("~/Views/Logbook/_VerbalsPointsDeductionOverTen.cshtml", verbalsPointsDeductionOverTen);
        }

        /// <summary>
        /// Recupera i verbali con importo superiore a 400 e visualizza la partial view dei verbali con importo superiore a 400.
        /// </summary>
        /// <returns>La partial view dei verbali con importo superiore a 400.</returns>
        public IActionResult GetVerbalsAmountOver400()
        {
            var verbalsAmountOver400 = _verbalSvc.GetVerbalsDetailsAmourOver400();
            return PartialView("~/Views/Logbook/_VerbalsAmountOver400.cshtml", verbalsAmountOver400);
        }
    }
}
