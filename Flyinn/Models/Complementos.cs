using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Complementos
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime Fecha { get; set; }
        public string NroContrato { get; set; }
        public float MontoContrato { get; set; }
        public float PorcPromotor { get; set; }
        public float PorcSupervisor { get; set; }
        public float PorcCoordinador { get; set; }
        public float PorcGerente { get; set; }
        public float comisionCoordinador { get; set; }

    }
}