using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Parametros
    {
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int codOfiCoche { get; set; }
        public int codOfiCosta { get; set; }
        public int codOfiPlaya { get; set; }
        public int codOfiIsla { get; set; }
        public int codOfiSala { get; set; }
        public int codOfiSala5 { get; set; }

        public int codOfiSala7 { get; set; }
        public string PPF { get; set; }
        public string PVB { get; set; }
        public int CodigoPrograma { get; set; }

        public string Proc { get; set; }
        public string Pend { get; set; }

        public string Anul { get; set; }

        public static DateTime fechaIni { get; set; }
        public static DateTime fechaFini { get; set; }

        public int perfil { get; set; }


        public string usr { get; set; }//Parámetro para bitácora

        public string host { get; set; }//Parámetro para bitácora
    }
}