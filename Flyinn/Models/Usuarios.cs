using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Usuarios
    {
        public int Codigo { get; set; }
        public string nombreUser { get; set; }
        public string nbUsuario { get; set; }
        public string contraseña { get; set; }
        public int Cedula { get; set; }
        public string apeUser { get; set; }
        public string correo { get; set; }
        public int Perfil { get; set; }
        public int activo { get; set; }
        public string Estado { get; set; }

        public string nbPerfil { get; set; }

    }
}