using Epimunicipal.Service;
using Microsoft.AspNetCore.Mvc;

namespace Epimunicipal.Controllers
{
    public class LogbookController : Controller
    {
        private readonly VerbalSvc _verbalSvc;
        public LogbookController(VerbalSvc verbalSvc)
        {
            _verbalSvc = verbalSvc;
        }

        public IActionResult Index()
        {
            var verbals = _verbalSvc.GetVerbalsDetails();
            return View(verbals);
        }

        public IActionResult GetVerbals()
        {
            var verbals = _verbalSvc.GetVerbalsDetails();
            return PartialView("~/Views/Logbook/_Verbals.cshtml", verbals);
        }

        public IActionResult GetTransgressorVerbals()
        {
            var transgressorVerbals = _verbalSvc.GetVerbalsByTrasgressor();
            return PartialView("~/Views/Logbook/_TransgressorVerbals.cshtml", transgressorVerbals);
        }

        public IActionResult GetTransgressorPointsDeducted()
        {
            var transgressorPointsDeducted = _verbalSvc.GetTransgressorPointsDeducted();
            return PartialView("~/Views/Logbook/_TransgressorPointsDeducted.cshtml", transgressorPointsDeducted);
        }

        public IActionResult GetVerbalsPointsDeductionOverTen()
        {
            var verbalsPointsDeductionOverTen = _verbalSvc.GetVerbalsPointsDeductedOverTen();
            return PartialView("~/Views/Logbook/_VerbalsPointsDeductionOverTen.cshtml", verbalsPointsDeductionOverTen);
        }

        public IActionResult GetVerbalsAmountOver400()
        {
            var verbalsAmountOver400 = _verbalSvc.GetVerbalsDetailsAmourOver400();
            return PartialView("~/Views/Logbook/_VerbalsAmountOver400.cshtml", verbalsAmountOver400);
        }
    }
}
