﻿namespace UTEC.Salud.Models
{
    public class VistaAfiliado
    {
        public List<Afiliado> Lista { get; set; }
    }

    public class Afiliado
    {
        public int Ubigeo { get; set; }
        public string UnidadEjecutora { get; set; }
        public string Ambito { get; set; }
        public string Vraem { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string PlanSeguro { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
    }
}