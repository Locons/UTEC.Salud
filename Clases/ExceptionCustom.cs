using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using UTEC.Salud.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Text;

namespace UTEC.Salud.Clases
{
    public class ExceptionCustom : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExceptionCustom(
            IWebHostEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider,
            IHttpContextAccessor httpContextAccessor)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public void OnException(ExceptionContext filterContext)
        {
            Exception e = filterContext.Exception;
            ErrorVistasModel vistaModel = new ErrorVistasModel();
            vistaModel.ErrorMessage = e.Message;
            vistaModel.ControllerName = (string)filterContext.RouteData.Values["controller"];
            vistaModel.ActionName = (string)filterContext.RouteData.Values["action"];

            var result = new ViewResult
            {
                ViewName = IsAjaxRequest(filterContext.HttpContext.Request) ? "ModalError" : "Error",
                ViewData = new ViewDataDictionary(_modelMetadataProvider, filterContext.ModelState)
                {
                    Model = vistaModel
                }
            };

            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 400;
        }
    }
}
