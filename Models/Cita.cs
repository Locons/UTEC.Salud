namespace UTEC.Salud.Models
{
    public class VistaCita
    {
        public List<Cita> Lista { get; set; }
    }

    public class Cita
    {
        public string institucion { get; set; }
        public string documento { get; set; }
    }
}
