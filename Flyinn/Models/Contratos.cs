using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Contratos
    {
        public int idComisiones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaProcesable { get; set; }
        public Cliente Cliente { get; set; }       
        public string NroContrato { get; set; }
        public float MontoContrato { get; set; }        
        public Programas Programa { get; set; }
        public Certificados Certificado { get; set; }
        public Comisiones Comisiones { get; set; }
        public Empleado CodPromotor { get; set; }
        public Empleado CodLiner { get; set; }
        public Empleado CodCloser { get; set; }
        public Empleado Promotor { get; set; }
        public Empleado Gerente { get; set; }
        public Empleado Supervisor { get; set; }
        public Empleado Coordinador { get; set; }
        public Empleado Liner { get; set; }
        public Empleado Closer { get; set; }
        public int Indicador { get; set; }
        public float MontoTotal { get; set; }

        public DateTime fechaReserva { get; set; }

        public DateTime fechaViajeCliente { get; set; }

        public string fReserva { get; set; }

        public string fViajeCliente { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }



    }
}