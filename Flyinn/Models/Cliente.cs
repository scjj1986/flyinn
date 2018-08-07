using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string cedula { get; set; }
    }
}