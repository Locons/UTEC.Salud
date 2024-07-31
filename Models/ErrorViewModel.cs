namespace UTEC.Salud.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ErrorVistasModel
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
        public string ErrorStackTrace { get; set; }
    }
}
