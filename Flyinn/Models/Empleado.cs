using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public int idEstatus { get; set; }
        public string nbEstatus { get; set; }
        public Cargo Cargo { get; set; }
        public string Descripcion { get; set; }
        public List<Contratos> Contratos { get; set;}
        public double TotalContratos { get; set; }
        public int CantidadContratos { get; set; }
        public List<Certificados> Certificados { get; set; }
        public double TotalCertificados { get; set; }
        public int CantidadCertificados { get; set; }

        public Programas Programa { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public int activo { get; set; }

        public int Promotor { get; set; }
        public int Supervisor { get; set; }
        public int Coordinador { get; set; }
        public int Gerente { get; set; }

        public int Liner { get; set; }

        public int Closer { get; set; }
        public string Codigo { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }

    }
}