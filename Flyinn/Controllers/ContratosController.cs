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

namespace Flyinn.Controllers
{
    [Authorize(Users = "0")]
    public class ContratosController : Controller
    {
        ConexionBaseDatos Conexion = new ConexionBaseDatos();
        DataTable dsReporte = new DataTable();
        Metodos metodos = new Metodos();
        int idEmpleado;
        int promotor;
        int supervisor;
        int coordinador;
        int gerente;
       
       // Configuracion Configuracion = new Configuracion();     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Principal() //pantalla principal se cargan los combos de la vista cuando se asocia un certiciado aun contrado al darle doble clic sobre el mismo 
        {
            int perfil = Convert.ToInt32(ConfigurationManager.AppSettings["Administrador"]);
            //var Perfiles=Conexion.GeneralConexion("Conexion","SELECT CodigoPerfil ")
            int Codigo = Convert.ToInt32(Session["CodigoPerfil"]);

            if (Codigo == perfil)
            {
                ViewBag.mostrar = 1;
            }
            else
            {
                ViewBag.mostrar = 0;
            }
            metodos.CargarCodigoEmpleado();
            #region Cargar Programas
            ViewData["Programas"] = new SelectList(metodos.CargarProgramas(), "idPrograma", "Descripcion");           
            #endregion    
            #region Cargar Certificados
            ViewData["Certificados"] = new SelectList(metodos.CargarCertificados(), "idCertificado", "CodigoCertificado");
            #endregion                
            #region Cargar Estatus           
            ViewData["Estatus"] = new SelectList(metodos.CargarEstatus(), "idEstatus", "nbEstatus", 1);
            #endregion    
            #region Cargar Perfil
            ViewData["Perfil"] = new SelectList(metodos.CargarPerfil(), "Codigo", "Nombre", 1);
            #endregion    
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
           
            #region codigos empleados sin cargo
            metodos.CargarCodigoEmpleado(); // metodo para traer los codigos de los empleados sin supervisor,sin promotor etc para no colocar el codigocargo directo en el codigo y se trae de base de datos 

            ViewData["SINPROMOTOR"] = Configuracion.sinPromotor;
            ViewData["SINSUPERVISOR"] = Configuracion.sinSupervisor;
            ViewData["SINCOORDINADOR"] = Configuracion.sinCoordinador;
            ViewData["SINGERENTE"] = Configuracion.sinGerente;
            #endregion
            return View(metodos.ListarUsuarios());
        }

        public JsonResult reloadcmbCert()
        {
            //bool res = false;
            ViewData["Certificados"] = new SelectList(metodos.CargarCertificados(), "idCertificado", "CodigoCertificado");
            return Json(ViewData["Certificados"]);
        }
        public ActionResult RefrescarCrearUsuarios()
        {
            return View(metodos.ListarUsuarios());
        }
        public ActionResult Filtrar(DateTime fechaInicio, DateTime fechaFin, int codOfiIsla, int codOfiCosta, int codOfiPlaya, int codOfiCoche, int codOfiSala, int codOfiSala5, string PPF, string PVB, int CodigoPrograma)
        {
            Parametros Pmts = new Parametros(); Pmts.fechaInicio = fechaInicio; Pmts.fechaFin = fechaFin; Pmts.codOfiCoche = codOfiCoche; Pmts.codOfiCosta = codOfiCosta; Pmts.codOfiIsla = codOfiIsla; Pmts.codOfiPlaya = codOfiPlaya; Pmts.codOfiSala = codOfiSala; Pmts.codOfiSala5 = codOfiSala5; Pmts.PPF = PPF; Pmts.PVB = PVB; Pmts.CodigoPrograma = CodigoPrograma;

            return PartialView("ReportTable", metodos.ListaContratos(Pmts));
        }


        #region MÉTODO PARA PROCESAR BITÁCOTA
        

        public string equipocliente()
        {

            return Request.ServerVariables["REMOTE_HOST"];
            /*string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName.Split(new Char[] { '.' });
            return computer_name[0].ToString().ToUpper();*/
        }


        #endregion

        #region INSERTAR COMISION CONTRATO

        


        public JsonResult InsertarComisionContrato(string NroContrato, string codCertificado, double MontoContrato, int Promotores, int EstatusP, int Supervisores, int EstatusS, int Coordinadores, int EstatusC, int Gerentes, int EstatusG)
        {
            bool verifi = false;

            dsReporte = Conexion.GeneralConexion("Conexion", "SELECT COUNT(*) FROM Contratos WHERE NroContrato = '" + NroContrato + "' AND codCertificado IS NOT NULL" /* and rtrim(codCertificado)<>''    "*/, CommandType.Text, new List<Parameters>());
            
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pNroContrato", Valor = NroContrato });
            
            Parametros.Add(new Parameters { nameValue = "@pPromotores", Valor = Promotores });
            Parametros.Add(new Parameters { nameValue = "@pEstatusP", Valor = EstatusP });
            Parametros.Add(new Parameters { nameValue = "@pSupervisores", Valor = Supervisores });
            Parametros.Add(new Parameters { nameValue = "@pEstatusS", Valor = EstatusS });
            Parametros.Add(new Parameters { nameValue = "@pCoordinadores", Valor = Coordinadores });
            Parametros.Add(new Parameters { nameValue = "@pEstatusC", Valor = EstatusC });
            Parametros.Add(new Parameters { nameValue = "@pGerentes", Valor = Gerentes });
            Parametros.Add(new Parameters { nameValue = "@pEstatusG", Valor = EstatusG });
            Parametros.Add(new Parameters { nameValue = "@pMontoContrato", Valor = MontoContrato });

            Bitacora Bit = new Bitacora();

            if(Convert.ToInt32(dsReporte.Rows[0][0]) == 0){
                Parametros.Add(new Parameters { nameValue = "@pcodCertificado", Valor = codCertificado = codCertificado == "<...>" ? "" : codCertificado });      
                dsReporte = Conexion.GeneralConexion("Conexion", "sp_ins_ComisionesContrato", CommandType.StoredProcedure, Parametros);


                //--------------------------------- Bitácora  -----------------------------------//
                Bit = new Bitacora(2, 1, Session["NickUsr"].ToString().ToUpper(), equipocliente());
                Bit.Descripcion = Bit.desc_contr_ins(NroContrato, codCertificado, MontoContrato, Promotores, EstatusP, Supervisores, EstatusS, Coordinadores, EstatusC, Gerentes, EstatusG);
                Bit.ejecutar_bitacora();
                //------------------------------------------------------------------------------//
                
            
            } else {

            //--------------------------------- Bitácora  -----------------------------------------//
            if (Bit.campos_distintos_contratos(NroContrato, codCertificado, MontoContrato, Promotores, EstatusP, Supervisores, EstatusS, Coordinadores, EstatusC, Gerentes, EstatusG)){
                Bit = new Bitacora(2, 2, Session["NickUsr"].ToString().ToUpper(), equipocliente());
                Bit.Descripcion = Bit.desc_contr_mod(NroContrato, codCertificado, MontoContrato, Promotores, EstatusP, Supervisores, EstatusS, Coordinadores, EstatusC, Gerentes, EstatusG);
                Bit.ejecutar_bitacora();
            }//------------------------------------------------------------------------------------//

            DataTable dtt2 = Conexion.GeneralConexion("Conexion", "SELECT * FROM Contratos WHERE NroContrato = '" + NroContrato + "' AND codCertificado IS NOT NULL", CommandType.Text, new List<Parameters>());
            Parametros.Add(new Parameters { nameValue = "@pcodCertificado", Valor = codCertificado = codCertificado == "<...>" ? Convert.ToString(dtt2.Rows[0]["codCertificado"]) : codCertificado });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mod_ComisionesContrato", CommandType.StoredProcedure, Parametros);

            }

            

            verifi = true;

            return Json(verifi);
        }
        #endregion

        #region COMPLEMENTOS
        public ActionResult InsertarComplementos(string[] Lista)
        {
            metodos.insertarComplementos(Lista[0], Convert.ToDateTime(Lista[1]), Convert.ToDouble(Lista[2]), Convert.ToDouble(Lista[3]), Session["NickUsr"].ToString().ToUpper(), equipocliente());
            
            return View() ;
        }
        [HttpPost]
        public ActionResult ConsultarComplementos(Complementos comp)
        {
             //return PartialView("Complementos");
           return PartialView("Complementos",metodos.ListaComplementos(comp.FechaInicio,comp.FechaFin));
        }
        #endregion
        [HttpPost]
        public ActionResult Complementos()
        {
            return RedirectToAction("Principal");
        }
        #region MODULO EMPLEADOS
        public ActionResult ListarEmpleados()
        {
            #region Cargar Cargos
            ViewData["Cargo"] = new SelectList(metodos.CargarCargos(), "CodigoCargo", "Descripcion");
            #endregion
            #region Cargar Programas
            ViewData["Programas"] = new SelectList(metodos.CargarProgramas(), "idPrograma", "Descripcion");
            #endregion 
            return PartialView("Empleados", metodos.ListarEmpleados());
        }
        public ActionResult PartialViewEmpleado()
        {
            #region Cargar Cargos
            ViewData["Cargo"] = new SelectList(metodos.CargarCargos(), "CodigoCargo", "Descripcion");
            #endregion
            #region Cargar Programas
            ViewData["Programas"] = new SelectList(metodos.CargarProgramas(), "idPrograma", "Descripcion");
            #endregion


            return PartialView("Empleados", metodos.ListarEmpleados());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult IngresarEmpleado(Empleado empleados,Cargo cargo,Programas programa,bool indicador)
        {
            try
            {
                List<Parameters> Parametros1 = new List<Parameters>();

                Parametros1.Add(new Parameters { nameValue = "@pCodigo", Valor = empleados.CodigoEmpleado });
                Parametros1.Add(new Parameters { nameValue = "@pCodigoCargo", Valor = cargo.CodigoCargo });
                Parametros1.Add(new Parameters { nameValue = "@pCodigoPrograma", Valor = programa.CodigoPrograma });
                Parametros1.Add(new Parameters { nameValue = "@pNombre", Valor = empleados.Nombres });
                Parametros1.Add(new Parameters { nameValue = "@pEmail", Valor = empleados.Email });
                Parametros1.Add(new Parameters { nameValue = "@pCedula", Valor = empleados.Cedula });
                Parametros1.Add(new Parameters { nameValue = "@pActivo", Valor = empleados.activo });
                var dtEmpleados = new DataTable();

                if (indicador == true)
                {
                   
                        dtEmpleados = Conexion.GeneralConexion("Conexion", "sp_ins_Empleados", CommandType.StoredProcedure, Parametros1);                    
                }
                else
                {
                    Parametros1.Add(new Parameters { nameValue = "@pidEmpleado", Valor = empleados.idEmpleado });
                    dtEmpleados = Conexion.GeneralConexion("Conexion", "sp_mod_Empleados", CommandType.StoredProcedure, Parametros1);
                }
                
                #region Cargar Cargos
                ViewData["Cargo"] = new SelectList(metodos.CargarCargos(), "CodigoCargo", "Descripcion");
                #endregion
                #region Cargar Programas
                ViewData["Programas"] = new SelectList(metodos.CargarProgramas(), "idPrograma", "Descripcion");
                #endregion

                              
                    return PartialView("Empleados", metodos.ListarEmpleados());
             
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
                
            }
                
               
        }
       
        
            
           
        
        #endregion

        #region PARTILVIEW USARIOS
        public ActionResult PartialViewUsuarios(Usuarios usuarios)
        {
            #region Cargar Perfil
            ViewData["Perfil"] = new SelectList(metodos.CargarPerfil(), "Codigo", "Nombre", 1);
            #endregion
           
            return PartialView("Usuarios", metodos.ListarUsuarios());
        }
        #endregion

        #region MODULO USUARIOS
        public ActionResult IngresarUsuarios(Usuarios usuarios)
        {
            #region Cargar Perfil
            ViewData["Perfil"] = new SelectList(metodos.CargarPerfil(), "Codigo", "Nombre", 1);
            #endregion    
            List<Parameters> Parametros1 = new List<Parameters>();
            Parametros1.Add(new Parameters { nameValue = "@pLogin", Valor = usuarios.nbUsuario });
            Parametros1.Add(new Parameters { nameValue = "@pClave", Valor = usuarios.contraseña });
            Parametros1.Add(new Parameters { nameValue = "@pNombres", Valor = usuarios.nombreUser });
            Parametros1.Add(new Parameters { nameValue = "@pApellidos", Valor = usuarios.apeUser });
            Parametros1.Add(new Parameters { nameValue = "@pCodigoPerfil", Valor = usuarios.Perfil });
            Parametros1.Add(new Parameters { nameValue = "@pEmail", Valor = usuarios.correo });
            Parametros1.Add(new Parameters { nameValue = "@pCedula", Valor = usuarios.Cedula });
            Parametros1.Add(new Parameters { nameValue = "@pActivo", Valor = usuarios.activo });
            var dtUsuarios = new DataTable();
            dtUsuarios = Conexion.GeneralConexion("Conexion", "sp_ins_Usuarios", CommandType.StoredProcedure, Parametros1);


            return PartialView("Usuarios", metodos.ListarUsuarios());
        }

        public ActionResult ModificarUsuarios(Usuarios usuarios)
        {
            #region Cargar Perfil
            ViewData["Perfil"] = new SelectList(metodos.CargarPerfil(), "Codigo", "Nombre", 1);
            #endregion    
           // bool verifi = false;
            List<Parameters> Parametros1 = new List<Parameters>();
            Parametros1.Add(new Parameters { nameValue = "@pLogin", Valor = usuarios.nbUsuario });
            Parametros1.Add(new Parameters { nameValue = "@pClave", Valor = usuarios.contraseña });
            Parametros1.Add(new Parameters { nameValue = "@pNombres", Valor = usuarios.nombreUser });
            Parametros1.Add(new Parameters { nameValue = "@pApellidos", Valor = usuarios.apeUser });
            Parametros1.Add(new Parameters { nameValue = "@pCodigoPerfil", Valor = usuarios.Perfil });
            Parametros1.Add(new Parameters { nameValue = "@pEmail", Valor = usuarios.correo });
            Parametros1.Add(new Parameters { nameValue = "@pActivo", Valor = usuarios.activo });
            Parametros1.Add(new Parameters { nameValue = "@pCodigo", Valor = usuarios.Codigo });
            Parametros1.Add(new Parameters { nameValue = "@pCedula", Valor = usuarios.Cedula });
            var dtUsuarios = new DataTable();
            dtUsuarios = Conexion.GeneralConexion("Conexion", "sp_mod_Usuarios", CommandType.StoredProcedure, Parametros1);
         //   verifi = true;
           
            //metodos.ListarUsuarios();
            return PartialView("Usuarios",metodos.ListarUsuarios());         
        }
        #endregion

        #region DATOS POR DEFECTO DEL CERTIFICADO AL CONTRATO


        public JsonResult fReservaCert(string CodigoCertificado)
        {
            var dtcascada = Conexion.GeneralConexion("Conexion", "SELECT * from Certificados where codCertificado='" + CodigoCertificado + "' ", CommandType.Text, new List<Parameters>());
            string res = "";
            if (dtcascada.Rows[0]["FechaReserva"] != DBNull.Value)
            {
                res = Convert.ToString(dtcascada.Rows[0]["FechaReserva"]);

                res = res.Replace(" 12:00:00 a.m.", "");
            }
            else
            {
                res = "";
            }
            return Json(res);
        }

        public JsonResult fViajeCliCert(string CodigoCertificado)
        {
            var dtcascada = Conexion.GeneralConexion("Conexion", "SELECT * from Certificados where codCertificado='" + CodigoCertificado + "' ", CommandType.Text, new List<Parameters>());
            string res = "";
            if (dtcascada.Rows[0]["FechaViajeCliente"] != DBNull.Value)
            {
                res = Convert.ToString(dtcascada.Rows[0]["FechaViajeCliente"]);

                res = res.Replace(" 12:00:00 a.m.", "");
            }
            else
            {
                res = "";
            }
            return Json(res);
        }



        public JsonResult Promotor(Certificados Certificado)
        {            
           var dtcascada = Conexion.GeneralConexion("Conexion", "SELECT idGerente,idPromotor,idCoordinador,idSupervisor from Comisiones_Flyinn where Documento='" + Certificado.CodigoCertificado + "' ", CommandType.Text, new List<Parameters>());
           
            if (Convert.ToString(dtcascada.Rows[0]["idPromotor"]) != "" && Convert.ToString(dtcascada.Rows[0]["idPromotor"]) != " ")
           {
              promotor = Convert.ToInt32(dtcascada.Rows[0]["idPromotor"]);
           }
           else
           {
              promotor = 0;
           }
           return Json(promotor);
        }
        public JsonResult Supervisor(Certificados Certificado)
        {
            var dtcascada = Conexion.GeneralConexion("Conexion", "SELECT idGerente,idPromotor,idCoordinador,idSupervisor from Comisiones_Flyinn where Documento='" + Certificado.CodigoCertificado + "' ", CommandType.Text, new List<Parameters>());
            
            if (Convert.ToString(dtcascada.Rows[0]["idSupervisor"]) != "" && Convert.ToString(dtcascada.Rows[0]["idSupervisor"]) != " ")
            {
                supervisor = Convert.ToInt32(dtcascada.Rows[0]["idSupervisor"]);
            }
            else
            {
               supervisor = 0;
            }
            return Json(supervisor);
        }
        public JsonResult Coordinador(Certificados Certificado)
        {
            var dtcascada = Conexion.GeneralConexion("Conexion", "SELECT idGerente,idPromotor,idCoordinador,idSupervisor from Comisiones_Flyinn where Documento='" + Certificado.CodigoCertificado + "' ", CommandType.Text, new List<Parameters>());
            
            if (Convert.ToString(dtcascada.Rows[0]["idCoordinador"]) != "" && Convert.ToString(dtcascada.Rows[0]["idCoordinador"]) != " ")
            {
                coordinador = Convert.ToInt32(dtcascada.Rows[0]["idCoordinador"]);
            }
            else
            {
                coordinador = 0;
            }
          
            return Json(coordinador);
        }
        public JsonResult Gerente(Certificados Certificado)
        {
            var dtcascada = Conexion.GeneralConexion("Conexion", "SELECT idGerente,idPromotor,idCoordinador,idSupervisor from Comisiones_Flyinn where Documento='" + Certificado.CodigoCertificado + "' ", CommandType.Text, new List<Parameters>());
            
            if (Convert.ToString(dtcascada.Rows[0]["idGerente"])!="" && Convert.ToString(dtcascada.Rows[0]["idGerente"])!=" ")
            {
                 gerente = Convert.ToInt32(dtcascada.Rows[0]["idGerente"]);
            }
            else
            {
                gerente = 0;
            }

            return Json(gerente);
        }
        #endregion

        #region VERFICIAR CODIGO EMPLEADO
        public JsonResult VerificarCodigo(string codigo) // verificar si el codigo del empleado existe y arroja un mjs con error... 
        {
            var verifi = false;
            var dtVerficar = Conexion.GeneralConexion("Conexion","SELECT CODIGO FROM Empleados WHERE CODIGO='"+codigo+"'",CommandType.Text,new List<Parameters>());
            if (dtVerficar.Rows.Count==1)
            {
                verifi = true;
                return Json(verifi);
            }
            return Json(verifi);
            
        }
        #endregion 

        #region CERRAR SESION
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("InicioSesion", "Index");
        }
        #endregion      

    }

   
}