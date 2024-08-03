using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Reflection;
using UTEC.Salud.Clases;
using UTEC.Salud.Models;

namespace UTEC.Salud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Medico()
        {
            return View();
        }

        public IActionResult Cita()
        {
            VistaCita model = new VistaCita();
            return View(model);
        }

        public IActionResult Afiliado()
        {
            VistaAfiliado model = new VistaAfiliado();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVistasModel { ErrorMessage = "Error al obtener datos" });
        }

        [HttpPost]
        public ActionResult ListarAfiliados()
        {
            try
            {
                VistaAfiliado model = new VistaAfiliado();

                Proxy proxy = new Proxy();
                model.Lista = proxy.ListarAfiliados();

                return PartialView("tablaAfiliado", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ListarCitas()
        {
            try
            {
                VistaCita model = new VistaCita();

                Proxy proxy = new Proxy();
                model.Lista = proxy.ListarCita();

                return PartialView("tablaCita", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
