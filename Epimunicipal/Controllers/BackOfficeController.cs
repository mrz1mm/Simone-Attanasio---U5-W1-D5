using Epimunicipal.Models.Dto;
using Epimunicipal.Service;
using Microsoft.AspNetCore.Mvc;

namespace Epimunicipal.Controllers
{
    /// <summary>
    /// Controller per la gestione del back office.
    /// </summary>
    public class BackOfficeController : Controller
    {
        private readonly IPersonalDataSvc _personalDataSvc;
        private readonly IVerbalSvc _verbalSvc;
        private readonly IViolationTypeSvc _violationTypeSvc;

        /// <summary>
        /// Costruttore del controller BackOffice.
        /// </summary>
        /// <param name="personalDataSvc">Servizio per la gestione dei dati personali.</param>
        /// <param name="verbalSvc">Servizio per la gestione dei verbali.</param>
        /// <param name="violationTypeSvc">Servizio per la gestione dei tipi di violazione.</param>
        public BackOfficeController(IPersonalDataSvc personalDataSvc, IVerbalSvc verbalSvc, IViolationTypeSvc violationTypeSvc)
        {
            _personalDataSvc = personalDataSvc;
            _verbalSvc = verbalSvc;
            _violationTypeSvc = violationTypeSvc;
        }

        /// <summary>
        /// Visualizza la pagina principale del back office.
        /// </summary>
        /// <returns>La vista della pagina principale.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Visualizza la partial view per aggiungere un trasgressore.
        /// </summary>
        /// <returns>La partial view per aggiungere un trasgressore.</returns>
        public IActionResult AddTransgressorPartial()
        {
            return PartialView("~/Views/BackOffice/_AddTransgressor.cshtml");
        }

        /// <summary>
        /// Visualizza la partial view per aggiungere un verbale.
        /// </summary>
        /// <returns>La partial view per aggiungere un verbale.</returns>
        public IActionResult AddVerbalPartial()
        {
            var personalDatas = _personalDataSvc.GetPersonalDatas();
            var violationTypes = _violationTypeSvc.GetViolationTypes();

            ViewBag.PersonalDataList = personalDatas.Select(pd => new { Id = pd.PersonalDataId, FullName = pd.Surname + " " + pd.Name }).ToList();
            ViewBag.ViolationTypeList = violationTypes.Select(vt => new { Id = vt.ViolationTypeId, Description = vt.Description }).ToList();

            return PartialView("~/Views/BackOffice/_AddVerbal.cshtml");
        }

        /// <summary>
        /// Aggiunge un nuovo trasgressore.
        /// </summary>
        /// <param name="personalDataDto">I dettagli del trasgressore da aggiungere.</param>
        /// <returns>Una redirezione alla vista principale.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTransgression([Bind("Surname, Name, Address, City, ZipCode, TaxIdCode")] PersonalDataDto personalDataDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                TempData["PersonalData"] = Newtonsoft.Json.JsonConvert.SerializeObject(personalDataDto);
                return RedirectToAction("Index", "BackOffice");
            }

            try
            {
                if (_personalDataSvc.IsTaxIdCodeExists(personalDataDto.TaxIdCode))
                {
                    TempData["Error"] = "Codice Fiscale già presente";
                    TempData["PersonalData"] = Newtonsoft.Json.JsonConvert.SerializeObject(personalDataDto);
                    return RedirectToAction("Index", "BackOffice");
                }

                _personalDataSvc.AddPersonalData(personalDataDto);
                TempData["Success"] = "Trasgressore inserito correttamente";
                return RedirectToAction("Index", "BackOffice");
            }

            catch (Exception ex)
            {
                TempData["Error"] = "Errore nell'inserimento dei Dati Personali";
                TempData["PersonalData"] = Newtonsoft.Json.JsonConvert.SerializeObject(personalDataDto);
                return RedirectToAction("Index", "BackOffice");
            }
        }


        /// <summary>
        /// Aggiunge un nuovo verbale.
        /// </summary>
        /// <param name="verbalDto">I dettagli del verbale da aggiungere.</param>
        /// <returns>Una redirezione alla vista principale.</returns>
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
