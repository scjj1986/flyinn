using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Configuracion
    {
        public string nbParametros { get; set; }
        public int valorParametro { get; set; }
        public static int sinPromotor { get; set; }
        public static int sinSupervisor { get; set; }
        public static int sinCoordinador { get; set; }
        public static int sinGerente { get; set; }
        public static int liners { get; set; }
        public static int closer { get; set; }
        public static int promotor { get; set; }
        public static int supervisor { get; set; }
        public static int  coordinador { get; set; }
        public static int  gerente { get; set; }


    }
}