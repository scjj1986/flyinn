using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Librerias
{
    public class ConexionBaseDatos
    {
        public DataTable GeneralConexion(string NameConnection, string SintaxSQL, CommandType TypeMethod, List<Parameters> Parametros)
        {
            DataTable dtFinal = new DataTable();
        //    try
        //    {
            
                //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[NameConnection].ConnectionString.ToString()))
              //using (SqlConnection connection = new SqlConnection("Data Source=SUNSOLCARSQL03;Initial Catalog=CONTRATOS_PRU;User ID=contratos_reservas;Password=c0ntratos2016**"))
                using (SqlConnection connection = new SqlConnection("Data Source=SUNSOLCARSQL04;Initial Catalog=CONTRATOS;User ID=contratos2;Password=123456"))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandType = TypeMethod;
                        command.CommandText = SintaxSQL;
                        command.CommandTimeout = 120;
                        foreach (Parameters Param in Parametros)
                        {
                            command.Parameters.AddWithValue(Param.nameValue, Param.Valor);
                        }
                        dtFinal.Load(command.ExecuteReader());
                        connection.Close();
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ocurrio Un Error Al Procesar los Datos (" + ex.Message + ")");
            //}
            return dtFinal;
        }

        public DataTable ConexionNominaProfit(string NameConnection, string SintaxSQL, CommandType TypeMethod, List<Parameters> Parametros)
        {
            DataTable dtFinal = new DataTable();
            //    try
            //    {
            //Console.WriteLine(ConfigurationManager.ConnectionStrings[NameConnection].ConnectionString.ToString());
            using (SqlConnection connection = new SqlConnection("Data Source=SUNSOLCARSQL10;Initial Catalog=SSVC_N;User ID=profit;Password=profit"))
            {
                using (SqlCommand command = new SqlCommand())
                {


                    connection.Open();
                    command.Connection = connection;
                    command.CommandType = TypeMethod;
                    command.CommandText = SintaxSQL;
                    command.CommandTimeout = 120;
                    foreach (Parameters Param in Parametros)
                    {
                        command.Parameters.AddWithValue(Param.nameValue, Param.Valor);
                    }

                    dtFinal.Load(command.ExecuteReader());
                    connection.Close();
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ocurrio Un Error Al Procesar los Datos (" + ex.Message + ")");
            //}
            return dtFinal;
        }

        
    }

   
}
