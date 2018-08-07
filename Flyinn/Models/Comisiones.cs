using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Comisiones
    {
        public string NroContrato { get; set; }
        public string codCertificado { get; set; }
        public float ComisionPromotor { get; set; }
        public float ComisionSupervisor { get; set; }
        public float ComisionGerente { get; set; }
        public float ComisionCoordinador { get; set; }
        public float ComisionLiner { get; set; }
        public float ComisionCloser { get; set; }
        public float TotalComisionP { get; set; }
        public float TotalComisionL { get; set; }
        public float TotalComisionC { get; set; }
        public float MontoTotal { get; set; } 
    }
}