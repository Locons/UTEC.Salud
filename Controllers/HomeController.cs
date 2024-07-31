using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Reflection;
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
            return View();
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

                List<Afiliado> result = new List<Afiliado>();

                //throw new Exception("Prueba");

                result.Add(new Afiliado() { Ubigeo = 123, UnidadEjecutora = "Prueba 1" });
                result.Add(new Afiliado() { Ubigeo = 123, UnidadEjecutora = "Prueba 1" });
                result.Add(new Afiliado() { Ubigeo = 123, UnidadEjecutora = "Prueba 1" });
                result.Add(new Afiliado() { Ubigeo = 123, UnidadEjecutora = "Prueba 1" });
                result.Add(new Afiliado() { Ubigeo = 123, UnidadEjecutora = "Prueba 1" });
                result.Add(new Afiliado() { Ubigeo = 123, UnidadEjecutora = "Prueba 1" });
                result.Add(new Afiliado() { Ubigeo = 123, UnidadEjecutora = "Prueba 1" });
                result.Add(new Afiliado() { Ubigeo = 123, UnidadEjecutora = "Prueba 1" });
                result.Add(new Afiliado() { Ubigeo = 123, UnidadEjecutora = "Prueba 1" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });
                result.Add(new Afiliado() { Ubigeo = 345, UnidadEjecutora = "Prueba 2" });

                model.Lista = result;

                return PartialView("tablaAfiliado", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
