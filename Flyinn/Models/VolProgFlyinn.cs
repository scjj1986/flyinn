using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class VolProgFlyinn
    {
        public string nrocontrato { get; set; }

        public string nombre { get; set; }

        public string montocontrato { get; set; }

        public DateTime fechacreacion { get; set; }
        public string estado { get; set; }

        public string estatus { get; set; }

        public DateTime fechaprocesable { get; set; }
        public string descripcion { get; set; }

        public string cedula_rif { get; set; }






        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int codOfiCoche { get; set; }
        public int codOfiCosta { get; set; }
        public int codOfiPlaya { get; set; }
        public int codOfiIsla { get; set; }
        public int codOfiSala { get; set; }
        public int codOfiSala5 { get; set; }

        public int codOfiSala7 { get; set; }

        public string Proc { get; set; }
        public string Pend { get; set; }

        public string Anul { get; set; }









    }
}