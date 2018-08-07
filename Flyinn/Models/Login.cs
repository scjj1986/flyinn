using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flyinn.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Debe Ingresar un Nombre de Usuario", AllowEmptyStrings = false)]

        public string usuario { get; set; }
        [Required(ErrorMessage = "Debe Ingresar una Contraseña", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string clave { get; set; }
        public int perfil { get; set; }

    }
}