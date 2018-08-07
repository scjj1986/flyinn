using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Librerias;
using System.Data;
using System.IO;
using Flyinn.Models;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace Flyinn.Controllers
{
    public class IndexController : Controller
    {
        ConexionBaseDatos Conexion = new ConexionBaseDatos();
        DataTable dsReporte = new DataTable();
        string password;
        int userCertificado = Convert.ToInt32(ConfigurationManager.AppSettings["Certificados"]);
        public string md5(string password)
        {
            //Declaraciones
            System.Security.Cryptography.MD5 md5;
            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            //Conversion
            Byte[] encodedBytes = md5.ComputeHash(ASCIIEncoding.Default.GetBytes(password)); //genero el hash a partir de la password original

            //Resultado

            //return BitConverter.ToString(encodedBytes); //esto, devuelve el hash con "-" cada 2 char
            return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encodedBytes).ToLower(), @"-", ""); //devuelve el hash continuo y en minuscula. (igual que en php)
        }
        public string GetMD5Hash(string input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            password = s.ToString();
            return password;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InicioSesion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InicioSesion(Login user)
        {
           
            //user.clave = md5(user.clave);
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pUsuario", Valor = user.usuario });
            Parametros.Add(new Parameters { nameValue = "@pClave", Valor = user.clave });
           
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_ini_Usuarios", CommandType.StoredProcedure,Parametros);

            if (dsReporte.Rows.Count != 0)
            {
                user.perfil = dsReporte.Rows[0]["CodigoPerfil"] != DBNull.Value ? Convert.ToInt32(dsReporte.Rows[0]["CodigoPerfil"]) : 0;
            }


            if (dsReporte.Rows.Count == 0)
            {
                ViewBag.Error = "Usuario o Clave son incorrectos!";
            }
            else if (dsReporte.Rows[0]["Activo"].ToString() == "0")
            {
                ViewBag.Error = "Usuario Inactivo!";
            }
            else if (user.perfil == userCertificado)
            {

                Session["UserCertificado"] = user.perfil;
                Session["NickUsr"] = user.usuario;
                FormsAuthentication.SetAuthCookie("2", false);
                return RedirectToAction("Listado", "Certificados");
            }
            else
            {
                // user.perfil = dsReporte.Rows[0]["CodigoPerfil"] != DBNull.Value ? Convert.ToInt32(dsReporte.Rows[0]["CodigoPerfil"]) : 0;

                Session["CodigoPerfil"] = user.perfil;
                Session["NickUsr"] = user.usuario;
                FormsAuthentication.SetAuthCookie("0", false);
                return RedirectToAction("Principal", "Contratos");
            }

            return View();


        }
    }
}
