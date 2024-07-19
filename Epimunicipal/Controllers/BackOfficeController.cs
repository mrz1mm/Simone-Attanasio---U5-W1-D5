using Epimunicipal.Models.Dto;
using Epimunicipal.Service;
using Microsoft.AspNetCore.Mvc;

namespace Epimunicipal.Controllers
{
    public class BackOfficeController : Controller
    {
        private readonly PersonalDataSvc _personalDataSvc;
        private readonly VerbalSvc _verbalSvc;
        private readonly ViolationTypeSvc _violationTypeSvc;

        public BackOfficeController(PersonalDataSvc personalDataSvc, VerbalSvc verbalSvc, ViolationTypeSvc violationTypeSvc)
        {
            _personalDataSvc = personalDataSvc;
            _verbalSvc = verbalSvc;
            _violationTypeSvc = violationTypeSvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTransgressorPartial()
        {
            return PartialView("~/Views/BackOffice/_AddTransgressor.cshtml");
        }

        public IActionResult AddVerbalPartial()
        {
            var personalDatas = _personalDataSvc.GetPersonalDatas();
            var violationTypes = _violationTypeSvc.GetViolationTypes();

            ViewBag.PersonalDataList = personalDatas.Select(pd => new { Id = pd.PersonalDataId, FullName = pd.Surname + " " + pd.Name }).ToList();
            ViewBag.ViolationTypeList = violationTypes.Select(vt => new { Id = vt.ViolationTypeId, Description = vt.Description }).ToList();

            return PartialView("~/Views/BackOffice/_AddVerbal.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTransgression([Bind("Surname, Name, Address, City, ZipCode, TaxIdCode")] PersonalDataDto personalDataDto)
            {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return View();
            }

            _personalDataSvc.AddPersonalData(personalDataDto);

            TempData["Success"] = "Trasgressore inserito correttamente";
            return RedirectToAction("Index", "Logbook");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddVerbal([Bind("PersonalDataId, ViolationTypeId, ViolationDate, ViolationAddress, AgentName, VerbalDate, Amount, PointDeduction")] VerbalDto verbalDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return View();
            }

            _verbalSvc.AddVerbal(verbalDto);
            
            TempData["Success"] = "Verbale inserito correttamente";
            return RedirectToAction("Index", "Logbook");
        }
    }
}
