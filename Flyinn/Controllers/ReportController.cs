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
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using Flyinn.Models;
using System.Web.UI;
using System.Text;
using System.Configuration;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Flyinn.Controllers
{
    public class ReportController : Controller
    {
       
        ConexionBaseDatos Conexion = new ConexionBaseDatos();
        DataTable dsReporte = new DataTable();
        Metodos metodos = new Metodos();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TransferirComisiones()
        {

            return View();

        }
        
        public ActionResult Report()
        {
            metodos.CargarCodigoEmpleado(); // metodo para traer los codigos de los empleados sin supervisor,sin promotor etc para no colocar el codigocargo directo en el codigo y se trae de base de datos 
            int perfil = Convert.ToInt32(ConfigurationManager.AppSettings["Administrador"]);
          //var Perfiles=Conexion.GeneralConexion("Conexion","SELECT CodigoPerfil ")
            int Codigo =Convert.ToInt32(Session["CodigoPerfil"]);

            if (Codigo == perfil)
            {
                ViewBag.mostrar = 1;
            }
            else
            {
                ViewBag.mostrar = 0;
            }
            #region Cargar Programas
            ViewData["Programas"] = new SelectList(metodos.CargarProgramas(), "idPrograma", "Descripcion");
            #endregion    
            #region Cargar Promotores
            ViewData["Promotores"] = new SelectList(metodos.CargarEmpleados(Configuracion.promotor), "idEmpleado", "Nombres");
            #endregion
            #region Cargar Liner
            ViewData["Liner"] = new SelectList(metodos.CargarEmpleados(Configuracion.liners), "idEmpleado", "Nombres");
            #endregion
            #region Cargar Closer
            ViewData["Closer"] = new SelectList(metodos.CargarEmpleados(Configuracion.closer), "idEmpleado", "Nombres");
            #endregion

            return View();
        }

        public ActionResult BuscarComiTrans(DateTime fechaInicio, DateTime fechaFin)
        {

            return PartialView("TablaComisionesTransferencia", metodos.ListaComisionesTrans(fechaInicio, fechaFin));
        }


        public ActionResult InsertarComiTrans(DateTime fechaInicio, DateTime fechaFin)
        {
            metodos.InsertarComiTrans(fechaInicio, fechaFin);
            return PartialView();
        }

        

        public ActionResult ActualizarComiTrans(DateTime fechaInicio, DateTime fechaFin)
        {
            metodos.ActualizarComiTrans(fechaInicio, fechaFin);
            return PartialView();
        }



        public ActionResult FiltrarContratos(DateTime fechaInicio, DateTime fechaFin, int codOfiIsla, int codOfiCosta, int codOfiPlaya, int codOfiCoche, int codOfiSala, int codOfiSala5, string PPF, string PVB, int CodigoPrograma)
        {
            Parametros Pmts = new Parametros(); Pmts.fechaInicio = fechaInicio; Pmts.fechaFin = fechaFin; Pmts.codOfiCoche = codOfiCoche; Pmts.codOfiCosta = codOfiCosta; Pmts.codOfiIsla = codOfiIsla; Pmts.codOfiPlaya = codOfiPlaya; Pmts.codOfiSala = codOfiSala; Pmts.codOfiSala5 = codOfiSala5; Pmts.PPF = PPF; Pmts.PVB = PVB; Pmts.CodigoPrograma = CodigoPrograma;
            ViewData["fechaInicio"] = fechaInicio.ToShortDateString();
            ViewData["fechaFin"] = fechaFin.ToShortDateString();
            return PartialView("ReporteContratosProcesables", metodos.ListarContratosProcesables2(Pmts));
        }

        public ActionResult generarC(DateTime fechaInicio, DateTime fechaFin, int codOfiIsla, int codOfiCosta, int codOfiPlaya, int codOfiCoche, int codOfiSala, int codOfiSala5, string PPF, string PVB, int CodigoPrograma)
        {
            Parametros Pmts = new Parametros(); Pmts.fechaInicio = fechaInicio; Pmts.fechaFin = fechaFin; Pmts.codOfiCoche = codOfiCoche; Pmts.codOfiCosta = codOfiCosta; Pmts.codOfiIsla = codOfiIsla; Pmts.codOfiPlaya = codOfiPlaya; Pmts.codOfiSala = codOfiSala; Pmts.codOfiSala5 = codOfiSala5; Pmts.PPF = PPF; Pmts.PVB = PVB; Pmts.CodigoPrograma = CodigoPrograma; Pmts.usr = Session["NickUsr"].ToString().ToUpper(); Pmts.host = equipocliente();
            ViewData["fechaInicio"] = fechaInicio.ToShortDateString();
            ViewData["fechaFin"] = fechaFin.ToShortDateString();
            return PartialView("ReporteContratosProcesables", metodos.generarComision(Pmts));
        }





        public ActionResult FiltrarVPF(DateTime fechaInicio, DateTime fechaFin, int codOfiIsla, int codOfiCosta, int codOfiPlaya, int codOfiCoche, int codOfiSala, int codOfiSala5, int codOfiSala7, string Proc, string Pend, string Anul)
        {
            Parametros Pmts = new Parametros(); Pmts.fechaInicio = fechaInicio; Pmts.fechaFin = fechaFin; Pmts.codOfiCoche = codOfiCoche; Pmts.codOfiCosta = codOfiCosta; Pmts.codOfiIsla = codOfiIsla; Pmts.codOfiPlaya = codOfiPlaya; Pmts.codOfiSala = codOfiSala; Pmts.codOfiSala5 = codOfiSala5; Pmts.codOfiSala7 = codOfiSala7; Pmts.Proc = Proc; Pmts.Pend = Pend; Pmts.Anul = Anul;
            ViewData["fechaInicio"] = fechaInicio.ToShortDateString();
            ViewData["fechaFin"] = fechaFin.ToShortDateString();
            //return PartialView("ReporteTablaVPF", metodos.ListarContratosProcesables2(Pmts));
            return PartialView("ReporteTablaVPF", metodos.ListaVPF(Pmts));
        }
         
         
         



        public ActionResult FiltrarReportesComisionesDetalladas(DateTime fechaInicio, DateTime fechaFin)
        {
            
            return PartialView("ReporteComisionesDetalladas", metodos.ListadoEmpleadoComisiones(fechaInicio, fechaFin));
        }


        public ActionResult FiltrarReportesComisionesHistorico(DateTime fechaInicio, DateTime fechaFin)
        {

            return PartialView("ReporteComisionesHistorico", metodos.ListadoHistorico(fechaInicio, fechaFin));
        }
        public PdfActionResult PDFReporteHistorico(DateTime fechaInicio, DateTime fechaFin)
        {
            return new PdfActionResult(metodos.ListadoHistorico(fechaInicio, fechaFin), (writer, document) =>
            {
                document.SetPageSize(iTextSharp.text.PageSize.A4);
                document.NewPage();
            })
            {
                FileDownloadName = "ReporteHistorico.pdf"
            };
        }


        public ActionResult GuardaHistorico(DateTime fechaInicio, DateTime fechaFin)
        {
            metodos.GuardaHistorico(fechaInicio, fechaFin,Session["NickUsr"].ToString().ToUpper(), equipocliente());
            return PartialView();
        }
        public int verificaCierre(DateTime fechaInicio, DateTime fechaFin)
        {
            if (metodos.verificaCierre(fechaInicio, fechaFin) == 1)
                return 1;
            else return 0;
           
        }
        public PdfActionResult PDFReportesComisionesDetalladas(DateTime fechaInicio, DateTime fechaFin)
        {
            return new PdfActionResult(metodos.ListadoEmpleadoComisiones(fechaInicio, fechaFin), (writer, document) =>
            {
                document.SetPageSize(iTextSharp.text.PageSize.A4);
                document.NewPage();
            })
            {
                FileDownloadName = "ListadoComisionesDetalladas.pdf"
            };
        }
        public PdfActionResult PDFReporteContratosProcesables(DateTime fechaInicio, DateTime fechaFin, int codOfiIsla, int codOfiCosta, int codOfiPlaya, int codOfiCoche, int codOfiSala, int codOfiSala5, string PPF, string PVB, int CodigoPrograma)
        {  
            Parametros Pmts = new Parametros(); Pmts.fechaInicio = fechaInicio; Pmts.fechaFin = fechaFin; Pmts.codOfiCoche = codOfiCoche; Pmts.codOfiCosta = codOfiCosta; Pmts.codOfiIsla = codOfiIsla; Pmts.codOfiPlaya = codOfiPlaya; Pmts.codOfiSala = codOfiSala; Pmts.codOfiSala5 = codOfiSala5; Pmts.PPF = PPF; Pmts.PVB = PVB; Pmts.CodigoPrograma = CodigoPrograma;
            return new PdfActionResult(metodos.ListarContratosProcesables2(Pmts), (writer, document) =>
        {
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            document.NewPage();
        })
        {
            FileDownloadName="ContratosProcesables.pdf"
        };
        }


        public PdfActionResult PDFReporteVPF(DateTime fechaInicio, DateTime fechaFin, int codOfiIsla, int codOfiCosta, int codOfiPlaya, int codOfiCoche, int codOfiSala, int codOfiSala5, int codOfiSala7, string Proc, string Pend, string Anul)
        {
            Parametros Pmts = new Parametros(); Pmts.fechaInicio = fechaInicio; Pmts.fechaFin = fechaFin; Pmts.codOfiCoche = codOfiCoche; Pmts.codOfiCosta = codOfiCosta; Pmts.codOfiIsla = codOfiIsla; Pmts.codOfiPlaya = codOfiPlaya; Pmts.codOfiSala = codOfiSala; Pmts.codOfiSala5 = codOfiSala5; Pmts.codOfiSala7 = codOfiSala7; Pmts.Proc = Proc; Pmts.Pend = Pend; Pmts.Anul = Anul;
            return new PdfActionResult(metodos.ListaVPF(Pmts), (writer, document) =>
            {
                document.SetPageSize(iTextSharp.text.PageSize.A4);
                document.NewPage();
            })
            {
                FileDownloadName = "ReporteVolumenProgramaFlyinn.pdf"
            };
        }
        [HttpPost]


        public ActionResult FiltrarReportesComisiones(DateTime fechaInicio, DateTime fechaFin)
        {
           
            return PartialView("ReporteComisiones", metodos.ListadoComisiones(fechaInicio, fechaFin));
        }


        public ActionResult FiltrarReporteComplementos(DateTime fechaInicio, DateTime fechaFin)
        {

            return PartialView("ReporteComplementos", metodos.ReporteComplementos(fechaInicio, fechaFin));
        }

        public PdfActionResult PDFReporteComplementos(DateTime fechaInicio, DateTime fechaFin)
        {
            return new PdfActionResult(metodos.ReporteComplementos(fechaInicio, fechaFin), (writer, document) =>
            {
                document.SetPageSize(iTextSharp.text.PageSize.A4);
                document.NewPage();
            })
            {
                FileDownloadName = "ReporteComplementos.pdf"
            };
        }




        public PdfActionResult PDFReportesComisiones(DateTime fechaInicio, DateTime fechaFin)
        {
            return new PdfActionResult(metodos.ListadoComisiones(fechaInicio, fechaFin), (writer, document) =>
             {
                document.SetPageSize(iTextSharp.text.PageSize.A4);
                document.NewPage();
            })
            {
                FileDownloadName = "ListadoComisiones.pdf"
            };
        }

        


        [HttpPost]

        #region MÉTODOS PARA DESCRIPCIÓN BITÁCORA (REPORTE CLOSING)

        public string equipocliente()
        {

            /*
            string[] computer_name = System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName.Split(new Char[] { '.' });
            return computer_name[0].ToString().ToUpper();*/
            return Request.ServerVariables["REMOTE_HOST"];
        }
       

        
        #endregion
        public JsonResult InsertarComisiones(string Promotores, string comisionPromotor, string Liner, string comisionLiner, string Closer, string comisionCloser, string nroContrato)// metodo para insertar las comisiones manuales de los contratos procesables para los promotores, liner y closer  
        {

            
            //------------------------------- Bitácora (Juan) ------------------------------------------------------//
            Bitacora Bit = new Bitacora(3, 0, Session["NickUsr"].ToString().ToUpper(), equipocliente());
            dsReporte = Conexion.GeneralConexion("Conexion", "SELECT COUNT(*) FROM Comision_Contratos_Procesables WHERE NroContrato = '" + nroContrato + "'", CommandType.Text, new List<Parameters>());
            if (Convert.ToInt32(dsReporte.Rows[0][0]) == 0) {//Inserción

                Bit.Descripcion = Bit.desc_repclo_comi_ins(Promotores, comisionPromotor, Liner, comisionLiner, Closer, comisionCloser, nroContrato);
                Bit.idacc = 1;
            }
            else if (Bit.campos_distintos_rpcl_comi(comisionPromotor, comisionLiner, comisionCloser, nroContrato))//Modificación
            {
                Bit.Descripcion = Bit.desc_repclo_comi_mod(Promotores, comisionPromotor, Liner, comisionLiner, Closer, comisionCloser, nroContrato);
                Bit.idacc = 2;
            }
            if (Bit.idacc != 0)
                Bit.ejecutar_bitacora();
            //------------------------------------------------------------------------------------------------------//



            List<Parameters> Parametros = new List<Parameters>();
            var a = false;
            Parametros.Add(new Parameters { nameValue = "@pPromotores", Valor = Promotores });
            Parametros.Add(new Parameters { nameValue = "@pcomisionPromotor", Valor = comisionPromotor });
            Parametros.Add(new Parameters { nameValue = "@pLiner", Valor = Liner });
            Parametros.Add(new Parameters { nameValue = "@pcomisionLiner", Valor = comisionLiner });
            Parametros.Add(new Parameters { nameValue = "@pCloser", Valor = Closer });
            Parametros.Add(new Parameters { nameValue = "@pcomisionCloser", Valor = comisionCloser });
            Parametros.Add(new Parameters { nameValue = "@pnroContrato", Valor = nroContrato });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_ins_comisiones_contratosProcesables", CommandType.StoredProcedure, Parametros);
            

            a = true;
            return Json(a);
        }
        //public ActionResult InsertarComisiones1(int comisionPromotor)// metodo para insertar las comisiones manuales de los contratos procesables para los promotores, liner y closer  
        //{
        //    List<Parameters> Parametros = new List<Parameters>();
        //    var a = false;
        //   /// Parametros.Add(new Parameters { nameValue = "@pPromotores", Valor = Promotores });
        //    Parametros.Add(new Parameters { nameValue = "@pcomisionPromotor", Valor = comisionPromotor });
        //    //Parametros.Add(new Parameters { nameValue = "@pLiner", Valor = Liner });
        //    //Parametros.Add(new Parameters { nameValue = "@pcomisionLiner", Valor = comisionLiner });
        //    //Parametros.Add(new Parameters { nameValue = "@pCloser", Valor = Closer });
        //    //Parametros.Add(new Parameters { nameValue = "@pcomisionCloser", Valor = comisionCloser });
        //    //Parametros.Add(new Parameters { nameValue = "@pnroContrato", Valor = nroContrato });


        //    dsReporte = Conexion.GeneralConexion("Conexion", "sp_ins_comisiones_contratosProcesables", CommandType.StoredProcedure, Parametros);
        //    a = true;
        //    return View();
        //}
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