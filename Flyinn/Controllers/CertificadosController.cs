using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Drawing;
using RazorPDF;
using RazorPDF.Legacy.Text;
using Librerias;
using Flyinn.Models;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text;
using System.Configuration;
using System.Net;
using System.Security.Principal;



namespace Flyinn.Controllers
{
    public class CertificadosController : Controller
    {
        ConexionBaseDatos Conexion = new ConexionBaseDatos();
        DataTable dsReporte = new DataTable();
        Metodos metodos = new Metodos();
        int userCertificado = Convert.ToInt32(ConfigurationManager.AppSettings["Certificados"]);
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listado(Certificados fechas)
        {
            metodos.CargarCodigoEmpleado(); // metodo para traer los codigos de los empleados sin supervisor,sin promotor etc para no colocar el codigocargo directo en el codigo y se trae de base de datos 
            #region Cargar Promotores
            ViewData["Promotores"] = new SelectList(metodos.CargarEmpleados(Configuracion.promotor), "idEmpleado", "Nombres");
            #endregion
            #region Cargar Supervisores
            ViewData["Supervisores"] = new SelectList(metodos.CargarEmpleados(Configuracion.supervisor), "idEmpleado", "Nombres");
            #endregion
            #region Cargar Coordinadores
            ViewData["Coordinadores"] = new SelectList(metodos.CargarEmpleados(Configuracion.coordinador), "idEmpleado", "Nombres");
            #endregion
            #region Cargar Gerentes
            ViewData["Gerentes"] = new SelectList(metodos.CargarEmpleados(Configuracion.gerente), "idEmpleado", "Nombres");
            #endregion
            #region Cargar Sucursal
            ViewData["Sucursal"] = new SelectList(metodos.CargarSucursal(), "idSucursal", "nbSucursal");
            #endregion              


            //#region Cargar Liner
            //ViewData["Liner"] = new SelectList(metodos.CargarEmpleados(Configuracion.liners), "idEmpleado", "Nombres");
            //#endregion
            //#region Cargar Closer
            //ViewData["Closer"] = new SelectList(metodos.CargarEmpleados(Configuracion.closer), "idEmpleado", "Nombres");
            //#endregion
            if (Convert.ToInt32(Session["UserCertificado"]) == userCertificado)
            {
                ViewBag.Users = true;
            }
            else
            {
                ViewBag.Users = false;
            }
            return View(metodos.ListaCertificados(fechas.fechaInicio,fechas.fechaFin));
        }
        public ActionResult BuscarCertificado(DateTime fechaInicio, DateTime fechaFin)
        {
           
            return PartialView("BuscarCertificado",metodos.ListaCertificados(fechaInicio,fechaFin));
        }
        #region CERRAR SESION
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("InicioSesion", "Index");
        }
        #endregion      

        #region VERIFICAR CERTIFICADO
        public JsonResult VerificarCertificado(string codCertificado, string certificados)
        {
            char[] espacio = { ' ' };
            string[] rest;
            int verifi = 0;
            dsReporte = Conexion.GeneralConexion("Conexion", "SELECT *FROM Certificados WHERE codCertificado ='" + codCertificado + "'", CommandType.Text, new List<Parameters>());
            if (dsReporte.Rows.Count != 0)
            {
                verifi = 1;

            }
            else
            {
                if (certificados != null)
                {
                    rest = certificados.Split(espacio);

                    for (int i = 0; i < rest.Count(); i++)
                    {
                        if (codCertificado == rest[i])
                        {
                            verifi = 2;
                        }
                    }
                }
            }
            return Json(verifi);
        }

        #endregion

        #region MÉTODOS PREPARACIÓN DE DESCRIPCIÓN DE BITÁCORA (INSERCIÓN Y MODIFICACIÓN)


        

        public string equipocliente()
        {

            return Request.ServerVariables["REMOTE_HOST"];
            /*
            string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName.Split(new Char[] { '.' });
            return computer_name[0].ToString().ToUpper();*/
        }


        
        public string aaaa_mm_dd(string fch){

            string[] arr = fch.Split('/');
            return arr[2] + "-" + arr[1] + "-" + arr[0]+" 00:00:00.000";
        }

        #endregion


        [HttpPost]
        [ValidateInput(false)]
        #region INSERTAR CERTIFICADO
        public JsonResult InsertarCertificado(string tablacertificados)
        {
            
            List<Certificados> ListAux = new List<Certificados>();
            Bitacora Bit;
            tablacertificados = tablacertificados.Replace("&nbsp;", "");
            ListAux = metodos.ConvertHtmlTable_TableCertificados(tablacertificados);
            Boolean verifi = false;

            for (int i = 0; i < ListAux.Count; i++)
            {
                dsReporte = Conexion.GeneralConexion("Conexion", "SELECT idSucursal FROM Sucursal WHERE nbSucursal='" + ListAux[i].Sucursal.nbSucursal + "'", CommandType.Text, new List<Parameters>());
                int idSucursal = Convert.ToInt32(dsReporte.Rows[0]["idSucursal"]);
                List<Parameters> Parametros = new List<Parameters>();
                Parametros.Add(new Parameters { nameValue = "@pcodCertificado", Valor = ListAux[i].CodigoCertificado });
                Parametros.Add(new Parameters { nameValue = "@pfechaVenta", Valor = ListAux[i].Fecha });
                Parametros.Add(new Parameters { nameValue = "@pnbCliente", Valor = ListAux[i].nbCliente });
                Parametros.Add(new Parameters { nameValue = "@pnroNoches", Valor = ListAux[i].NroNoches });
                Parametros.Add(new Parameters { nameValue = "@pnroAdultos", Valor = ListAux[i].NroAdultos });
                Parametros.Add(new Parameters { nameValue = "@pnroNiños", Valor = ListAux[i].NroNiños });
                Parametros.Add(new Parameters { nameValue = "@pPromotores", Valor = ListAux[i].Promotor.idEmpleado });
                Parametros.Add(new Parameters { nameValue = "@pSupervisores", Valor = ListAux[i].Supervisor.idEmpleado });
                Parametros.Add(new Parameters { nameValue = "@pGerentes", Valor = ListAux[i].Gerente.idEmpleado });
                Parametros.Add(new Parameters { nameValue = "@pidSucursal", Valor = idSucursal });
                Parametros.Add(new Parameters { nameValue = "@pcedulaCliente", Valor = ListAux[i].cedulaCliente });
                Parametros.Add(new Parameters { nameValue = "@pnbAcompañante", Valor = ListAux[i].nbAcompañante });
                Parametros.Add(new Parameters { nameValue = "@pcedulaAc", Valor = ListAux[i].cedulaAc });
                Parametros.Add(new Parameters { nameValue = "@pObservaciones", Valor = ListAux[i].Observaciones.ToUpper() });
                Parametros.Add(new Parameters { nameValue = "@pmontoCertificado", Valor = ListAux[i].montoCertificado});
                Parametros.Add(new Parameters { nameValue = "@pLiner", Valor = ListAux[i].Liner.Nombres });
                Parametros.Add(new Parameters { nameValue = "@pCloser", Valor = ListAux[i].Closer.Nombres });

                Parametros.Add(new Parameters { nameValue = "@pfechaReserva", Valor = ListAux[i].fReserva == "" ? null : aaaa_mm_dd(ListAux[i].fReserva) });
                Parametros.Add(new Parameters { nameValue = "@pfechaViajeCliente", Valor = ListAux[i].fViajeCliente == "" ? null : aaaa_mm_dd(ListAux[i].fViajeCliente) });


                /*
                Parametros.Add(new Parameters { nameValue = "@pfechaReserva", Valor = ListAux[i].fReserva ==""? DBNull.Value : Convert.ToDateTime(ListAux[i].fReserva) });
                Parametros.Add(new Parameters { nameValue = "@pfechaViajeCliente", Valor = Convert.ToDateTime(ListAux[i].fViajeCliente) });*/

                


                
                dsReporte = Conexion.GeneralConexion("Conexion", "sp_ins_ComisionesCertificado", CommandType.StoredProcedure, Parametros);


                //--------------------------------- Bitácora  -----------------------------------//
                Bit = new Bitacora(1,1,Session["NickUsr"].ToString().ToUpper(),equipocliente());
                Bit.Descripcion = Bit.desc_insertar_cert(ListAux[i]);
                Bit.ejecutar_bitacora();
                //------------------------------------------------------------------------------/

                verifi = true;

            }
            return Json(verifi);
        }

        #endregion
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult ModificarCertificado(string codCertificado, string codCertificado2, DateTime fechaCertificado, string nbCLiente, string cedulaCliente, string nbAcompanante, string cedulaAc,
            int Noches,int Adultos,int Ninos, int Promotores, int Supervisores,int Gerentes, int Sucursal,string Liner,string Closer,float montoCertificado,string Observaciones, string fechaReserva, string fechaViajeCliente)
        {
            bool verifi = false;
            List<Parameters> Parametros = new List<Parameters>();

            //--------------------------------- Bitácora -----------------------------------------//
            Bitacora Bit = new Bitacora(1,2,Session["NickUsr"].ToString().ToUpper(),equipocliente());
            if (Bit.campos_distintos_certificados(codCertificado, codCertificado2, fechaCertificado, nbCLiente, cedulaCliente, nbAcompanante, cedulaAc,Noches,Adultos,Ninos, Promotores, Supervisores,Gerentes,Sucursal,Liner,Closer,montoCertificado,Observaciones,fechaReserva,fechaViajeCliente)){
                Bit.Descripcion = Bit.desc_modificar_cert(codCertificado, codCertificado2, fechaCertificado, nbCLiente, cedulaCliente, nbAcompanante, cedulaAc, Noches, Adultos, Ninos, Promotores, Supervisores, Gerentes, Sucursal, Liner, Closer, montoCertificado, Observaciones, fechaReserva, fechaViajeCliente);
                Bit.ejecutar_bitacora();
            }//-------------------------------------------------------------------------------------//


                Parametros = new List<Parameters>();
                Parametros.Add(new Parameters { nameValue = "@pcodCertificado", Valor = codCertificado });
                Parametros.Add(new Parameters { nameValue = "@pcodCertificado2", Valor = codCertificado2 });
                Parametros.Add(new Parameters { nameValue = "@pfechaVenta", Valor = fechaCertificado });
                Parametros.Add(new Parameters { nameValue = "@pnbCliente", Valor = nbCLiente });
                Parametros.Add(new Parameters { nameValue = "@pnroNoches", Valor = Noches });
                Parametros.Add(new Parameters { nameValue = "@pnroAdultos", Valor = Adultos });
                Parametros.Add(new Parameters { nameValue = "@pnroNiños", Valor = Ninos });
                Parametros.Add(new Parameters { nameValue = "@pPromotores", Valor = Promotores });
                Parametros.Add(new Parameters { nameValue = "@pSupervisores", Valor = Supervisores });
                Parametros.Add(new Parameters { nameValue = "@pGerentes", Valor = Gerentes });
                Parametros.Add(new Parameters { nameValue = "@pidSucursal", Valor = Sucursal });
                Parametros.Add(new Parameters { nameValue = "@pcedulaCliente", Valor = cedulaCliente });
                Parametros.Add(new Parameters { nameValue = "@pnbAcompañante", Valor = nbAcompanante });
                Parametros.Add(new Parameters { nameValue = "@pcedulaAc", Valor = cedulaAc });
                Parametros.Add(new Parameters { nameValue = "@pmontoCertificado", Valor = montoCertificado });
                Parametros.Add(new Parameters { nameValue = "@pObservaciones", Valor = Observaciones.ToUpper() });
                Parametros.Add(new Parameters { nameValue = "@pLiner", Valor = Liner });
                Parametros.Add(new Parameters { nameValue = "@pCloser", Valor = Closer });
                Parametros.Add(new Parameters { nameValue = "@pfechaReserva", Valor = fechaReserva == "" ? null : fechaReserva + " 00:00:00.000" });
                Parametros.Add(new Parameters { nameValue = "@pfechaViajeCliente", Valor = fechaViajeCliente == "" ? null : fechaViajeCliente + " 00:00:00.000" });
                


                dsReporte = Conexion.GeneralConexion("Conexion", "sp_mod_ComisionesCertificado", CommandType.StoredProcedure, Parametros);
          if (dsReporte != null) { verifi = true; }

         return Json(verifi);
        }

    }
}