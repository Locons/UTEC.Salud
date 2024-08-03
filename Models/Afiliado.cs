namespace UTEC.Salud.Models
{
    public class VistaAfiliado
    {
        public List<Afiliado> Lista { get; set; }
    }

    public class Afiliado
    {
        public string unidadEjecutora { get; set; }
        public string ambitoINEI { get; set; }
        public string vraem { get; set; }
        public string edad { get; set; }
        public string sexo { get; set; }
        public string planSeguro { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
    }
}
