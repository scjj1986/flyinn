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




namespace Flyinn.Models
{
    public class Metodos
    {
        ConexionBaseDatos Conexion = new ConexionBaseDatos();
        DataTable dsReporte = new DataTable();
        DataTable dscierre = new DataTable();
        string Programa;
        int ind;
        #region SEPARADORES
        string[] separador()
        {
            string[] separador = new string[457];

            for (int z = 1; z < 457; z++)
            {
                if (z == 1)
                {
                    separador[z] = "<tr><td>";
                };
                if (z == 2)
                {
                    separador[z] = "</td><td>";
                }
                if (z == 3)
                {
                    separador[z] = "</td></tr>";
                }
                if (z == 4)
                {
                    separador[z] = "</td><td hidden=\"\">";
                }
                if (z == 5)
                {
                    separador[z] = "";
                }
                else if (z > 5 && z < 156)
                {
                    separador[z] = "<tr id=\"cer" + (z - 6) + "\"><td>";
                }
                else if (z > 155 && z < 306)
                {
                    separador[z] = "<button class=\"btn btn-danger btn-xs\" type=\"button\" id=\"btnmenos\" value=\"-\" onclick=\"menos(cer" + (z - 156) + ")\"><i class=\"glyphicon glyphicon-remove\"></i></button>";
                }
                else if (z > 305 && z < 456)
                {
                    separador[z] = "</td> <td>";
                }

            }
            return separador;

        }

        #endregion

        #region CONVERTIDOR TABLE HTML - TABLA CERTIFICADOS
        public List<Certificados> ConvertHtmlTable_TableCertificados(string texto_tablas)
        {
            List<Certificados> auxList = new List<Certificados>();
            Certificados auxCertificado = new Certificados();
            auxCertificado.Sucursal = new Sucursal();
            auxCertificado.Promotor = new Empleado();
            auxCertificado.Supervisor = new Empleado();
            auxCertificado.Gerente = new Empleado();
            auxCertificado.Liner = new Empleado();
            auxCertificado.Closer = new Empleado();
            string[] separadores = separador();

            try
            {
                List<string> result;
                result = texto_tablas.Split(separadores, StringSplitOptions.None).ToList();

                int i = 1;

                foreach (string s in result)
                {
                    if (s != "" && s != "undefined" && s != null && s != " ")
                    {
                        switch (i)
                        {

                            case 1:
                                auxCertificado.CodigoCertificado = s;
                                i++;
                                break;
                            case 2:
                                auxCertificado.Fecha = Convert.ToDateTime(s);
                                i++;
                                break;
                            case 3:
                                auxCertificado.nbCliente = s;
                                i++;
                                break;
                            case 4:
                                auxCertificado.cedulaCliente = s;
                                i++;
                                break;
                            case 5:
                                auxCertificado.nbAcompañante = s;
                                i++;
                                break;
                            case 6:
                                auxCertificado.cedulaAc = s;
                                i++;
                                break;
                            case 7:
                                auxCertificado.Sucursal.nbSucursal = s;
                                i++;
                                break;
                            case 8:
                                auxCertificado.Promotor.idEmpleado = Convert.ToInt32(s);
                                i++;
                                break;
                            case 9:
                                i++;
                                break;
                            case 10:
                                auxCertificado.Supervisor.idEmpleado = Convert.ToInt32(s);
                                i++;
                                break;
                            case 11:
                                i++;
                                break;
                            case 12:
                                auxCertificado.Gerente.idEmpleado = Convert.ToInt32(s);
                                i++;
                                break;
                            case 13:
                                i++;
                                break;
                            case 14:
                                if (s == "NO")
                                {
                                    auxCertificado.Liner.Nombres = "";
                                }
                                else
                                {
                                    auxCertificado.Liner.Nombres = s;
                                }

                                i++;
                                break;
                            case 15:
                                if (s == "NO")
                                {
                                    auxCertificado.Closer.Nombres = "";
                                }
                                else
                                {
                                    auxCertificado.Closer.Nombres = s;
                                }

                                i++;
                                break;
                            case 16:
                                auxCertificado.NroNoches = Convert.ToInt32(s);
                                i++;
                                break;
                            case 17:
                                auxCertificado.NroAdultos = Convert.ToInt32(s);
                                i++;
                                break;
                            case 18:
                                auxCertificado.NroNiños = Convert.ToInt32(s);
                                i++;
                                break;
                            case 19:
                                auxCertificado.montoCertificado = Convert.ToInt32(s);
                                i++;
                                break;
                            case 20:
                                auxCertificado.MontoPagar = Convert.ToSingle(s);

                                i++;
                                break;
                            case 21:
                                if (s != "SIN OBSERVACIÓN")
                                {
                                    auxCertificado.Observaciones = s;
                                }
                                else
                                {
                                    auxCertificado.Observaciones = "";
                                }
                                i++;
                                break;
                            case 22:
                                auxCertificado.fReserva = s;
                                i++;
                                break;
                            case 23:
                                auxCertificado.fViajeCliente = s;
                                auxList.Add(auxCertificado);
                                auxCertificado = new Certificados();
                                auxCertificado.Sucursal = new Sucursal();
                                auxCertificado.Promotor = new Empleado();
                                auxCertificado.Supervisor = new Empleado();
                                auxCertificado.Gerente = new Empleado();
                                auxCertificado.Liner = new Empleado();
                                auxCertificado.Closer = new Empleado();
                                i = 1;
                                break;

                        }
                    }
                    else {

                        switch (i)
                        {

                            case 22:
                                auxCertificado.fReserva = s;
                                i++;
                                break;
                            case 23:
                                auxCertificado.fViajeCliente = s;
                                auxList.Add(auxCertificado);
                                auxCertificado = new Certificados();
                                auxCertificado.Sucursal = new Sucursal();
                                auxCertificado.Promotor = new Empleado();
                                auxCertificado.Supervisor = new Empleado();
                                auxCertificado.Gerente = new Empleado();
                                auxCertificado.Liner = new Empleado();
                                auxCertificado.Closer = new Empleado();
                                i = 1;
                                break;

                        }
                    
                    
                    
                    
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return auxList;
        }

        #endregion

        #region REPORTE COMISIONES
        public List<Empleado> ListadoComisiones(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Empleado> empleados = new List<Empleado>();
            Empleado empl = new Empleado();
            empl.Cargo = new Cargo();          
            int ind = 1;          

            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaini", Valor = fechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pfechafin", Valor = fechaFin });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_Rep_Comisiones", CommandType.StoredProcedure, Parametros);

            
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {

                
                
                if (i == 0)
                {
                    empl.fechaInicio = fechaInicio;
                    empl.fechaFin = fechaFin;
                    empl.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    empl.Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                    empl.Cargo.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionCargo"]);
                    //empl.idEstatus = Convert.ToInt32(dsReporte.Rows[i]["idEstatus"]);
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 1)
                    {
                        empl.CantidadCertificados = Convert.ToInt32(dsReporte.Rows[i]["Cantidad"]);
                        //empl.TotalCertificados = empl.CantidadCertificados * Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));


                        empl.TotalCertificados = empl.CantidadCertificados * Convert.ToDouble(dsReporte.Rows[i]["ComisionSupervisor"]);
                    }
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 0)
                    {
                        empl.CantidadContratos = Convert.ToInt32(dsReporte.Rows[i]["Cantidad"]);
                        //empl.TotalContratos = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));
                        empl.TotalContratos = Convert.ToDouble(dsReporte.Rows[i]["ComisionSupervisor"]);
                    }

                    empleados.Add(empl);
                    empl = new Empleado();
                    empl.Cargo = new Cargo();

                    ind = 1;
                }
               
                else if (Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) == Convert.ToInt32(dsReporte.Rows[i - 1]["idSupervisor"]))
                {
                    int idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    string Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                   // empl.idEstatus = Convert.ToInt32(dsReporte.Rows[i]["idEstatus"]);
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 1)
                    {
                        empl.CantidadCertificados = Convert.ToInt32(dsReporte.Rows[i]["Cantidad"]);
                        //empl.TotalCertificados = empl.CantidadCertificados * Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));
                        empl.TotalCertificados = empl.CantidadCertificados * Convert.ToDouble(dsReporte.Rows[i]["ComisionSupervisor"]);
                    }                   
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 0)
                    {
                        empl.CantidadContratos = Convert.ToInt32(dsReporte.Rows[i]["Cantidad"]);
                        //empl.TotalContratos = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));
                        empl.TotalContratos = Convert.ToDouble(dsReporte.Rows[i]["ComisionSupervisor"]);
                    }      
                    ind = 0;
                  
                    if (i == dsReporte.Rows.Count - 1)
                    {
                        empleados.Add(empl);
                        empl = new Empleado();
                        empl.Cargo = new Cargo();                            
                        ind = 1;
                    }
                }
                else if (Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) != Convert.ToInt32(dsReporte.Rows[i - 1]["idSupervisor"]))
                {
                    if (ind == 0)
                    {
                        empleados.Add(empl);
                        empl = new Empleado();
                        empl.Cargo = new Cargo();
                               
                        ind = 1;
                    }

                    empl.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    empl.Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                    empl.Cargo.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionCargo"]);
                   // empl.idEstatus = Convert.ToInt32(dsReporte.Rows[i]["idEstatus"]);
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 1)
                    {
                        empl.CantidadCertificados = Convert.ToInt32(dsReporte.Rows[i]["Cantidad"]);
                        //empl.TotalCertificados = empl.CantidadCertificados * Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));
                        empl.TotalCertificados = empl.CantidadCertificados * Convert.ToDouble(dsReporte.Rows[i]["ComisionSupervisor"]);
                    }
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 0)
                    {
                        empl.CantidadContratos = Convert.ToInt32(dsReporte.Rows[i]["Cantidad"]);
                        //empl.TotalContratos = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));
                        empl.TotalContratos = Convert.ToDouble(dsReporte.Rows[i]["ComisionSupervisor"]);
                    }         

                    if (i == dsReporte.Rows.Count - 1 || Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) != Convert.ToInt32(dsReporte.Rows[i + 1]["idSupervisor"]))
                    {
                        empleados.Add(empl);
                        empl = new Empleado();
                        empl.Cargo = new Cargo();                               
                        ind = 1;
                    }
                }
               
            }
            return empleados;
        }
      

        #endregion
        //Guarda historico

        public void GuardaHistorico(DateTime fechaInicio, DateTime fechaFin, string usr, string host)
        {
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaini", Valor = fechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pfechafin", Valor = fechaFin });
            Conexion.GeneralConexion("Conexion", "sp_Rep_ComisionesDetalladas_historico", CommandType.StoredProcedure, Parametros);
            //--------------------------------- Bitácora  -----------------------------------//
            Bitacora Bit = new Bitacora(4,5,usr,host);
            Bit.Descripcion = Bit.desc_repcomi_cierre(fechaInicio, fechaFin);
            Bit.ejecutar_bitacora();
            //------------------------------------------------------------------------------/
        }
        public int verificaCierre(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaini", Valor = fechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pfechafin", Valor = fechaFin });
            dscierre= Conexion.GeneralConexion("Conexion", "sp_verificaCierre", CommandType.StoredProcedure, Parametros);
            if (dscierre.Rows.Count > 0)
                return 1;
            else return 0;
        }
        #region REPORTE COMISIONES DETALLADAS
        public List<Empleado> ListadoEmpleadoComisiones(DateTime fechaInicio, DateTime fechaFin)
        {   
            List<Empleado> empleados = new List<Empleado>();
            Empleado empl = new Empleado();
            empl.Cargo = new Cargo();
            empl.Contratos = new List<Contratos>();
            empl.Certificados = new List<Certificados>();
            Certificados auxCertificado = new Certificados();
            Contratos auxContratos = new Contratos();
            auxContratos.Cliente = new Cliente();
            int ind = 1;

            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaini", Valor = fechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pfechafin", Valor = fechaFin });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_Rep_ComisionesDetalladas", CommandType.StoredProcedure, Parametros);
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                if (i == 0)
                {
                    
                    empl.fechaInicio = fechaInicio;
                    empl.fechaFin = fechaFin;
                    
                    empl.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    empl.Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                    empl.Cargo.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionCargo"]);
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 1)
                    {
                        auxCertificado.CodigoCertificado = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxCertificado.Fecha = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxCertificado.nbCliente = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxCertificado.MontoPagar = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));
                            empl.TotalCertificados += auxCertificado.MontoPagar;
                        }
                        empl.Certificados.Add(auxCertificado);
                        auxCertificado = new Certificados();

                    }
                    else if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 0)
                    {
                        auxContratos.NroContrato = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxContratos.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxContratos.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                        auxContratos.Cliente.Nombres = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxContratos.MontoTotal = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));
                            empl.TotalContratos += auxContratos.MontoTotal;
                        }
                        empl.Contratos.Add(auxContratos);
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                    }

                }

                else if (Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) == Convert.ToInt32(dsReporte.Rows[i - 1]["idSupervisor"]))
                {
                    int idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    string Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 1)
                    {
                        auxCertificado.CodigoCertificado = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxCertificado.Fecha = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxCertificado.nbCliente = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxCertificado.MontoPagar = Convert.ToSingle(dsReporte.Rows[i]["ComisionSupervisor"]);
                            empl.TotalCertificados += auxCertificado.MontoPagar;
                        }
                        empl.Certificados.Add(auxCertificado);
                        auxCertificado = new Certificados();

                    }
                    else if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 0)
                    {
                        auxContratos.NroContrato = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxContratos.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxContratos.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                        auxContratos.Cliente.Nombres = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxContratos.MontoTotal = Convert.ToSingle(dsReporte.Rows[i]["ComisionSupervisor"]);
                            empl.TotalContratos += auxContratos.MontoTotal;
                        }
                        empl.Contratos.Add(auxContratos);
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                    }
                    ind = 0;

                    if (i == dsReporte.Rows.Count - 1)
                    {
                        empleados.Add(empl);
                        empl = new Empleado();
                        empl.Cargo = new Cargo();
                        empl.Contratos = new List<Contratos>();
                        empl.Certificados = new List<Certificados>();
                        auxCertificado = new Certificados();
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                        ind = 1;
                    }
                }
                else if (Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) != Convert.ToInt32(dsReporte.Rows[i - 1]["idSupervisor"]))
                {
                    if (ind == 0)
                    {
                        empleados.Add(empl);
                        empl = new Empleado();
                        empl.Cargo = new Cargo();
                        empl.Contratos = new List<Contratos>();
                        empl.Certificados = new List<Certificados>();
                        auxCertificado = new Certificados();
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();

                        ind = 1;
                    }

                    empl.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    empl.Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                    empl.Cargo.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionCargo"]);
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 1)
                    {
                        auxCertificado.CodigoCertificado = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxCertificado.Fecha = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxCertificado.nbCliente = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxCertificado.MontoPagar = Convert.ToSingle(dsReporte.Rows[i]["ComisionSupervisor"]);
                            empl.TotalCertificados += auxCertificado.MontoPagar;
                        }
                        empl.Certificados.Add(auxCertificado);
                        auxCertificado = new Certificados();

                    }
                    else if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 0)
                    {
                        auxContratos.NroContrato = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxContratos.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxContratos.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                        auxContratos.Cliente.Nombres = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxContratos.MontoTotal = Convert.ToSingle(dsReporte.Rows[i]["ComisionSupervisor"]);
                            empl.TotalContratos += auxContratos.MontoTotal;
                        }
                        empl.Contratos.Add(auxContratos);
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                    }

                    if (i == dsReporte.Rows.Count - 1 || Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) != Convert.ToInt32(dsReporte.Rows[i + 1]["idSupervisor"]))
                    {
                        empleados.Add(empl);
                        empl = new Empleado();
                        empl.Cargo = new Cargo();
                        empl.Contratos = new List<Contratos>();
                        empl.Certificados = new List<Certificados>();
                        auxCertificado = new Certificados();
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                        ind = 1;
                    }
                }

            }
            return empleados;
        }

        public List<Empleado> ListadoHistorico(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Empleado> empleados = new List<Empleado>();
            Empleado empl = new Empleado();
            empl.Cargo = new Cargo();
            empl.Contratos = new List<Contratos>();
            empl.Certificados = new List<Certificados>();
            Certificados auxCertificado = new Certificados();
            Contratos auxContratos = new Contratos();
            auxContratos.Cliente = new Cliente();
            int ind = 1;

            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaini", Valor = fechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pfechafin", Valor = fechaFin });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_Listar_ComisionesDetalladas_historico", CommandType.StoredProcedure, Parametros);
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                if (i == 0)
                {
                    empl.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    empl.Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                    empl.Cargo.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionCargo"]);
                    empl.fechaInicio = fechaInicio;
                    empl.fechaFin = fechaFin;
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 1)
                    {
                        auxCertificado.CodigoCertificado = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxCertificado.Fecha = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxCertificado.nbCliente = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxCertificado.MontoPagar = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));
                            empl.TotalCertificados += auxCertificado.MontoPagar;
                        }
                        empl.Certificados.Add(auxCertificado);
                        auxCertificado = new Certificados();

                    }
                    else if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 0)
                    {
                        auxContratos.NroContrato = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxContratos.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxContratos.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                        auxContratos.Cliente.Nombres = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxContratos.MontoTotal = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2));
                            empl.TotalContratos += auxContratos.MontoTotal;
                        }
                        empl.Contratos.Add(auxContratos);
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                    }

                }

                else if (Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) == Convert.ToInt32(dsReporte.Rows[i - 1]["idSupervisor"]))
                {
                    int idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    string Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 1)
                    {
                        auxCertificado.CodigoCertificado = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxCertificado.Fecha = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxCertificado.nbCliente = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxCertificado.MontoPagar = Convert.ToSingle(dsReporte.Rows[i]["ComisionSupervisor"]);
                            empl.TotalCertificados += auxCertificado.MontoPagar;
                        }
                        empl.Certificados.Add(auxCertificado);
                        auxCertificado = new Certificados();

                    }
                    else if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 0)
                    {
                        auxContratos.NroContrato = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxContratos.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxContratos.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                        auxContratos.Cliente.Nombres = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxContratos.MontoTotal = Convert.ToSingle(dsReporte.Rows[i]["ComisionSupervisor"]);
                            empl.TotalContratos += auxContratos.MontoTotal;
                        }
                        empl.Contratos.Add(auxContratos);
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                    }
                    ind = 0;

                    if (i == dsReporte.Rows.Count - 1)
                    {
                        empleados.Add(empl);
                        empl = new Empleado();
                        empl.Cargo = new Cargo();
                        empl.Contratos = new List<Contratos>();
                        empl.Certificados = new List<Certificados>();
                        auxCertificado = new Certificados();
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                        ind = 1;
                    }
                }
                else if (Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) != Convert.ToInt32(dsReporte.Rows[i - 1]["idSupervisor"]))
                {
                    if (ind == 0)
                    {
                        empleados.Add(empl);
                        empl = new Empleado();
                        empl.Cargo = new Cargo();
                        empl.Contratos = new List<Contratos>();
                        empl.Certificados = new List<Certificados>();
                        auxCertificado = new Certificados();
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();

                        ind = 1;
                    }

                    empl.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    empl.Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                    empl.Cargo.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionCargo"]);
                    if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 1)
                    {
                        auxCertificado.CodigoCertificado = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxCertificado.Fecha = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxCertificado.nbCliente = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxCertificado.MontoPagar = Convert.ToSingle(dsReporte.Rows[i]["ComisionSupervisor"]);
                            empl.TotalCertificados += auxCertificado.MontoPagar;
                        }
                        empl.Certificados.Add(auxCertificado);
                        auxCertificado = new Certificados();

                    }
                    else if (Convert.ToInt32(dsReporte.Rows[i]["IndTipo"]) == 0)
                    {
                        auxContratos.NroContrato = Convert.ToString(dsReporte.Rows[i]["Documento"]);
                        auxContratos.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                        auxContratos.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                        auxContratos.Cliente.Nombres = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                        if (Convert.ToString(dsReporte.Rows[i]["ComisionSupervisor"]) != "")
                        {
                            auxContratos.MontoTotal = Convert.ToSingle(dsReporte.Rows[i]["ComisionSupervisor"]);
                            empl.TotalContratos += auxContratos.MontoTotal;
                        }
                        empl.Contratos.Add(auxContratos);
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                    }

                    if (i == dsReporte.Rows.Count - 1 || Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) != Convert.ToInt32(dsReporte.Rows[i + 1]["idSupervisor"]))
                    {
                        empleados.Add(empl);
                        empl = new Empleado();
                        empl.Cargo = new Cargo();
                        empl.Contratos = new List<Contratos>();
                        empl.Certificados = new List<Certificados>();
                        auxCertificado = new Certificados();
                        auxContratos = new Contratos();
                        auxContratos.Cliente = new Cliente();
                        ind = 1;
                    }
                }

            }
            return empleados;
        }

        #endregion

        #region LISTAR CONTRATOS
        public List<Contratos> ListaContratos(Parametros Pmts) 
        {

            List<Contratos> contratos = new List<Contratos>();
            Contratos contrato = new Contratos();
            contrato.Certificado = new Certificados();
            contrato.Cliente = new Cliente();
            contrato.Comisiones = new Comisiones();
            contrato.Programa = new Programas();
            contrato.Promotor = new Empleado();
            contrato.Comisiones.ComisionPromotor = 0.00f;
            contrato.Coordinador = new Empleado();
            contrato.Comisiones.ComisionCoordinador = 0.00f;
            contrato.Gerente = new Empleado();
            contrato.Comisiones.ComisionGerente = 0.00f;
            contrato.Supervisor = new Empleado();
            contrato.Comisiones.ComisionSupervisor = 0.00f;

            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaInicio", Valor = Pmts.fechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pfechaFin", Valor = Pmts.fechaFin });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiCosta", Valor = Pmts.codOfiCosta });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiCoche", Valor = Pmts.codOfiCoche });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiPlaya", Valor = Pmts.codOfiPlaya });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiIsla", Valor = Pmts.codOfiIsla });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiSala", Valor = Pmts.codOfiSala });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiSala5", Valor = Pmts.codOfiSala5 });
            Parametros.Add(new Parameters { nameValue = "@pPPF", Valor = Pmts.PPF });
            Parametros.Add(new Parameters { nameValue = "@pPVB", Valor = Pmts.PVB });
            Parametros.Add(new Parameters { nameValue = "@pCodigoPrograma", Valor = Pmts.CodigoPrograma });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Contratos_Flyinn", CommandType.StoredProcedure, Parametros);
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
               
                if (i == 0)
                {
                    contrato.fechaInicio = Pmts.fechaInicio;
                    contrato.fechaFin = Pmts.fechaFin;
                }
                
                contrato.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["FechaCreacion"]);
                contrato.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                contrato.Cliente.Nombres = Convert.ToString(dsReporte.Rows[i]["nombres"]);
                contrato.Cliente.Apellidos = Convert.ToString(dsReporte.Rows[i]["apellidos"]);
                contrato.Cliente.cedula = Convert.ToString(dsReporte.Rows[i]["cedula_rif"]);                
                contrato.NroContrato = Convert.ToString(dsReporte.Rows[i]["NroContrato"]);
                contrato.MontoContrato = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["MontoContrato"]), 2));
                contrato.Programa.CodigoPrograma = Convert.ToInt32(dsReporte.Rows[i]["CodigoPrograma"]);
                contrato.Programa.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                contrato.Indicador = Convert.ToInt32(dsReporte.Rows[i]["Indicador"]);



                if (Convert.ToString(dsReporte.Rows[i]["idCertificado"]) != "")
                {
                    contrato.Certificado.idCertificado = Convert.ToInt32(dsReporte.Rows[i]["idCertificado"]);
                }
                contrato.Certificado.CodigoCertificado = Convert.ToString(dsReporte.Rows[i]["codCertificado"]);
                if (Convert.ToString(dsReporte.Rows[i]["idPromotor"]) != "" && dsReporte.Rows[i]["idPromotor"] != null && Convert.ToInt32(dsReporte.Rows[i]["idPromotor"]) != -1)
                {
                    contrato.Promotor.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idPromotor"]);
                    contrato.Promotor.Nombres = Convert.ToString(dsReporte.Rows[i]["Promotor"]);
                   
                    
                    if (dsReporte.Rows[i]["EstatusPromotor"]!=DBNull.Value && dsReporte.Rows[i]["EstatusP"]!=DBNull.Value)
                    {
                        contrato.Promotor.idEstatus = Convert.ToInt32(dsReporte.Rows[i]["EstatusPromotor"]);
                        contrato.Promotor.nbEstatus = Convert.ToString(dsReporte.Rows[i]["EstatusP"]);
                    }
                   
                    contrato.Comisiones.ComisionPromotor =dsReporte.Rows[i]["ComisionPromotor"]!=DBNull.Value? Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionPromotor"]), 2)):0.00f;
                }
                if (Convert.ToString(dsReporte.Rows[i]["idSupervisor"]) != "" && dsReporte.Rows[i]["idSupervisor"] != null && Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) != -1)
                {
                    contrato.Supervisor.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    contrato.Supervisor.Nombres = Convert.ToString(dsReporte.Rows[i]["Supervisor"]);
                    if (dsReporte.Rows[i]["EstatusSupervisor"]!=DBNull.Value && dsReporte.Rows[i]["EstatusS"]!=DBNull.Value )
                    {
                        contrato.Supervisor.idEstatus = Convert.ToInt32(dsReporte.Rows[i]["EstatusSupervisor"]);
                        contrato.Supervisor.nbEstatus = Convert.ToString(dsReporte.Rows[i]["EstatusS"]);
                    }                   

                    contrato.Comisiones.ComisionSupervisor =dsReporte.Rows[i]["ComisionSupervisor"]!=DBNull.Value? Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionSupervisor"]), 2)):0.00f;
                }
                if (Convert.ToString(dsReporte.Rows[i]["idGerente"]) != "" && dsReporte.Rows[i]["idGerente"] != null && Convert.ToInt32(dsReporte.Rows[i]["idGerente"]) != -1)
                {
                    contrato.Gerente.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idGerente"]);
                    contrato.Gerente.Nombres = Convert.ToString(dsReporte.Rows[i]["Gerente"]);
                    if (dsReporte.Rows[i]["EstatusGerente"] != DBNull.Value && dsReporte.Rows[i]["EstatusG"] != DBNull.Value)
                    {
                        contrato.Gerente.idEstatus = Convert.ToInt32(dsReporte.Rows[i]["EstatusGerente"]);
                        contrato.Gerente.nbEstatus = Convert.ToString(dsReporte.Rows[i]["EstatusG"]);
                    }                   
                  
                    contrato.Comisiones.ComisionGerente =dsReporte.Rows[i]["ComisionGerente"]!=DBNull.Value? Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionGerente"]), 2)):0.00f;
                }
                if (Convert.ToString(dsReporte.Rows[i]["idCoordinador"]) != "" && dsReporte.Rows[i]["idCoordinador"] != null && Convert.ToInt32(dsReporte.Rows[i]["idCoordinador"]) != -1)
                {
                    contrato.Coordinador.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idCoordinador"]);
                    contrato.Coordinador.Nombres = Convert.ToString(dsReporte.Rows[i]["Coordinador"]);
                    if (dsReporte.Rows[i]["EstatusCoordinador"] != DBNull.Value && dsReporte.Rows[i]["EstatusC"] != DBNull.Value)
                    {
                        contrato.Coordinador.idEstatus = Convert.ToInt32(dsReporte.Rows[i]["EstatusCoordinador"]);
                        contrato.Coordinador.nbEstatus = Convert.ToString(dsReporte.Rows[i]["EstatusC"]);
                    }                   
             
                    contrato.Comisiones.ComisionCoordinador = dsReporte.Rows[i]["ComisionCoordinador"]!=DBNull.Value?Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionCoordinador"]), 2)):0.00f;
                }
                contrato.Comisiones.MontoTotal = (contrato.Comisiones.ComisionPromotor + contrato.Comisiones.ComisionSupervisor + contrato.Comisiones.ComisionGerente + contrato.Comisiones.ComisionCoordinador);



                if (dsReporte.Rows[i]["FechaReserva"] != DBNull.Value)
                {

                    contrato.fReserva = Convert.ToString(dsReporte.Rows[i]["FechaReserva"]);
                    contrato.fReserva = contrato.fReserva.Replace("12:00:00 a.m.", "");
                    contrato.fechaReserva = Convert.ToDateTime(dsReporte.Rows[i]["FechaReserva"]);

                }
                else
                {

                    contrato.fReserva = "";
                }

                if (dsReporte.Rows[i]["FechaViajeCliente"] != DBNull.Value)
                {

                    contrato.fViajeCliente = Convert.ToString(dsReporte.Rows[i]["FechaViajeCliente"]);
                    contrato.fViajeCliente = contrato.fViajeCliente.Replace("12:00:00 a.m.", "");
                    contrato.fechaViajeCliente = Convert.ToDateTime(dsReporte.Rows[i]["FechaViajeCliente"]);

                }
                else
                {

                    contrato.fViajeCliente = "";
                }





                contratos.Add(contrato);              
                contrato = new Contratos();
                contrato.Certificado = new Certificados();
                contrato.Cliente = new Cliente();
                contrato.Comisiones = new Comisiones();
                contrato.Programa = new Programas();
                contrato.Promotor = new Empleado();
                contrato.Comisiones.ComisionPromotor = 0.00f;
                contrato.Coordinador = new Empleado();
                contrato.Comisiones.ComisionCoordinador = 0.00f;
                contrato.Gerente = new Empleado();
                contrato.Comisiones.ComisionGerente = 0.00f;
                contrato.Supervisor = new Empleado();
                contrato.Comisiones.ComisionSupervisor = 0.00f;
                 
                    
            }                     
            return contratos;
        }
        #endregion



        #region LISTAR COMISIONES PARA TRANSFERIR

        public List<ComisionesTrans> ListaComisionesTrans(DateTime fchini, DateTime fchfin)
        {

            List<ComisionesTrans> lcomtrans = new List<ComisionesTrans>();
            ComisionesTrans comtrans = new ComisionesTrans();

            

            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaini", Valor = fchini });
            Parametros.Add(new Parameters { nameValue = "@pfechafin", Valor = fchfin });
            dsReporte = Conexion.ConexionNominaProfit("Conexion", "_SP_mostrar_nom_flyinn", CommandType.StoredProcedure, Parametros);
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {

                comtrans.nombre_completo = Convert.ToString(dsReporte.Rows[i]["nombre_completo"]);
                comtrans.monto = Convert.ToString(dsReporte.Rows[i]["monto"]);
                comtrans.tipo = Convert.ToString(dsReporte.Rows[i]["tipo"]);
                lcomtrans.Add(comtrans);
                comtrans = new ComisionesTrans();
            }
            return lcomtrans;
        }

        #endregion

        #region INSERTAR COMISIONES PARA TRANSFERIR

        public void InsertarComiTrans(DateTime fchini, DateTime fchfin)
        {
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaini", Valor = fchini });
            Parametros.Add(new Parameters { nameValue = "@pfechafin", Valor = fchfin });
            Conexion.ConexionNominaProfit("Conexion", "_SP_insertar_nom_flyinn", CommandType.StoredProcedure, Parametros);
        }

        #endregion

        #region ACTUALIZAR COMISIONES PARA TRANSFERIR

        public void ActualizarComiTrans(DateTime fchini, DateTime fchfin)
        {
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaini", Valor = fchini });
            Parametros.Add(new Parameters { nameValue = "@pfechafin", Valor = fchfin });
            Conexion.ConexionNominaProfit("Conexion", "_SP_actualizar_transf_flyinn", CommandType.StoredProcedure, Parametros);
        }

        #endregion


        public List<VolProgFlyinn> ListaVPF(Parametros Pmts)
        {

            List<VolProgFlyinn> lista = new List<VolProgFlyinn>();
            VolProgFlyinn vpf = new VolProgFlyinn();
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@FECHA_INI", Valor = Pmts.fechaInicio});
            Parametros.Add(new Parameters { nameValue = "@FECHA_FIN", Valor = Pmts.fechaFin });
            Parametros.Add(new Parameters { nameValue = "@PROC", Valor = Pmts.Proc});
            Parametros.Add(new Parameters { nameValue = "@PEND", Valor = Pmts.Pend });
            Parametros.Add(new Parameters { nameValue = "@ANUL", Valor = Pmts.Anul});
            Parametros.Add(new Parameters { nameValue = "@PCODOFICOCHE", Valor = Pmts.codOfiCoche });
            Parametros.Add(new Parameters { nameValue = "@PCODOFICOSTA", Valor = Pmts.codOfiCosta });
            Parametros.Add(new Parameters { nameValue = "@PCODOFIPLAYA", Valor = Pmts.codOfiPlaya });
            Parametros.Add(new Parameters { nameValue = "@PCODOFIISLA", Valor = Pmts.codOfiIsla });
            Parametros.Add(new Parameters { nameValue = "@PCODOFISALA5", Valor = Pmts.codOfiSala5 });
            Parametros.Add(new Parameters { nameValue = "@PCODOFISALA7", Valor = Pmts.codOfiSala7 });
            dsReporte = Conexion.GeneralConexion("Conexion", "Sp_VolumenFlyinn", CommandType.StoredProcedure, Parametros);
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {

                vpf.nrocontrato = Convert.ToString(dsReporte.Rows[i]["NroContrato"]);
                vpf.nombre = Convert.ToString(dsReporte.Rows[i]["Nombre"]);
                vpf.montocontrato = Convert.ToString(dsReporte.Rows[i]["MontoContrato"]);
                vpf.fechacreacion = Convert.ToDateTime(dsReporte.Rows[i]["FechaCreacion"]);
                vpf.estado =  Convert.ToString(dsReporte.Rows[i]["estado"]);
                vpf.estatus =  Convert.ToString(dsReporte.Rows[i]["Estatus"]);
                vpf.fechaprocesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                vpf.descripcion =  Convert.ToString(dsReporte.Rows[i]["Descripcion"]);
                vpf.cedula_rif = Convert.ToString(dsReporte.Rows[i]["cedula_rif"]);
                vpf.fechaInicio = Pmts.fechaInicio;
                vpf.fechaFin = Pmts.fechaFin;
                vpf.Proc = Pmts.Proc;
                vpf.Pend = Pmts.Pend;
                vpf.Anul = Pmts.Anul;
                vpf.codOfiCoche = Pmts.codOfiCoche;
                vpf.codOfiCosta = Pmts.codOfiCosta;
                vpf.codOfiPlaya = Pmts.codOfiPlaya;
                vpf.codOfiIsla = Pmts.codOfiIsla;
                vpf.codOfiSala5 = Pmts.codOfiSala5;
                vpf.codOfiSala7 = Pmts.codOfiSala7;
                lista.Add(vpf);
                vpf = new VolProgFlyinn();
            }
            return lista;
        }




        #region LISTADOS DE REPORTES CONTRATOS PROCESABLES
        public List<Programas> ListarContratosProcesables2(Parametros Pmts)
        {
            // se tiene que instanciar los objetos nuevamente cuando se inserta un nuevo registro porque sino arroja un error. se debe hacer al inicio y final de cada condicion.

            List<Programas> programa = new List<Programas>(); // listado principal para agrupar los registros por programas 
            Programas datos = new Programas(); //objeto programa para llamar los datos que se van agregar en el listado programas. 
            datos.listContratos = new List<Contratos>(); // list de contratos para agregar los datos del contrato que pertenezcan aun grupo. 
            datos.contratos = new Contratos();

            List<Contratos> contratos = new List<Contratos>();
            Contratos contrato = new Contratos();
            contrato.Certificado = new Certificados();
            // contrato.Cliente = new Cliente();
            contrato.Comisiones = new Comisiones();
            contrato.Programa = new Programas();
            contrato.Promotor = new Empleado();
            contrato.CodPromotor = new Empleado();
            contrato.CodLiner = new Empleado();
            contrato.CodCloser = new Empleado();
            contrato.Comisiones.ComisionPromotor = 0.00f;
            contrato.Liner = new Empleado();
            contrato.Comisiones.ComisionLiner = 0.00f;
            contrato.Closer = new Empleado();
            contrato.Comisiones.ComisionCloser = 0.00f;
            contrato.Comisiones.TotalComisionP = 0.00f;
            contrato.Comisiones.TotalComisionL = 0.00f;
            contrato.Comisiones.TotalComisionC = 0.00f;

            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaInicio", Valor = Pmts.fechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pfechaFin", Valor = Pmts.fechaFin });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiCosta", Valor = Pmts.codOfiCosta });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiCoche", Valor = Pmts.codOfiCoche });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiPlaya", Valor = Pmts.codOfiPlaya });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiIsla", Valor = Pmts.codOfiIsla });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiSala", Valor = Pmts.codOfiSala });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiSala5", Valor = Pmts.codOfiSala5 });
            Parametros.Add(new Parameters { nameValue = "@pPPF", Valor = Pmts.PPF });
            Parametros.Add(new Parameters { nameValue = "@pPVB", Valor = Pmts.PVB });
            Parametros.Add(new Parameters { nameValue = "@pCodigoPrograma", Valor = Pmts.CodigoPrograma });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Contratos_Procesables", CommandType.StoredProcedure, Parametros);
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                if (i == 0)
                {
                    contrato.fechaInicio = Pmts.fechaInicio;
                    contrato.fechaFin = Pmts.fechaFin;

                    //--- Carga de parámetros para el reporte de closing (contratos procesables)------//
                    datos.fini = Pmts.fechaInicio;
                    datos.ffin = Pmts.fechaFin;
                    datos.codcoc = Pmts.codOfiCoche;
                    datos.codpla = Pmts.codOfiPlaya;
                    datos.codisl = Pmts.codOfiIsla;
                    datos.codcos = Pmts.codOfiCosta;
                    datos.codsal5 = Pmts.codOfiSala5;
                    datos.codsal7 = Pmts.codOfiSala;
                    datos.PPF = Pmts.PPF;
                    datos.PVB = Pmts.PVB;
                    datos.nombre_programa = Bitacora.nombre_programa(Pmts.CodigoPrograma);
                    //--------------------------------------------------------------------------------//
                    
                    datos.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                    Programa = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                    ind = 1;
                }
                if (ind == 0)
                {
                    datos.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                    Programa = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                    ind = 1;
                }
                //    string prueba = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]).Substring(0,5);

                if (Programa.Substring(0, 5) == Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]).Substring(0, 5) /*&& Programa.Substring(0, 5) == "CALLE"*/) // condicion solo para el programa calle ya que los nombres son diferentes pero se agrupan en un solo programa se utiliza el metodo substring para que la variable se le asigne calle y entre en la condicion
                {
                    contrato.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["FechaCreacion"]);
                    contrato.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                    contrato.NroContrato = Convert.ToString(dsReporte.Rows[i]["NroContrato"]);
                    contrato.MontoContrato = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["MontoContrato"]), 2));
                    contrato.Programa.CodigoPrograma = Convert.ToInt32(dsReporte.Rows[i]["CodigoPrograma"]);
                    contrato.Programa.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                    contrato.Indicador = Convert.ToInt32(dsReporte.Rows[i]["Indicador"]);

                    //contrato.CodPromotor.CodigoEmpleado = dsReporte.Rows[i]["CodPromotor"].ToString();

                    contrato.CodPromotor.CodigoEmpleado = Convert.ToString(dsReporte.Rows[i]["idPromotor"]);



                    //contrato.Promotor.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idPromotor"]);
                    contrato.Promotor.Nombres = Convert.ToString(dsReporte.Rows[i]["Promotor"]);
                    contrato.CodLiner.CodigoEmpleado = dsReporte.Rows[i]["codLiner"].ToString();
                    //contrato.Liner.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idLiner"]);
                    contrato.Liner.Nombres = Convert.ToString(dsReporte.Rows[i]["Liner"]);
                    contrato.CodCloser.CodigoEmpleado = dsReporte.Rows[i]["codCloser"].ToString();
                    //contrato.Closer.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idCloser"]);
                    contrato.Closer.Nombres = Convert.ToString(dsReporte.Rows[i]["Closer"]);

                    if (dsReporte.Rows[i]["ComisionPromotor"] != DBNull.Value)
                    {
                        contrato.Comisiones.ComisionPromotor = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionPromotor"]), 2));
                        contrato.Comisiones.TotalComisionP = contrato.Comisiones.TotalComisionP + Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionPromotor"]), 2));
                        
                    }
                    else
                    {
                        contrato.Comisiones.ComisionPromotor = 0.00f;
                        contrato.Comisiones.TotalComisionP = 0.00f;
                    }
                    if (dsReporte.Rows[i]["ComisionLiner"] != DBNull.Value)
                    {
                        contrato.Comisiones.ComisionLiner = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionLiner"]), 2));
                        contrato.Comisiones.TotalComisionL =contrato.Comisiones.TotalComisionL + Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionLiner"]), 2));
                    }
                    else
                    {
                        contrato.Comisiones.ComisionLiner = 0.00f;
                        contrato.Comisiones.TotalComisionL = 0.00f;
                    }
                    if (dsReporte.Rows[i]["ComisionCloser"] != DBNull.Value)
                    {
                        contrato.Comisiones.ComisionCloser = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionCloser"]), 2));
                        contrato.Comisiones.TotalComisionC = contrato.Comisiones.TotalComisionC + Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionCloser"]), 2));
                    }
                    else
                    {
                        contrato.Comisiones.ComisionCloser = 0.00f;
                        contrato.Comisiones.TotalComisionC = 0.00f;
                    }
                    datos.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]).Substring(0, 5);
                    datos.listContratos.Add(contrato);
                    contrato = new Contratos();
                    contrato.Programa = new Programas();
                    contrato.Comisiones = new Comisiones();
                    contrato.CodLiner = new Empleado();
                    contrato.CodCloser = new Empleado();
                    contrato.CodPromotor = new Empleado();
                    contrato.Promotor = new Empleado();
                    contrato.Comisiones.ComisionPromotor = 0.00f;
                    contrato.Liner = new Empleado();
                    contrato.Comisiones.ComisionLiner = 0.00f;
                    contrato.Closer = new Empleado();
                    contrato.Comisiones.ComisionCloser = 0.00f;
                    contrato.Comisiones.TotalComisionP = 0.00f;
                    contrato.Comisiones.TotalComisionL = 0.00f;
                    contrato.Comisiones.TotalComisionC = 0.00f;

                    //susana
                    //ind = 0;
                }
                else //if (datos.Descripcion.Substring(0, 5) == "CALLE") // solo se inserta el programa calle en la lista por no tener un nombre de calle unico se agrupa aparte.
                {
                    programa.Add(datos);
                    contrato = new Contratos();
                    datos = new Programas();
                    contrato.Programa = new Programas();
                    contrato.Comisiones = new Comisiones();
                    datos.listContratos = new List<Contratos>(); // list de contratos para agregar los datos del contrato que pertenezcan aun grupo.                    
                    contrato.CodPromotor = new Empleado();
                    contrato.CodLiner = new Empleado();
                    contrato.CodCloser = new Empleado();
                    contrato.Promotor = new Empleado();
                    contrato.Comisiones.ComisionPromotor = 0.00f;
                    contrato.Liner = new Empleado();
                    contrato.Comisiones.ComisionLiner = 0.00f;
                    contrato.Closer = new Empleado();
                    contrato.Comisiones.ComisionCloser = 0.00f;
                    contrato.Comisiones.TotalComisionP = 0.00f;
                    contrato.Comisiones.TotalComisionL = 0.00f;
                    contrato.Comisiones.TotalComisionC = 0.00f;


                    contrato.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["FechaCreacion"]);
                    contrato.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                    contrato.NroContrato = Convert.ToString(dsReporte.Rows[i]["NroContrato"]);
                    contrato.MontoContrato = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["MontoContrato"]), 2));
                    contrato.Programa.CodigoPrograma = Convert.ToInt32(dsReporte.Rows[i]["CodigoPrograma"]);
                    contrato.Programa.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                    contrato.Indicador = Convert.ToInt32(dsReporte.Rows[i]["Indicador"]);
                    contrato.CodPromotor.CodigoEmpleado = dsReporte.Rows[i]["CodPromotor"].ToString();

                    contrato.Promotor.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idPromotor"]);



                    contrato.Promotor.Nombres = Convert.ToString(dsReporte.Rows[i]["Promotor"]);
                    contrato.CodLiner.CodigoEmpleado = dsReporte.Rows[i]["codLiner"].ToString();
                    //contrato.Liner.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idLiner"]);
                    contrato.Liner.Nombres = Convert.ToString(dsReporte.Rows[i]["Liner"]);
                    contrato.CodCloser.CodigoEmpleado = dsReporte.Rows[i]["codCloser"].ToString();
                    //contrato.Closer.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idCloser"]);
                    contrato.Closer.Nombres = Convert.ToString(dsReporte.Rows[i]["Closer"]);

                    if (dsReporte.Rows[i]["ComisionPromotor"] != DBNull.Value)
                    {
                        contrato.Comisiones.ComisionPromotor = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionPromotor"]), 2));
                        contrato.Comisiones.TotalComisionP = contrato.Comisiones.TotalComisionP + Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionPromotor"]), 2));

                    }
                    else
                    {
                        contrato.Comisiones.ComisionPromotor = 0.00f;
                        contrato.Comisiones.TotalComisionP = 0.00f;
                    }
                    if (dsReporte.Rows[i]["ComisionLiner"] != DBNull.Value)
                    {
                        contrato.Comisiones.ComisionLiner = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionLiner"]), 2));
                        contrato.Comisiones.TotalComisionL = contrato.Comisiones.TotalComisionL + Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionLiner"]), 2));
                    }
                    else
                    {
                        contrato.Comisiones.ComisionLiner = 0.00f;
                        contrato.Comisiones.TotalComisionL = 0.00f;
                    }
                    if (dsReporte.Rows[i]["ComisionCloser"] != DBNull.Value)
                    {
                        contrato.Comisiones.ComisionCloser = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionCloser"]), 2));
                        contrato.Comisiones.TotalComisionC = contrato.Comisiones.TotalComisionC + Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionCloser"]), 2));
                    }
                    else
                    {
                        contrato.Comisiones.ComisionCloser = 0.00f;
                        contrato.Comisiones.TotalComisionC = 0.00f;
                    }
                    datos.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]).Substring(0, 5);
                    datos.listContratos.Add(contrato);
                    contrato = new Contratos();
                    contrato.Programa = new Programas();
                    contrato.Comisiones = new Comisiones();
                    contrato.CodLiner = new Empleado();
                    contrato.CodCloser = new Empleado();
                    contrato.CodPromotor = new Empleado();
                    contrato.Promotor = new Empleado();
                    contrato.Comisiones.ComisionPromotor = 0.00f;
                    contrato.Liner = new Empleado();
                    contrato.Comisiones.ComisionLiner = 0.00f;
                    contrato.Closer = new Empleado();
                    contrato.Comisiones.ComisionCloser = 0.00f;
                    contrato.Comisiones.TotalComisionP = 0.00f;
                    contrato.Comisiones.TotalComisionL = 0.00f;
                    contrato.Comisiones.TotalComisionC = 0.00f;

                    Programa = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                }
               /* if (Programa == dsReporte.Rows[i]["DescripcionPrograma"].ToString() && Programa.Substring(0, 5) != "CALLE")// condicion para insertar en la lista. los demas programas menos el de calle 
                {
                    datos.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                    contrato.FechaCreacion = Convert.ToDateTime(dsReporte.Rows[i]["FechaCreacion"]);
                    contrato.FechaProcesable = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                    contrato.NroContrato = Convert.ToString(dsReporte.Rows[i]["NroContrato"]);
                    contrato.MontoContrato = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["MontoContrato"]), 2));
                    contrato.Programa.CodigoPrograma = Convert.ToInt32(dsReporte.Rows[i]["CodigoPrograma"]);
                    contrato.Programa.Descripcion = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                    contrato.Indicador = Convert.ToInt32(dsReporte.Rows[i]["Indicador"]);
                    contrato.CodPromotor.CodigoEmpleado = dsReporte.Rows[i]["CodPromotor"].ToString();
                    contrato.Promotor.idEmpleado =dsReporte.Rows[i]["idPromotor"]!=DBNull.Value? Convert.ToInt32(dsReporte.Rows[i]["idPromotor"]):0;
                    contrato.Promotor.Nombres =dsReporte.Rows[i]["Promotor"]!=DBNull.Value? Convert.ToString(dsReporte.Rows[i]["Promotor"]):"";
                    contrato.CodLiner.CodigoEmpleado = dsReporte.Rows[i]["codLiner"].ToString();
                    contrato.Liner.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idLiner"]);
                    contrato.Liner.Nombres = Convert.ToString(dsReporte.Rows[i]["Liner"]);
                    contrato.CodCloser.CodigoEmpleado = dsReporte.Rows[i]["codCloser"].ToString();
                    contrato.Closer.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idCloser"]);
                    contrato.Closer.Nombres = Convert.ToString(dsReporte.Rows[i]["Closer"]);

                    if (dsReporte.Rows[i]["ComisionPromotor"] != DBNull.Value)
                    {
                        contrato.Comisiones.ComisionPromotor = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionPromotor"]), 2));
                        contrato.Comisiones.TotalComisionP = contrato.Comisiones.TotalComisionP + Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionPromotor"]), 2));
                    }
                    else
                    {
                        contrato.Comisiones.ComisionPromotor = 0.00f;
                        contrato.Comisiones.TotalComisionP = 0.00f;
                    }
                    if (dsReporte.Rows[i]["ComisionLiner"] != DBNull.Value)
                    {
                        contrato.Comisiones.ComisionLiner = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionLiner"]), 2));
                        contrato.Comisiones.TotalComisionL = contrato.Comisiones.TotalComisionL + Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionLiner"]), 2));
                    }
                    else
                    {
                        contrato.Comisiones.ComisionLiner = 0.00f;
                        contrato.Comisiones.TotalComisionL = 0.00f;
                    }
                    if (dsReporte.Rows[i]["ComisionCloser"] != DBNull.Value)
                    {
                        contrato.Comisiones.ComisionCloser = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionCloser"]), 2));
                        contrato.Comisiones.TotalComisionC = contrato.Comisiones.TotalComisionC + Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionCloser"]), 2));
                    }
                    else
                    {
                        contrato.Comisiones.ComisionCloser = 0.00f;
                        contrato.Comisiones.TotalComisionC = 0.00f;
                    }
                    datos.listContratos.Add(contrato);
                    contrato = new Contratos();
                    contrato.Programa = new Programas();
                    contrato.Comisiones = new Comisiones();
                    contrato.CodLiner = new Empleado();
                    contrato.CodCloser = new Empleado();
                    contrato.CodPromotor = new Empleado();
                    contrato.Promotor = new Empleado();
                    contrato.Comisiones.ComisionPromotor = 0.00f;
                    contrato.Liner = new Empleado();
                    contrato.Comisiones.ComisionLiner = 0.00f;
                    contrato.Closer = new Empleado();
                    contrato.Comisiones.ComisionCloser = 0.00f;
                    contrato.Comisiones.TotalComisionP = 0.00f;
                    contrato.Comisiones.TotalComisionL = 0.00f;
                    contrato.Comisiones.TotalComisionC = 0.00f;
                    //susana
                   // ind = 0;
                }

                else if (Programa != dsReporte.Rows[i]["DescripcionPrograma"].ToString() && Programa.Substring(0, 5) != "CALLE") // se insertan todo los registrso por programa menos calle que se inserta en la primera condicion.
                {
                    programa.Add(datos);
                    ind = 0;

                    //contratos.Add(contrato);
                    contrato = new Contratos();
                    datos = new Programas();
                    datos.listContratos = new List<Contratos>(); // list de contratos para agregar los datos del contrato que pertenezcan aun grupo. 
                    // contrato.Certificado = new Certificados();
                    //  contrato.Cliente = new Cliente();
                    // Programas datos = new Programas(); //objeto programa para llamar los datos que se van agregar en el listado programas. 

                    //  datos.contratos = new Contratos();

                    contrato.Comisiones = new Comisiones();
                    contrato.Programa = new Programas();
                    contrato.Promotor = new Empleado();
                    contrato.CodPromotor = new Empleado();
                    contrato.CodLiner = new Empleado();
                    contrato.CodCloser = new Empleado();
                    contrato.Comisiones.ComisionPromotor = 0.00f;
                    contrato.Liner = new Empleado();
                    contrato.Comisiones.ComisionLiner = 0.00f;
                    contrato.Closer = new Empleado();
                    contrato.Comisiones.ComisionCloser = 0.00f;
                    contrato.Comisiones.TotalComisionP = 0.00f;
                    contrato.Comisiones.TotalComisionL = 0.00f;
                    contrato.Comisiones.TotalComisionC = 0.00f;
                    Programa = Convert.ToString(dsReporte.Rows[i]["DescripcionPrograma"]);
                }*/
                if (i == dsReporte.Rows.Count - 1 && Programa == dsReporte.Rows[i]["DescripcionPrograma"].ToString())// esta condicion solo aplica al ultimo registro de la tabla 
                {
                    programa.Add(datos);
                    ind = 0;

                    //contratos.Add(contrato);
                    contrato = new Contratos();
                    datos = new Programas();
                    datos.listContratos = new List<Contratos>(); // list de contratos para agregar los datos del contrato que pertenezcan aun grupo. 
                    // contrato.Certificado = new Certificados();
                    //  contrato.Cliente = new Cliente();
                    // Programas datos = new Programas(); //objeto programa para llamar los datos que se van agregar en el listado programas. 

                    //  datos.contratos = new Contratos();

                    contrato.Comisiones = new Comisiones();
                    contrato.Programa = new Programas();
                    contrato.Promotor = new Empleado();
                    contrato.CodPromotor = new Empleado();
                    contrato.CodLiner = new Empleado();
                    contrato.CodCloser = new Empleado();
                    contrato.Comisiones.ComisionPromotor = 0.00f;
                    contrato.Liner = new Empleado();
                    contrato.Comisiones.ComisionLiner = 0.00f;
                    contrato.Closer = new Empleado();
                    contrato.Comisiones.ComisionCloser = 0.00f;
                    contrato.Comisiones.TotalComisionP = 0.00f;
                    contrato.Comisiones.TotalComisionL = 0.00f;
                    contrato.Comisiones.TotalComisionC = 0.00f;
                }



            }
            return programa;
        }

        #region PARA GUARDAR BITÁCORA

        
        

        


        #endregion



        //generar comision
        public List<Programas> generarComision(Parametros Pmts)
        {
            // se tiene que instanciar los objetos nuevamente cuando se inserta un nuevo registro porque sino arroja un error. se debe hacer al inicio y final de cada condicion.

            List<Programas> programa = new List<Programas>(); // listado principal para agrupar los registros por programas 
            Programas datos = new Programas(); //objeto programa para llamar los datos que se van agregar en el listado programas. 
            datos.listContratos = new List<Contratos>(); // list de contratos para agregar los datos del contrato que pertenezcan aun grupo. 
            datos.contratos = new Contratos();

            List<Contratos> contratos = new List<Contratos>();
            Contratos contrato = new Contratos();
            contrato.Certificado = new Certificados();
            // contrato.Cliente = new Cliente();
            contrato.Comisiones = new Comisiones();
            contrato.Programa = new Programas();
            contrato.Promotor = new Empleado();
            contrato.CodPromotor = new Empleado();
            contrato.CodLiner = new Empleado();
            contrato.CodCloser = new Empleado();
            contrato.Comisiones.ComisionPromotor = 0.00f;
            contrato.Liner = new Empleado();
            contrato.Comisiones.ComisionLiner = 0.00f;
            contrato.Closer = new Empleado();
            contrato.Comisiones.ComisionCloser = 0.00f;
            contrato.Comisiones.TotalComisionP = 0.00f;
            contrato.Comisiones.TotalComisionL = 0.00f;
            contrato.Comisiones.TotalComisionC = 0.00f;

            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pfechaInicio", Valor = Pmts.fechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pfechaFin", Valor = Pmts.fechaFin });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiCosta", Valor = Pmts.codOfiCosta });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiCoche", Valor = Pmts.codOfiCoche });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiPlaya", Valor = Pmts.codOfiPlaya });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiIsla", Valor = Pmts.codOfiIsla });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiSala", Valor = Pmts.codOfiSala });
            Parametros.Add(new Parameters { nameValue = "@pcodOfiSala5", Valor = Pmts.codOfiSala5 });
            Parametros.Add(new Parameters { nameValue = "@pPPF", Valor = Pmts.PPF });
            Parametros.Add(new Parameters { nameValue = "@pPVB", Valor = Pmts.PVB });
            Parametros.Add(new Parameters { nameValue = "@pCodigoPrograma", Valor = Pmts.CodigoPrograma });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_ins_comision_Procesables", CommandType.StoredProcedure, Parametros);
            
            //-----------Bitácora --------------------------//
            Bitacora Bit = new Bitacora(3, 4, Pmts.usr, Pmts.host);
            Bit.Descripcion = Bit.desc_repclo_gen_comi(Pmts);
            Bit.ejecutar_bitacora();
            //----------------------------------------------//


            return programa;
        }
        #endregion

        #region LISTAR USUARIOS
        public List<Usuarios> ListarUsuarios()
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Usuarios", CommandType.StoredProcedure, new List<Parameters>());
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                Usuarios usuario= new Usuarios();
                usuario.Codigo = Convert.ToInt32(dsReporte.Rows[i]["Codigo"]);
                usuario.nbUsuario=dsReporte.Rows[i]["Login"].ToString();
                usuario.nombreUser=dsReporte.Rows[i]["Nombres"].ToString();
                usuario.apeUser=dsReporte.Rows[i]["Apellidos"].ToString();
                usuario.correo = dsReporte.Rows[i]["Email"].ToString() == "NO POSEE" ? " " : dsReporte.Rows[i]["Email"].ToString();
                usuario.nbPerfil=dsReporte.Rows[i]["nbPerfil"].ToString();              
                usuario.activo=Convert.ToInt32(dsReporte.Rows[i]["Activo"]);
                usuario.Perfil = Convert.ToInt32(dsReporte.Rows[i]["CodigoPerfil"]);
                usuario.Cedula=Convert.ToInt32(dsReporte.Rows[i]["Cedula"]);
                usuario.contraseña = dsReporte.Rows[i]["Clave"].ToString();
                usuario.Estado = dsReporte.Rows[i]["Estado"].ToString();
                usuarios.Add(usuario);
            }
            return usuarios;
        }
        #endregion

        #region LISTAR EMPLEADOS
        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> Empleados = new List<Empleado>();
            Empleado empleado = new Empleado();
            empleado.Cargo = new Cargo();
            empleado.Programa = new Programas();
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_ListarEmpleados", CommandType.StoredProcedure, new List<Parameters>());
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
               // Empleado empleado = new Empleado();
                empleado.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["ID"]);
                empleado.CodigoEmpleado = dsReporte.Rows[i]["CODIGO"].ToString();               
                empleado.Nombres = dsReporte.Rows[i]["NOMBRE"].ToString();
                empleado.Cedula = dsReporte.Rows[i]["CEDULA_RIF"].ToString();
                empleado.Cargo.Descripcion = dsReporte.Rows[i]["Cargo"].ToString();
                empleado.Cargo.CodigoCargo =Convert.ToInt32(dsReporte.Rows[i]["CodigoCargo"]);
                empleado.Programa.Descripcion = dsReporte.Rows[i]["Programa"].ToString();
                empleado.Programa.CodigoPrograma = Convert.ToInt32(dsReporte.Rows[i]["CodigoPrograma"]);
                empleado.Email = dsReporte.Rows[i]["Email"].ToString() =="NO POSEE" ? " " : dsReporte.Rows[i]["Email"].ToString();
                empleado.Estado = dsReporte.Rows[i]["Estado"].ToString();
                empleado.activo = Convert.ToInt32(dsReporte.Rows[i]["Activo"]);
                Empleados.Add(empleado);
                empleado = new Empleado();
                empleado.Cargo = new Cargo();
                empleado.Programa = new Programas();
            }
            return Empleados;
        }
        #endregion

        #region LISTAR CERTIFICADOS
        public List<Certificados> ListaCertificados(DateTime fechaInicio ,DateTime fechaFin)
        {       
            
       
            List<Parameters> Parametros = new List<Parameters>();
            List<Certificados> Certificados = new List<Certificados>();
            Certificados Certificado = new Certificados(); 
            Certificado.Sucursal = new Sucursal(); 
            Certificado.Promotor = new Empleado();          
            Certificado.Gerente = new Empleado();           
            Certificado.Supervisor = new Empleado();
            Certificado.Liner = new Empleado();
            Certificado.Closer = new Empleado();
            
            
            fechaInicio = fechaInicio == Convert.ToDateTime("01/01/0001 0:00:00") ? Convert.ToDateTime("01/01/1900") : fechaInicio;
            fechaFin = fechaFin == Convert.ToDateTime("01/01/0001 0:00:00") ? Convert.ToDateTime("01/01/1900") : fechaFin;

            /*
            fechaInicio = Convert.ToDateTime(Convert.ToString(DateTime.Now.Year) + "-01-01");
            fechaFin = DateTime.Now;*/
           
            Parametros.Add(new Parameters { nameValue = "@pfechaInicio", Valor = fechaInicio.ToShortDateString() });
            Parametros.Add(new Parameters { nameValue = "@pfechaFin", Valor = fechaFin.ToShortDateString() });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_ListadoCertificados", CommandType.StoredProcedure, Parametros);

            
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                Certificado.CodigoCertificado =Convert.ToString(dsReporte.Rows[i]["codCertificado"]);
                Certificado.Fecha = Convert.ToDateTime(dsReporte.Rows[i]["fechaVenta"]);
                Certificado.dia = Convert.ToString(Certificado.Fecha.Day); // se divide la fecha en dia mes y año y se asignan a variables para poder cargarlas en el input datapicker
                Certificado.mes = Convert.ToString(Certificado.Fecha.Month);
                Certificado.ano = Convert.ToString(Certificado.Fecha.Year);
                Certificado.nbCliente = Convert.ToString(dsReporte.Rows[i]["nbCliente"]);
                Certificado.cedulaCliente = dsReporte.Rows[i]["cedulaCliente"] != DBNull.Value ? Convert.ToString(dsReporte.Rows[i]["cedulaCliente"]) : "";
                Certificado.nbAcompañante =dsReporte.Rows[i]["nbAcompañante"]!=DBNull.Value? Convert.ToString(dsReporte.Rows[i]["nbAcompañante"]):"";
                Certificado.cedulaAc = dsReporte.Rows[i]["cedulaAc"] != DBNull.Value ? Convert.ToString(dsReporte.Rows[i]["cedulaAc"]) : "";
                Certificado.Sucursal.idSucursal = Convert.ToInt32(dsReporte.Rows[i]["idSucursal"]);
                Certificado.Sucursal.nbSucursal = Convert.ToString(dsReporte.Rows[i]["nbSucursal"]);
                Certificado.Liner.Nombres = dsReporte.Rows[i]["Liner"] !=DBNull.Value? Convert.ToString(dsReporte.Rows[i]["Liner"]):"";
                Certificado.Closer.Nombres = dsReporte.Rows[i]["Closer"] !=DBNull.Value? Convert.ToString(dsReporte.Rows[i]["Closer"]):"";
                if (Convert.ToString(dsReporte.Rows[i]["idPromotor"]) != "" && dsReporte.Rows[i]["idPromotor"] != null && Convert.ToInt32(dsReporte.Rows[i]["idPromotor"]) != -1)
                {
                    Certificado.Promotor.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idPromotor"]);
                    Certificado.Promotor.Nombres = Convert.ToString(dsReporte.Rows[i]["Promotor"]);                   
                }
                if (Convert.ToString(dsReporte.Rows[i]["idSupervisor"]) != "" && dsReporte.Rows[i]["idSupervisor"] != null && Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]) != -1)
                {
                    Certificado.Supervisor.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idSupervisor"]);
                    Certificado.Supervisor.Nombres = Convert.ToString(dsReporte.Rows[i]["Supervisor"]);                    
                }
                if (Convert.ToString(dsReporte.Rows[i]["idGerente"]) != "" && dsReporte.Rows[i]["idGerente"] != null && Convert.ToInt32(dsReporte.Rows[i]["idGerente"]) != -1)
                {
                    Certificado.Gerente.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["idGerente"]);
                    Certificado.Gerente.Nombres = Convert.ToString(dsReporte.Rows[i]["Gerente"]);
                }
               
                Certificado.NroNoches = Convert.ToInt32(dsReporte.Rows[i]["nroNoches"]);
                Certificado.NroAdultos = Convert.ToInt32(dsReporte.Rows[i]["nroAdultos"]);
                Certificado.NroNiños = Convert.ToInt32(dsReporte.Rows[i]["nroNiños"]);
                Certificado.Observaciones = Convert.ToString(dsReporte.Rows[i]["observaciones"]);


                if (dsReporte.Rows[i]["FechaReserva"] != DBNull.Value)
                {

                    Certificado.fReserva = Convert.ToString(dsReporte.Rows[i]["FechaReserva"]);
                    Certificado.fReserva = Certificado.fReserva.Replace("12:00:00 a.m.", "");
                    Certificado.fechaReserva = Convert.ToDateTime(dsReporte.Rows[i]["FechaReserva"]);

                }
                else {

                    Certificado.fReserva = "";
                }

                if (dsReporte.Rows[i]["FechaViajeCliente"] != DBNull.Value)
                {

                    Certificado.fViajeCliente = Convert.ToString(dsReporte.Rows[i]["FechaViajeCliente"]);
                    Certificado.fViajeCliente = Certificado.fViajeCliente.Replace("12:00:00 a.m.", "");
                    Certificado.fechaViajeCliente = Convert.ToDateTime(dsReporte.Rows[i]["FechaViajeCliente"]);

                }
                else
                {

                    Certificado.fViajeCliente = "";
                }


                //Certificado.fReserva = dsReporte.Rows[i]["FechaReserva"] != DBNull.Value ? Convert.ToString(dsReporte.Rows[i]["FechaReserva"]) : "";

                //Certificado.fReserva = Certificado.fReserva.Replace("12:00:00 a.m.", "");

                //Certificado.fechaReserva = Convert.ToDateTime(dsReporte.Rows[i]["FechaReserva"]);

                //Certificado.fViajeCliente = dsReporte.Rows[i]["FechaViajeCliente"] != DBNull.Value ? Convert.ToString(dsReporte.Rows[i]["FechaViajeCliente"]) : "";

                //Certificado.fViajeCliente = Certificado.fViajeCliente.Replace("12:00:00 a.m.", "");

                //Certificado.fechaViajeCliente = Convert.ToDateTime(dsReporte.Rows[i]["FechaViajeCliente"]);
                if (Convert.ToString(dsReporte.Rows[i]["montoCertificado"]) != "")
                {
                    Certificado.montoCertificado = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["montoCertificado"]), 2));
                }
                else
                {
                    Certificado.montoCertificado = 0.00f;
                }
                if (Convert.ToString(dsReporte.Rows[i]["TotalPago"])!="")
                {
                    Certificado.MontoPagar = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["TotalPago"]), 2));
                }
                else
                {
                    Certificado.MontoPagar = 0.00f;
                }
                

                Certificados.Add(Certificado);  
                Certificado = new Certificados(); 
                Certificado.Sucursal = new Sucursal(); 
                Certificado.Promotor = new Empleado();          
                Certificado.Gerente = new Empleado();           
                Certificado.Supervisor = new Empleado();
                Certificado.Liner = new Empleado();
                Certificado.Closer = new Empleado();

            }
            return Certificados;
        }
        #endregion

        #region CARGAR PROGRAMAS
        public List<Programas> CargarProgramas()
        {
            List<Programas> Programas = new List<Programas>();
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Programas", CommandType.Text, new List<Parameters>());

            for (int i = -1; i < dsReporte.Rows.Count; i++)
            {
                Programas Programa = new Programas();
                if (i == -1)
                {                   
                    Programa.idPrograma = -1;
                    Programa.Descripcion = "<...>";
                    Programa.Estado = -1;
                    Programa.CodigoPrograma = -1;
                    Programa.CodigoAnterior = "<...>";
                }
                else
                {                    
                    Programa.idPrograma = Convert.ToInt32(dsReporte.Rows[i]["Codigo"]);
                    Programa.Descripcion = Convert.ToString(dsReporte.Rows[i]["Descripcion"]);
                    Programa.Estado = Convert.ToInt32(dsReporte.Rows[i]["Estado"]);
                    Programa.CodigoPrograma = Convert.ToInt32(dsReporte.Rows[i]["Codigo"]);
                    Programa.CodigoAnterior = Convert.ToString(dsReporte.Rows[i]["CodigoAnterior"]);
                }

                Programas.Add(Programa);
            }
            return Programas;
        }
        #endregion

        #region CARGAR CERTIFICADOS

        
        public List<Certificados> CargarCertificados()
        {
            List<Certificados> Certificados = new List<Certificados>();
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_codigoCertificado", CommandType.Text, new List<Parameters>());
            

            for (int i = -1; i < dsReporte.Rows.Count; i++)
            {
                Certificados Certificado = new Certificados();
                if (i == -1)
                {
                    Certificado.idCertificado = -1;
                    Certificado.CodigoCertificado = "<...>";                   
                }
                else
                {
                    Certificado.idCertificado = Convert.ToInt32(dsReporte.Rows[i]["idCertificado"]);
                    Certificado.CodigoCertificado = Convert.ToString(dsReporte.Rows[i]["codCertificado"]);                
                }

                Certificados.Add(Certificado);
            }
            return Certificados;
        }
        #endregion

        #region CARGAR EMPLEADOS
        public List<Empleado> CargarEmpleados(int Tipo)
        {
            List<Empleado> Empleados = new List<Empleado>();            
            
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pTipo", Valor = Tipo });
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Empleados", CommandType.StoredProcedure, Parametros);
            
            for (int i = -1; i < dsReporte.Rows.Count; i++)
            {
                Empleado Empleado = new Empleado();
                Empleado.Cargo = new Cargo();
                if (i == -1)
                {
                    Empleado.idEmpleado = -1;
                    Empleado.Nombres = "<...>";
                    Empleado.Cedula = "";
                    Empleado.Cargo.CodigoCargo = 0;
                    Empleado.Cargo.Descripcion = "";                   
                }
                else
                {
                    Empleado.idEmpleado = Convert.ToInt32(dsReporte.Rows[i]["ID"]);
                    Empleado.Nombres = Convert.ToString(dsReporte.Rows[i]["NOMBRE"]);
                    Empleado.Cedula = Convert.ToString(dsReporte.Rows[i]["CEDULA_RIF"]); ;
                    Empleado.Cargo.CodigoCargo = Convert.ToInt32(dsReporte.Rows[i]["CodigoCargo"]);
                    Empleado.Cargo.Descripcion = Convert.ToString(dsReporte.Rows[i]["Descripcion"]);                   
                }

                Empleados.Add(Empleado);
            }
            return Empleados;
        }
        #endregion

        #region CARGAR ESTATUS
        public List<Estatus> CargarEstatus()
        {
            List<Estatus> Estatus = new List<Estatus>();
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Estatus", CommandType.Text, new List<Parameters>());

            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                Estatus Estatu = new Estatus();
                if (i == -1)
                {
                    Estatu.idEstatus = -1;
                    Estatu.nbEstatus = "<...>";                   
                }
                else
                {
                    Estatu.idEstatus = Convert.ToInt32(dsReporte.Rows[i]["idEstatus"]);
                    Estatu.nbEstatus = Convert.ToString(dsReporte.Rows[i]["nbEstatus"]);                    
                }

                Estatus.Add(Estatu);
            }
            return Estatus;
        }
        #endregion
      
        #region CARGAR SUCURSAL
        public List<Sucursal> CargarSucursal()
        {
            List<Sucursal> Sucursales = new List<Sucursal>();
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Sucursal", CommandType.Text, new List<Parameters>());
            
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                Sucursal Sucursal = new Sucursal();
                if (i == -1)
                {
                    Sucursal.idSucursal = -1;
                    Sucursal.nbSucursal = "<...>";                   
                }
                else
                {
                    Sucursal.idSucursal = Convert.ToInt32(dsReporte.Rows[i]["idSucursal"]);
                    Sucursal.nbSucursal = Convert.ToString(dsReporte.Rows[i]["nbSucursal"]);                    
                }

                Sucursales.Add(Sucursal);
            }
            return Sucursales;
        }
        #endregion

        #region CARGAR PERFIL
        public List<Perfil> CargarPerfil()
        {
            List<Perfil> Perfiles = new List<Perfil>();
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Perfil", CommandType.Text, new List<Parameters>());

            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                Perfil perfil = new Perfil();
                if (i == -1)
                {
                   perfil.Codigo = -1;
                    perfil.Nombre = "<...>";
                }
                else
                {
                    perfil.Codigo = Convert.ToInt32(dsReporte.Rows[i]["Codigo"]);
                    perfil.Nombre = Convert.ToString(dsReporte.Rows[i]["Nombre"]);

                }


                    Perfiles.Add(perfil);
            }
            return Perfiles;
        }
        #endregion

        #region CARGAR CARGOS
        public List<Cargo> CargarCargos()
        {
            List<Cargo> Cargos = new List<Cargo>();
            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Cargos", CommandType.Text, new List<Parameters>());

            for (int i = -1; i < dsReporte.Rows.Count; i++)
            {
                Cargo cargo = new Cargo();
               
                if (i == -1)
                {
                    cargo.CodigoCargo = -1;
                    cargo.Descripcion = "<...>";
                    
                }
                else
                {
                    cargo.CodigoCargo = Convert.ToInt32(dsReporte.Rows[i]["Codigo"]);
                    cargo.Descripcion = Convert.ToString(dsReporte.Rows[i]["Descripcion"]);

                }
               

                Cargos.Add(cargo);
            }
            return Cargos;
        }
        #endregion

        #region MODULO CONFIGURACION CARGAR CODIGO EMPLEADO
        public void CargarCodigoEmpleado()
        {
            var dsEmpleados = new DataTable();
           // Configuracion configuracion = new Configuracion();
            //metodo para cargar los codigos de los empleados segun su cargo se obtiene de la tabla configuraciones_flyinn..
            
            dsEmpleados = Conexion.GeneralConexion("Conexion", "sp_mos_empleadosflyinn_configuracion", CommandType.Text, new List<Parameters>());
                           
                Configuracion.sinPromotor = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "SIN PROMOTOR" + "'")[0]["valorParametro"]);                
                Configuracion.sinSupervisor = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "SIN SUPERVISOR" + "'")[0]["valorParametro"]);
                Configuracion.sinGerente = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "SIN GERENTE" + "'")[0]["valorParametro"]);
                Configuracion.sinCoordinador = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "SIN COORDINADOR" + "'")[0]["valorParametro"]);
                Configuracion.liners = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "LINERS" + "'")[0]["valorParametro"]);
                Configuracion.closer = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "CLOSERS" + "'")[0]["valorParametro"]);
                Configuracion.promotor = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "PROMOTORES" + "'")[0]["valorParametro"]);
                Configuracion.supervisor = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "SUPERVISORES" + "'")[0]["valorParametro"]);
                Configuracion.coordinador = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "COORDINADORES" + "'")[0]["valorParametro"]);
                Configuracion.gerente = Convert.ToInt32(dsEmpleados.Select("nbParametro='" + "GERENTES" + "'")[0]["valorParametro"]);


        }
        #endregion

        #region LISTADO COMPLEMENTOS

        public void insertarComplementos(string pNroContrato, DateTime pFecha, double pMontoContrato, double pPorcentaje,string usr, string host)
        {
           
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pNroContrato", Valor = pNroContrato });
            Parametros.Add(new Parameters { nameValue = "@pFecha", Valor = pFecha });
            Parametros.Add(new Parameters { nameValue = "@pMontoContrato", Valor = pMontoContrato });
            Parametros.Add(new Parameters { nameValue = "@pPorcentaje", Valor = pMontoContrato });
            Conexion.GeneralConexion("Conexion", "sp_ins_complementos_flyinn", CommandType.StoredProcedure, Parametros);
            

            //----------------------------------- Bitácora -------------------------------------//
            Bitacora Bit = new Bitacora(5,1,usr,host);
            Bit.Descripcion = Bit.desc_comp_ins(pNroContrato, pFecha, pMontoContrato, pPorcentaje);
            Bit.ejecutar_bitacora();
            //----------------------------------------------------------------------------------//


        }
        public List<Complementos> ListaComplementos(DateTime FechaInicio,DateTime FechaFin)
        {
            var dsReporte = new DataTable();
            List<Complementos> Complementos = new List<Complementos>();
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pFechaIni", Valor = FechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pFechaFin", Valor = FechaFin });

            dsReporte = Conexion.GeneralConexion("Conexion", "sp_mos_Complementos_Flyinn", CommandType.StoredProcedure, Parametros);
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                Complementos complemento = new Complementos();
                complemento.Fecha = Convert.ToDateTime(dsReporte.Rows[i]["FechaCreacion"]);
                complemento.NroContrato = dsReporte.Rows[i]["Documento"].ToString();
                complemento.MontoContrato = Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["MontoContrato"]), 2));
                complemento.PorcPromotor = dsReporte.Rows[i]["PorcPromotor"]!=DBNull.Value ? Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["PorcPromotor"]), 2)):0.00f;
                complemento.PorcSupervisor = dsReporte.Rows[i]["PorcSupervisor"] != DBNull.Value ? Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["PorcSupervisor"]), 2)) : 0.00f;
                complemento.PorcCoordinador = dsReporte.Rows[i]["PorcCoordinador"] != DBNull.Value ? Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["PorcCoordinador"]), 2)) : 0.00f;
                complemento.PorcGerente = dsReporte.Rows[i]["PorcGerente"] != DBNull.Value ? Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["PorcGerente"]), 2)) : 0.00f;
                Complementos.Add(complemento);
            }
            return Complementos;
        }
        public List<Complementos> ReporteComplementos(DateTime FechaInicio, DateTime FechaFin)
        {
            var dsReporte = new DataTable();
            List<Complementos> Complementos = new List<Complementos>();
            List<Parameters> Parametros = new List<Parameters>();
            Parametros.Add(new Parameters { nameValue = "@pFechaIni", Valor = FechaInicio });
            Parametros.Add(new Parameters { nameValue = "@pFechaFin", Valor = FechaFin });

            dsReporte = Conexion.GeneralConexion("Conexion", "sp_Reporte_Complementos", CommandType.StoredProcedure, Parametros);
            for (int i = 0; i < dsReporte.Rows.Count; i++)
            {
                Complementos complemento = new Complementos();
                complemento.Fecha = Convert.ToDateTime(dsReporte.Rows[i]["FechaProcesable"]);
                complemento.FechaInicio = FechaInicio;
                complemento.FechaFin = FechaFin;
                complemento.NroContrato = dsReporte.Rows[i]["NroContrato"].ToString();
                complemento.MontoContrato = 0;
                complemento.PorcPromotor = 0;
                complemento.PorcSupervisor = 0;
                complemento.comisionCoordinador = dsReporte.Rows[i]["ComisionCoordinador"] != DBNull.Value ? Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["ComisionCoordinador"]), 2)) : 0.00f;
                complemento.PorcCoordinador = dsReporte.Rows[i]["PorcCoordinador"] != DBNull.Value ? Convert.ToSingle(Math.Round(Convert.ToDecimal(dsReporte.Rows[i]["PorcCoordinador"]), 2)) : 0.00f;
                complemento.PorcGerente = 0;
                Complementos.Add(complemento);
            }
            return Complementos;
        }

        #endregion







    }
}