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

namespace Flyinn.Models
{
    public class Bitacora
    {
        ConexionBaseDatos Conexion = new ConexionBaseDatos();
        DataTable dsReporte = new DataTable();

        public Bitacora()
        {

        }

        public Bitacora(int mod,int ida,string us,string hst)
        {
            this.idmod = mod;
            this.idacc = ida;
            this.Descripcion = "";
            this.usuario = us;
            this.host = hst;
        }



        public int idmod { get; set; }
        public int idacc { get; set; }
        public string Descripcion { get; set; }
        public string usuario { get; set; }
        public string host { get; set; }

        
        #region MÉTODOS QUE GENERA STRINGS DE DESCRIPCIÓN (DEPENDIENDO DEL MÓDULO)


        #region Módulo Certificados

        //Inserción
        public string desc_insertar_cert(Certificados item)
        {
            string cad = "";

            //--------- Carga de nombres de Promotor, Supervisor y Gerente ------------//
            string promotor = nombre_prsucoge(item.Promotor.idEmpleado, "PROMOTOR");
            string supervisor = nombre_prsucoge(item.Supervisor.idEmpleado, "SUPERVISOR");
            string gerente = nombre_prsucoge(item.Gerente.idEmpleado, "GERENTE");
            string cedaco = item.cedulaAc == "0" ? "" : item.cedulaAc;
            //--------------------------------------------------------------------------//


            cad = "INSERCIÓN (CÓDIGO='" + item.CodigoCertificado + "'; FECHA='" + item.Fecha.ToShortDateString() + "' CLIENTE='" + item.nbCliente + "'; CED.CLI.='" + item.cedulaCliente + "'; ACOMP.='" + item.nbAcompañante + "'; CED. ACOMP.='" + cedaco + "'; HOTEL='" + item.Sucursal.nbSucursal + "';  PROMOTOR='" + promotor + "'; SUPERVISOR='" + supervisor + "'; GERENTE='" + gerente + "'; LINER='" + item.Liner.Nombres + "'; CLOSER='" + item.Closer.Nombres + "'; NOCHES='" + item.NroNoches + "'; ADULTOS='" + item.NroAdultos + "'; NIÑOS='" + item.NroNiños + "'; MONTO DEL CERT.='" + item.montoCertificado.ToString() + "'; OBSERVACION='" + item.Observaciones.ToUpper() + "'; F. RESERVA='" + item.fReserva + "'; F. VIAJE CLIENTE='" + item.fViajeCliente + "')";

            return cad;
        }

        //Modificación
        public string desc_modificar_cert(string codCertificado, string codCertificado2, DateTime fechaCertificado, string nbCLiente, string cedulaCliente, string nbAcompanante, string cedulaAc,
            int Noches, int Adultos, int Ninos, int Promotores, int Supervisores, int Gerentes, int Sucursal, string Liner, string Closer, float montoCertificado, string Observaciones, string fechaReserva, string fechaViajeCliente)
        {

            string cad = "";
            DataTable dsAux = new DataTable();
            dsAux = Conexion.GeneralConexion("Conexion", "SELECT c.codCertificado, c.fechaVenta, c.nbCliente,c.cedulaCliente,c.nbAcompañante,c.cedulaAc, c.idSucursal, s.nbSucursal, cf.idPromotor,p.NOMBRE Promotor, cf.idSupervisor, su.NOMBRE Supervisor, cf.idGerente, g.NOMBRE Gerente,c.Liner,c.Closer, c.nroNoches, c.nroAdultos,c.nroNiños,c.montoCertificado, cf.TotalPago,c.observaciones,c.FechaReserva, c.FechaViajeCliente FROM Certificados c INNER JOIN Sucursal s ON s.idSucursal = c.idSucursal LEFT JOIN Comisiones_Flyinn cf ON cf.Documento = c.codCertificado LEFT JOIN Empleados_Flyinn p ON p.ID = cf.idPromotor LEFT JOIN Empleados_Flyinn su ON su.ID = cf.idSupervisor LEFT JOIN Empleados_Flyinn g ON g.ID = cf.idGerente where c.codCertificado='" + codCertificado2 + "'", CommandType.Text, new List<Parameters>());
            cad = "MODIFICACIÓN(";

            if (codCertificado == codCertificado2)
                cad += " CÓD. CERT.='" + codCertificado + "';";
            if (codCertificado != codCertificado2)
                cad += " CÓD. ANT.='" + codCertificado2 + "', COD. NVO.='" + codCertificado + "';";
            if (fechaCertificado != Convert.ToDateTime(dsAux.Rows[0]["fechaVenta"]))
                cad += " FECHA ANT.='" + Convert.ToDateTime(dsAux.Rows[0]["fechaVenta"]).ToShortDateString() + "', FECHA NVA.='" + fechaCertificado.ToShortDateString() + "';";
            if (nbCLiente != Convert.ToString(dsAux.Rows[0]["nbCliente"]))
                cad += " NOM. CLI. ANT.='" + Convert.ToString(dsAux.Rows[0]["nbCliente"]) + "', NOM. CLI. NVO.='" + nbCLiente + "';";
            if (cedulaCliente != Convert.ToString(dsAux.Rows[0]["cedulaCliente"]))
                cad += " CÉD. CLI. ANT.='" + Convert.ToString(dsAux.Rows[0]["cedulaCliente"]) + "', CÉD. CLI. NVO.='" + cedulaCliente + "';";
            if (nbAcompanante != Convert.ToString(dsAux.Rows[0]["nbAcompañante"]))
                cad += " NOM. ACOMP. ANT.='" + Convert.ToString(dsAux.Rows[0]["nbAcompañante"]) + "', NOM. ACOMP. NVO.='" + nbAcompanante + "';";
            if (cedulaAc != Convert.ToString(dsAux.Rows[0]["cedulaAc"]))
                cad += " CÉD. ACOMP. ANT.='" + Convert.ToString(dsAux.Rows[0]["cedulaAc"]) + "', CÉD. ACOMP. NVO.='" + cedulaAc + "';";
            if (Sucursal != Convert.ToInt32(dsAux.Rows[0]["idSucursal"]))
            {

                DataTable dt2 = Conexion.GeneralConexion("Conexion", "SELECT * FROM Sucursal WHERE idSucursal=" + Convert.ToString(dsAux.Rows[0]["idSucursal"]), CommandType.Text, new List<Parameters>());
                cad += " SUC. ANT.='" + Convert.ToString(dt2.Rows[0]["nbSucursal"]) + "', ";
                dt2 = Conexion.GeneralConexion("Conexion", "SELECT * FROM Sucursal WHERE idSucursal=" + Convert.ToString(Sucursal), CommandType.Text, new List<Parameters>());
                cad += "SUC. NVA.='" + Convert.ToString(dt2.Rows[0]["nbSucursal"]) + "';";

            }

            if (Promotores != Convert.ToInt32(dsAux.Rows[0]["idPromotor"]))
                cad += " PROM. ANT.='" + nombre_prsucoge(Convert.ToInt32(dsAux.Rows[0]["idPromotor"]), "PROMOTOR") + "', PROM. NVO.='" + nombre_prsucoge(Promotores, "PROMOTOR") + "';";
            if (Supervisores != Convert.ToInt32(dsAux.Rows[0]["idSupervisor"]))
                cad += " SUP. ANT.='" + nombre_prsucoge(Convert.ToInt32(dsAux.Rows[0]["idSupervisor"]), "SUPERVISOR") + "', SUP. NVO.='" + nombre_prsucoge(Supervisores, "SUPERVISOR") + "';";
            if (Gerentes != Convert.ToInt32(dsAux.Rows[0]["idGerente"]))
                cad += " GTE. ANT.='" + nombre_prsucoge(Convert.ToInt32(dsAux.Rows[0]["idGerente"]), "GERENTE") + "', GTE. NVO.='" + nombre_prsucoge(Gerentes, "GERENTE") + "';";
            if (Liner != Convert.ToString(dsAux.Rows[0]["Liner"]))
                cad += " LIN. ANT.='" + Convert.ToString(dsAux.Rows[0]["Liner"]) + "', LIN. NVO.='" + Liner + "';";
            if (Closer != Convert.ToString(dsAux.Rows[0]["Closer"]))
                cad += " CLO. ANT.='" + Convert.ToString(dsAux.Rows[0]["Closer"]) + "', CLO. NVO.='" + Closer + "';";
            if (Noches != Convert.ToInt32(dsAux.Rows[0]["nroNoches"]))
                cad += " NOCHES ANT.='" + Convert.ToString(dsAux.Rows[0]["nroNoches"]) + "', NOCHES NVO.='" + Convert.ToString(Noches) + "';";
            if (Adultos != Convert.ToInt32(dsAux.Rows[0]["nroAdultos"]))
                cad += " ADULTOS ANT.='" + Convert.ToString(dsAux.Rows[0]["nroAdultos"]) + "', ADULTOS NVO.='" + Convert.ToString(Adultos) + "';";
            if (Ninos != Convert.ToInt32(dsAux.Rows[0]["nroNiños"]))
                cad += " NIÑOS ANT.='" + Convert.ToString(dsAux.Rows[0]["nroNiños"]) + "', NIÑOS NVO.='" + Convert.ToString(Ninos) + "';";
            if (Convert.ToDouble(montoCertificado) != Convert.ToDouble(dsAux.Rows[0]["montoCertificado"]))
                cad += " MONTO CERT. ANT.='" + Convert.ToString(dsAux.Rows[0]["montoCertificado"]) + "', MONTO CERT NVO.='" + Convert.ToString(montoCertificado) + "'";
            if (Observaciones != Convert.ToString(dsAux.Rows[0]["observaciones"]))
                cad += " OBS. ANT.='" + Convert.ToString(dsAux.Rows[0]["observaciones"]) + "', OBS. NVO.='" + Observaciones + "';";




            if (dsAux.Rows[0]["FechaReserva"] == DBNull.Value && fechaReserva != "")
                cad += " F. RESERV. ANT.='', F. RESERV. NVO.='" + Convert.ToDateTime(fechaReserva).ToShortDateString() + "';";
            else if (dsAux.Rows[0]["FechaReserva"] != DBNull.Value && fechaReserva == "")
                cad += " F. RESERV. ANT.='" + Convert.ToDateTime(dsAux.Rows[0]["FechaReserva"]).ToShortDateString() + "', F. RESERV. NVO.='';";
            else if (dsAux.Rows[0]["FechaReserva"] != DBNull.Value && fechaReserva != "")
            {
                if (Convert.ToDateTime(fechaReserva) != Convert.ToDateTime(dsAux.Rows[0]["FechaReserva"]))
                    cad += " F. RESERV. ANT.='" + Convert.ToDateTime(dsAux.Rows[0]["FechaReserva"]).ToShortDateString() + "', F. RESERV. NVO.='" + Convert.ToDateTime(fechaReserva).ToShortDateString() + "';";

            }






            if (dsAux.Rows[0]["FechaViajeCliente"] == DBNull.Value && fechaViajeCliente != "")
                cad += " F. VIAJ. CLI. ANT.='', F. VIAJ. CLI. NVO.='" + Convert.ToDateTime(fechaViajeCliente).ToShortDateString() + "';";
            else if (dsAux.Rows[0]["FechaViajeCliente"] != DBNull.Value && fechaViajeCliente == "")
                cad += " F. VIAJ. CLI. ANT.='" + Convert.ToDateTime(dsAux.Rows[0]["FechaViajeCliente"]).ToShortDateString() + "', F. VIAJ. CLI. NVO.='';";
            else if (dsAux.Rows[0]["FechaViajeCliente"] != DBNull.Value && fechaViajeCliente != "")
            {
                if (Convert.ToDateTime(fechaViajeCliente) != Convert.ToDateTime(dsAux.Rows[0]["FechaViajeCliente"]))
                    cad += " F. VIAJ. CLI. ANT.='" + Convert.ToDateTime(dsAux.Rows[0]["FechaViajeCliente"]).ToShortDateString() + "', F. VIAJ. CLI. NVO.='" + Convert.ToDateTime(fechaViajeCliente).ToShortDateString() + "';";

            }



            cad = cad.Remove(cad.Length - 1);
            cad += ")";


            return cad;
        }


        #endregion

        #region Módulo Contratos


        //Inserción
        public string desc_contr_ins(string NroContrato, string codCertificado, double MontoContrato, int Promotores, int EstatusP, int Supervisores, int EstatusS, int Coordinadores, int EstatusC, int Gerentes, int EstatusG)
        {

            string cad = "";
            string promotor = nombre_prsucoge(Promotores, "PROMOTOR");
            string supervisor = nombre_prsucoge(Supervisores, "SUPERVISOR");
            string coordinador = nombre_prsucoge(Coordinadores, "COORDINADOR");
            string gerente = nombre_prsucoge(Gerentes, "GERENTE");
            string stts_prom = EstatusP == 1 ? "ACTIVO" : "INACTIVO";
            string stts_sup = EstatusS == 1 ? "ACTIVO" : "INACTIVO";
            string stts_coord = EstatusC == 1 ? "ACTIVO" : "INACTIVO";
            string stts_gte = EstatusG == 1 ? "ACTIVO" : "INACTIVO";
            cad = "INSERCIÓN (N° CONTRATO='" + NroContrato + "'; CÓD. CERT='" + codCertificado + "'; MONTO CONTRATO BS.='" + Convert.ToString(MontoContrato) + "'; PROM.='" + promotor + "', ESTATUS PROM.='" + stts_prom + "'; SUP.='" + supervisor + "', ESTATUS SUP.='" + stts_sup + "'; COORD='" + coordinador + "', ESTATUS COORD.='" + stts_coord + "'; GTE.='" + gerente + "', ESTATUS GTE.='" + stts_gte + "')";


            return cad;
        }

        //Modificación
        public string desc_contr_mod(string NroContrato, string codCertificado, double MontoContrato, int Promotores, int EstatusP, int Supervisores, int EstatusS, int Coordinadores, int EstatusC, int Gerentes, int EstatusG)
        {
            string cad = "";

            DataTable dsAux = new DataTable();
            dsAux = Conexion.GeneralConexion("Conexion", "SELECT cnt.codCertificado,cnt.NroContrato,cf.Documento, cf.idPromotor,p.NOMBRE Promotor,cf.EstatusPromotor, cf.idSupervisor, su.NOMBRE Supervisor,cf.EstatusSupervisor,  cf.idCoordinador,coord.NOMBRE Coordinador, cf.EstatusCoordinador,    cf.idGerente, g.NOMBRE Gerente, cf.EstatusGerente FROM Comisiones_Flyinn cf inner join Contratos cnt on cnt.NroContrato=cf.Documento LEFT JOIN Empleados_Flyinn p ON p.ID = cf.idPromotor LEFT JOIN Empleados_Flyinn su ON su.ID = cf.idSupervisor LEFT JOIN Empleados_Flyinn coord ON coord.ID = cf.idCoordinador LEFT JOIN Empleados_Flyinn g ON g.ID = cf.idGerente where cf.Documento='" + NroContrato + "'", CommandType.Text, new List<Parameters>());
            string promotor = nombre_prsucoge(Promotores, "PROMOTOR");
            string supervisor = nombre_prsucoge(Supervisores, "SUPERVISOR");
            string coordinador = nombre_prsucoge(Coordinadores, "COORDINADOR");
            string gerente = nombre_prsucoge(Gerentes, "GERENTE");
            string stts_prom = EstatusP == 1 ? "ACTIVO" : "INACTIVO";
            string stts_sup = EstatusS == 1 ? "ACTIVO" : "INACTIVO";
            string stts_coord = EstatusC == 1 ? "ACTIVO" : "INACTIVO";
            string stts_gte = EstatusG == 1 ? "ACTIVO" : "INACTIVO";


            string stts_ant_prom = Convert.ToInt32(dsAux.Rows[0]["EstatusPromotor"]) == 1 ? "ACTIVO" : "INACTIVO";
            string stts_ant_sup = Convert.ToInt32(dsAux.Rows[0]["EstatusSupervisor"]) == 1 ? "ACTIVO" : "INACTIVO";
            string stts_ant_coord = Convert.ToInt32(dsAux.Rows[0]["EstatusCoordinador"]) == 1 ? "ACTIVO" : "INACTIVO";
            string stts_ant_gte = Convert.ToInt32(dsAux.Rows[0]["EstatusGerente"]) == 1 ? "ACTIVO" : "INACTIVO";




            cad = "MODIFICACIÓN (N° CONTRATO='" + NroContrato + "';";

            if (codCertificado != Convert.ToString(dsAux.Rows[0]["codCertificado"]) && codCertificado != "<...>")
                cad += " CÓD. CERT. ANT.='" + Convert.ToString(dsAux.Rows[0]["codCertificado"]).Trim(new char[] { ' ' }) + "', CÓD. CERT. NVO.='" + codCertificado + "';";


            if (promotor != Convert.ToString(dsAux.Rows[0]["Promotor"]).Trim(new char[] { ' ' }))
                cad += " PROM. ANT.='" + Convert.ToString(dsAux.Rows[0]["Promotor"]).Trim(new char[] { ' ' }) + "', PROM. NVO.='" + promotor + "';";
            if (EstatusP != Convert.ToInt32(dsAux.Rows[0]["EstatusPromotor"]))
                cad += " ESTATUS PROM. ANT.='" + stts_ant_prom + "', ESTATUS PROM. NVO.='" + stts_prom + "';";


            if (supervisor != Convert.ToString(dsAux.Rows[0]["Supervisor"]).Trim(new char[] { ' ' }))
                cad += " SUP. ANT.='" + Convert.ToString(dsAux.Rows[0]["Supervisor"]).Trim(new char[] { ' ' }) + "', SUP. NVO.='" + supervisor + "';";
            if (EstatusS != Convert.ToInt32(dsAux.Rows[0]["EstatusSupervisor"]))
                cad += " ESTATUS SUP. ANT.='" + stts_ant_sup + "', ESTATUS SUP. NVO.='" + stts_sup + "';";


            if (coordinador != Convert.ToString(dsAux.Rows[0]["Coordinador"]).Trim(new char[] { ' ' }))
                cad += " COORD. ANT.='" + Convert.ToString(dsAux.Rows[0]["Coordinador"]).Trim(new char[] { ' ' }) + "', COORD. NVO.='" + coordinador + "';";
            if (EstatusC != Convert.ToInt32(dsAux.Rows[0]["EstatusCoordinador"]))
                cad += " ESTATUS COORD. ANT.='" + stts_ant_coord + "', ESTATUS COORD. NVO.='" + stts_coord + "';";


            if (gerente != Convert.ToString(dsAux.Rows[0]["Gerente"]).Trim(new char[] { ' ' }))
                cad += " GTE. ANT.='" + Convert.ToString(dsAux.Rows[0]["Gerente"]).Trim(new char[] { ' ' }) + "', GTE. NVO.='" + gerente + "';";
            if (EstatusG != Convert.ToInt32(dsAux.Rows[0]["EstatusGerente"]))
                cad += " ESTATUS GTE. ANT.='" + stts_ant_gte + "', ESTATUS GTE. NVO.='" + stts_gte + "';";



            cad = cad.Remove(cad.Length - 1);
            cad += ")";

            return cad;

        }
        
        #endregion

        #region Módulo Reporte Closing

        //Inserción de comisiones
        public string desc_repclo_comi_ins(string Promotores, string comisionPromotor, string Liner, string comisionLiner, string Closer, string comisionCloser, string nroContrato)
        {

            return "INSERCIÓN DE COMISIONES (N° CONTRATO='" + nroContrato + "'; PROMOTOR='" + nombre_prolinclo(true, Promotores, "") + "',COMISIÓN='" + comisionPromotor + "'; LINER='" + nombre_prolinclo(false, "", Liner) + "',COMISIÓN='" + comisionLiner + "'; CLOSER='" + nombre_prolinclo(false, "", Closer) + "',COMISIÓN='" + comisionCloser + "')";
        }

        //Modificación de comisiones
        public string desc_repclo_comi_mod(string Promotores, string comisionPromotor, string Liner, string comisionLiner, string Closer, string comisionCloser, string nroContrato)
        {

            DataTable dsAux = new DataTable();
            dsAux = Conexion.GeneralConexion("Conexion", "SELECT * FROM Comision_Contratos_Procesables WHERE NroContrato = '" + nroContrato + "'", CommandType.Text, new List<Parameters>());

            //-------------- Comisiones en base da datos ------------------//
            double cp = Convert.ToDouble(dsAux.Rows[0]["ComisionPromotor"]);
            double cl = Convert.ToDouble(dsAux.Rows[0]["ComisionLiner"]);
            double cc = Convert.ToDouble(dsAux.Rows[0]["ComisionCloser"]);
            //------------------------------------------------------------//


            //----Comisiones nuevas (Preparación para convertirlas a double y compararlas con las comisiones de base de datos)------//
            comisionPromotor = comisionPromotor.Replace('.', ',');
            comisionLiner = comisionLiner.Replace('.', ',');
            comisionCloser = comisionCloser.Replace('.', ',');
            //----------------------------------------------------//

            string cad = "MODIFICACIÓN DE COMISIONES (N° CONTRATO='" + nroContrato + "';";

            if (Convert.ToDouble(comisionPromotor) != cp)
                cad += " PROMOTOR='" + nombre_prolinclo(true, Promotores, "") + "',COMISIÓN ANT.='" + cp.ToString() + "',COMISIÓN NVA.='" + comisionPromotor.Replace(',', '.') + "';";
            if (Convert.ToDouble(comisionLiner) != cl)
                cad += " LINER='" + nombre_prolinclo(false, "", Liner) + "',COMISIÓN ANT.='" + cl.ToString() + "',COMISIÓN NVA.='" + comisionLiner.Replace(',', '.') + "';";
            if (Convert.ToDouble(comisionCloser) != cc)
                cad += " CLOSER='" + nombre_prolinclo(false, "", Closer) + "',COMISIÓN ANT.='" + cc.ToString() + "',COMISIÓN NVA.='" + comisionCloser.Replace(',', '.') + "';";

            cad = cad.Remove(cad.Length - 1);
            cad += ")";
            return cad;
        }
        

        //Generar
        public string desc_repclo_gen_comi(Parametros p)
        {
            return "GENERAR (FECHA INCIO='" + p.fechaInicio.ToShortDateString() + "'; FECHA FIN='" + p.fechaFin.ToShortDateString() + "'; OFICINAS=" + cadena_oficinas(p) + "; PPF=" + (p.PPF != "PPF" ? "'SI'" : "'NO'") + "; PVB=" + (p.PVB != "PVB" ? "'SI'" : "'NO'") + "; PROGRAMA=" + nombre_programa(p.CodigoPrograma) + ")";
        }

        

        #endregion

        #region Módulo Reporte Comisiones

        //Cierre
        public string desc_repcomi_cierre(DateTime fini,DateTime ffin)
        {
            return "CIERRE (FECHA INICIO='" + fini.ToShortDateString() + "'; FECHA FIN='" + ffin.ToShortDateString() + "')";
        
        }

        #endregion

        #region Módulo Complementos

        //Inserción
        public string desc_comp_ins(string pNroContrato, DateTime pFecha, double pMontoContrato, double pPorcentaje)
        {
            return "INSERCIÓN (N° CONTRATO='" + pNroContrato + "'; FECHA PROCESABLE='"+pFecha.ToShortDateString()+"'; MONTO='"+pMontoContrato.ToString()+"'; PORC.='"+pPorcentaje.ToString()+"')";

        }

        #endregion

        #endregion

        #region MÉTODOS QUE GENERAN OTROS STRINGS (EMPLEADOS, OFICINAS, ETC.)

        //Devuelve el nombre de un Promotor,Supervisor,Coordinador o Gerente
        public string nombre_prsucoge(int id, string tipo)
        {
            DataTable dsAux = new DataTable();
            dsAux = Conexion.GeneralConexion("Conexion", "SELECT * FROM Empleados_Flyinn WHERE ID=" + Convert.ToString(id), CommandType.Text, new List<Parameters>());
            return id == -1 ? "SIN " + tipo : Convert.ToString(dsAux.Rows[0]["NOMBRE"]);
        }

        //Devuelve el nombre de un Promotor, Liner o Closer
        public string nombre_prolinclo(bool prom, string id, string cod)
        {
            DataTable dsAux = new DataTable();
            if (prom)
            {
                int result;
                if (int.TryParse(id, out result))
                {//Si el id que se trae es numérico, se busca en tabla 'Empleados_Flyinn'
                    dsAux = Conexion.GeneralConexion("Conexion", "SELECT * FROM Empleados_Flyinn WHERE ID=" + id + " And Estado=1", CommandType.Text, new List<Parameters>());
                    if (dsAux.Rows.Count == 0)
                        dsAux = Conexion.GeneralConexion("Conexion", "SELECT * FROM Empleados WHERE ID=" + id + " And Estado=1", CommandType.Text, new List<Parameters>());

                }
                else//Si no es numérico, es un código y se busca en tabla 'Empleados'
                    dsAux = Conexion.GeneralConexion("Conexion", "SELECT * FROM Empleados WHERE CODIGO='" + id + "' And Estado=1", CommandType.Text, new List<Parameters>());
            }
            else
                dsAux = Conexion.GeneralConexion("Conexion", "SELECT * FROM Empleados WHERE CODIGO='" + cod + "' And Estado=1", CommandType.Text, new List<Parameters>());

            return (id == "-1" && cod == "") ? "SIN ASIGNAR" : Convert.ToString(dsAux.Rows[0]["NOMBRE"]);

        }

        //Devuelve el nombre de un programa
        public static string nombre_programa(int id)
        {

            DataTable dsAux = new DataTable();
            ConexionBaseDatos Conexion = new ConexionBaseDatos();
            dsAux = Conexion.GeneralConexion("Conexion", "SELECT * FROM Programas WHERE Codigo=" + id.ToString() + " And Estado=1", CommandType.Text, new List<Parameters>());
            if (dsAux.Rows.Count == 0)
                return "'TODOS'";
            else
                return "'" + Convert.ToString(dsAux.Rows[0]["Descripcion"]) + "'";
        }


        //Devuelve el nombre de oficinas dependiendo de los parámetros
        public string cadena_oficinas(Parametros p)
        {

            string cad = "";

            if (p.codOfiCoche == 1)
                cad = "'COCHE'-";
            if (p.codOfiPlaya == 2)
                cad += "'PLAYA EL AGUA'-";
            if (p.codOfiIsla == 3)
                cad += "'ISLA CARIBE'-";
            if (p.codOfiCosta == 4)
                cad += "'COSTA AZUL'-";
            if (p.codOfiSala5 == 5)
                cad += "'SALA 05'-";
            if (p.codOfiSala == 7)
                cad += "'SALA 07'-";

            if (cad == "")
                cad = "'SIN OFICINAS'-";

            cad = cad.Remove(cad.Length - 1);
            return cad;

        }

        #endregion

        #region MÉTODOS PARA COMPARAR CAMPOS (BASE DE DATOS VS NUEVOS)


        //Módulo Certificados
        public bool campos_distintos_certificados(string codCertificado, string codCertificado2, DateTime fechaCertificado, string nbCLiente, string cedulaCliente, string nbAcompanante, string cedulaAc,
            int Noches, int Adultos, int Ninos, int Promotores, int Supervisores, int Gerentes, int Sucursal, string Liner, string Closer, float montoCertificado, string Observaciones, string fechaReserva, string fechaViajeCliente)
        {
            DataTable dsAux = new DataTable();
            if (codCertificado != codCertificado2)
                return true;
            else
            {
                dsAux = Conexion.GeneralConexion("Conexion", "SELECT c.codCertificado, c.fechaVenta, c.nbCliente,c.cedulaCliente,c.nbAcompañante,c.cedulaAc, c.idSucursal, s.nbSucursal, cf.idPromotor,p.NOMBRE Promotor, cf.idSupervisor, su.NOMBRE Supervisor, cf.idGerente, g.NOMBRE Gerente,c.Liner,c.Closer, c.nroNoches, c.nroAdultos,c.nroNiños,c.montoCertificado, cf.TotalPago,c.observaciones,c.FechaReserva, c.FechaViajeCliente FROM Certificados c INNER JOIN Sucursal s ON s.idSucursal = c.idSucursal LEFT JOIN Comisiones_Flyinn cf ON cf.Documento = c.codCertificado LEFT JOIN Empleados_Flyinn p ON p.ID = cf.idPromotor LEFT JOIN Empleados_Flyinn su ON su.ID = cf.idSupervisor LEFT JOIN Empleados_Flyinn g ON g.ID = cf.idGerente where c.codCertificado='" + codCertificado2 + "'", CommandType.Text, new List<Parameters>());
                if (fechaCertificado != Convert.ToDateTime(dsAux.Rows[0]["fechaVenta"]))
                    return true;
                if (nbCLiente != Convert.ToString(dsAux.Rows[0]["nbCliente"]))
                    return true;
                if (cedulaCliente != Convert.ToString(dsAux.Rows[0]["cedulaCliente"]))
                    return true;
                if (nbAcompanante != Convert.ToString(dsAux.Rows[0]["nbAcompañante"]))
                    return true;
                if (cedulaAc != Convert.ToString(dsAux.Rows[0]["cedulaAc"]))
                    return true;
                if (Sucursal != Convert.ToInt32(dsAux.Rows[0]["idSucursal"]))
                    return true;
                if (Promotores != Convert.ToInt32(dsAux.Rows[0]["idPromotor"]))
                    return true;
                if (Supervisores != Convert.ToInt32(dsAux.Rows[0]["idSupervisor"]))
                    return true;
                if (Gerentes != Convert.ToInt32(dsAux.Rows[0]["idGerente"]))
                    return true;
                if (Liner != Convert.ToString(dsAux.Rows[0]["Liner"]))
                    return true;
                if (Closer != Convert.ToString(dsAux.Rows[0]["Closer"]))
                    return true;
                if (Noches != Convert.ToInt32(dsAux.Rows[0]["nroNoches"]))
                    return true;
                if (Adultos != Convert.ToInt32(dsAux.Rows[0]["nroAdultos"]))
                    return true;
                if (Ninos != Convert.ToInt32(dsAux.Rows[0]["nroNiños"]))
                    return true;
                if (Convert.ToDouble(montoCertificado) != Convert.ToDouble(dsAux.Rows[0]["montoCertificado"]))
                    return true;
                if (Observaciones != Convert.ToString(dsAux.Rows[0]["observaciones"]))
                    return true;
                if (dsAux.Rows[0]["FechaReserva"] == DBNull.Value && fechaReserva != "")
                    return true;
                if (dsAux.Rows[0]["FechaReserva"] != DBNull.Value && fechaReserva == "")
                    return true;
                if (dsAux.Rows[0]["FechaReserva"] != DBNull.Value && fechaReserva != "")
                {
                    if (Convert.ToDateTime(fechaReserva) != Convert.ToDateTime(dsAux.Rows[0]["FechaReserva"]))
                        return true;
                }


                if (dsAux.Rows[0]["FechaViajeCliente"] == DBNull.Value && fechaViajeCliente != "")
                    return true;
                if (dsAux.Rows[0]["FechaViajeCliente"] != DBNull.Value && fechaViajeCliente == "")
                    return true;
                if (dsAux.Rows[0]["FechaViajeCliente"] != DBNull.Value && fechaViajeCliente != "")
                {
                    if (Convert.ToDateTime(fechaViajeCliente) != Convert.ToDateTime(dsAux.Rows[0]["FechaViajeCliente"]))
                        return true;

                }



            }

            return false;


        }

        //Módulo Contratos
        public bool campos_distintos_contratos(string NroContrato, string codCertificado, double MontoContrato, int Promotores, int EstatusP, int Supervisores, int EstatusS, int Coordinadores, int EstatusC, int Gerentes, int EstatusG)
        {
            DataTable dsAux = new DataTable();
            dsAux = Conexion.GeneralConexion("Conexion", "SELECT cnt.codCertificado,cnt.NroContrato,cf.Documento, cf.idPromotor,p.NOMBRE Promotor,cf.EstatusPromotor, cf.idSupervisor, su.NOMBRE Supervisor,cf.EstatusSupervisor,  cf.idCoordinador,coord.NOMBRE Coordinador, cf.EstatusCoordinador,    cf.idGerente, g.NOMBRE Gerente, cf.EstatusGerente FROM Comisiones_Flyinn cf inner join Contratos cnt on cnt.NroContrato=cf.Documento LEFT JOIN Empleados_Flyinn p ON p.ID = cf.idPromotor LEFT JOIN Empleados_Flyinn su ON su.ID = cf.idSupervisor LEFT JOIN Empleados_Flyinn coord ON coord.ID = cf.idCoordinador LEFT JOIN Empleados_Flyinn g ON g.ID = cf.idGerente where cf.Documento='" + NroContrato + "'", CommandType.Text, new List<Parameters>());
            string promotor = nombre_prsucoge(Promotores, "PROMOTOR");
            string supervisor = nombre_prsucoge(Supervisores, "SUPERVISOR");
            string coordinador = nombre_prsucoge(Coordinadores, "COORDINADOR");
            string gerente = nombre_prsucoge(Gerentes, "GERENTE");
            string stts_prom = EstatusP == 1 ? "ACTIVO" : "INACTIVO";
            string stts_sup = EstatusS == 1 ? "ACTIVO" : "INACTIVO";
            string stts_coord = EstatusC == 1 ? "ACTIVO" : "INACTIVO";
            string stts_gte = EstatusG == 1 ? "ACTIVO" : "INACTIVO";

            if (codCertificado != Convert.ToString(dsAux.Rows[0]["codCertificado"]) && codCertificado != "<...>")
                return true;


            if (promotor != Convert.ToString(dsAux.Rows[0]["Promotor"]).Trim(new char[] { ' ' }))
                return true;
            if (EstatusP != Convert.ToInt32(dsAux.Rows[0]["EstatusPromotor"]))
                return true;
            if (supervisor != Convert.ToString(dsAux.Rows[0]["Supervisor"]).Trim(new char[] { ' ' }))
                return true;
            if (EstatusS != Convert.ToInt32(dsAux.Rows[0]["EstatusSupervisor"]))
                return true;
            if (coordinador != Convert.ToString(dsAux.Rows[0]["Coordinador"]).Trim(new char[] { ' ' }))
                return true;
            if (EstatusC != Convert.ToInt32(dsAux.Rows[0]["EstatusCoordinador"]))
                return true;
            if (gerente != Convert.ToString(dsAux.Rows[0]["Gerente"]).Trim(new char[] { ' ' }))
                return true;
            if (EstatusG != Convert.ToInt32(dsAux.Rows[0]["EstatusGerente"]))
                return true;





            return false;
        }

        //Módulo Reporte Closing
        public bool campos_distintos_rpcl_comi(string comisionPromotor, string comisionLiner, string comisionCloser, string nroContrato)
        {
            DataTable dsAux = new DataTable();
            dsAux = Conexion.GeneralConexion("Conexion", "SELECT * FROM Comision_Contratos_Procesables WHERE NroContrato = '" + nroContrato + "'", CommandType.Text, new List<Parameters>());


            //-------------- Comisiones en base da datos ------------------//
            double cp = Convert.ToDouble(dsAux.Rows[0]["ComisionPromotor"]);
            double cl = Convert.ToDouble(dsAux.Rows[0]["ComisionLiner"]);
            double cc = Convert.ToDouble(dsAux.Rows[0]["ComisionCloser"]);
            //-------------------------------------------------------------//

            //----------------- Comisiones nuevas (Preparación para convertirlas a double y compararlas con las comisiones de base de datos)------------------------//
            comisionPromotor = comisionPromotor.Replace('.', ',');
            comisionLiner = comisionLiner.Replace('.', ',');
            comisionCloser = comisionCloser.Replace('.', ',');
            //------------------------------------------------------------//


            //------------------ Comparativa de las comisiones -----------//
            if (Convert.ToDouble(comisionPromotor) != cp)
                return true;
            else if (Convert.ToDouble(comisionLiner) != cl)
                return true;
            else if (Convert.ToDouble(comisionCloser) != cc)
                return true;
            //-------------------------------------------------------------//

            return false;
        }



        #endregion
         
        public void ejecutar_bitacora()
        {

            List<Parameters> pmts = new List<Parameters>();
            pmts.Add(new Parameters { nameValue = "@Fecha", Valor = DateTime.Now });
            pmts.Add(new Parameters { nameValue = "@Usuario", Valor = usuario });
            pmts.Add(new Parameters { nameValue = "@Host", Valor = host });
            pmts.Add(new Parameters { nameValue = "@idmodulo", Valor = idmod });
            pmts.Add(new Parameters { nameValue = "@idacc", Valor = idacc });
            pmts.Add(new Parameters { nameValue = "@descr", Valor = Descripcion });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_InsertarSucesoFlyinn", CommandType.StoredProcedure, pmts);

        }

    }
}