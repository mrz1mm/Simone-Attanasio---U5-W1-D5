using Epimunicipal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Epimunicipal.Controllers
{
    /// <summary>
    /// Controller per la gestione della homepage.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Costruttore del controller Home.
        /// </summary>
        /// <param name="logger">Logger per la registrazione degli eventi.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Visualizza la pagina principale.
        /// </summary>
        /// <returns>La vista della pagina principale.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Visualizza la pagina di errore.
        /// </summary>
        /// <returns>La vista della pagina di errore.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
