using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Certificados
    {
        public int idCertificado { get; set; }
        public string CodigoCertificado { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string dia { get; set; }
        public string mes { get; set; }
        public string ano { get; set; }
    
        public string nbCliente { get; set; }
        public string idCliente { get; set; }
        public Sucursal Sucursal { get; set; }
        public Empleado Promotor { get; set; }
        public Empleado Supervisor { get; set; }
        public Empleado Gerente { get; set; }
        public Empleado Liner { get; set; }
        public Empleado Closer { get; set; }
        public Comisiones Comisiones { get; set; }
        public int NroNoches { get; set; }
        public int NroNiños { get; set; }
        public int NroAdultos { get; set; }
        public float MontoPagar { get; set; }
        public string cedulaCliente { get; set; }
        public string cedulaAc { get; set; }
        public string nbAcompañante { get; set; }
        public float montoCertificado { get; set; }
        public string Observaciones { get; set; }

        public Nullable<System.DateTime> fechaReserva { get; set; }

        public Nullable<System.DateTime> fechaViajeCliente { get; set; }

        public string fReserva { get; set; }

        public string  fViajeCliente { get; set; }

    }
}