using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace testApp
{
    class tableMysql
    {
        //Variables publicas
        public bool conectado = false;
        public string estatusReport;


        //Mysql
        MySqlConnection conexion;
        MySqlCommand resultQuery;
        MySqlDataReader reader;

        /*********************************************************************************/
        public void conectar(string server, string user, string password, string nameDB){
            string sql = "server=" + server + "; user id=" + user + "; database=" + nameDB + "; password=" + password;
            conexion = new MySqlConnection(sql);
            //Conexion.ConnectionString = sql

            //Intenta conectar con la base de datos
            try
            {
                conexion.Open();
                conectado = true;
                estatusReport = "DB: Conexion establecida \r\n";
            }
            catch
            {
                conectado = false;
                estatusReport = "DB: No hay conexion a la DB \r\n";
            }
        }
        /*********************************************************************************/
        public bool insertar(string queryText)
        {
            if (conectado)
            {
                //Intentar llenar la tabla
                try
                {
                    resultQuery = new MySqlCommand(queryText, conexion);
                    int filasAfectadas = resultQuery.ExecuteNonQuery();
                    
                    //MessageBox.Show("Funciono: " + filasAfectadas);
                    if (filasAfectadas == 1)
                    {
                        estatusReport = "DB: Fila registrada \r\n";
                        return true;
                    }
                    //No pudo registrar
                    estatusReport = "DB: Intento registrar pero hubo algun problema \r\n";
                }
                catch(Exception ex)
                {
                    conectado = false;
                    estatusReport = "DB: Se rompio la conexion \r\n" + ex;                    
                }
            }
            else
            {
                estatusReport = "DB: No hay conexion a mysql \r\n";
                //MessageBox.Show("Sin conexion a la DB");
            }

            //No pudo enviar la consulta
            return false;
        }
        /********************************************************************************/
        public bool consulta(string queryText, out string result)
        {
            bool lectura = false;
            result = "";
            
            if (conectado)
            {
                try
                {
                    resultQuery = new MySqlCommand(queryText, conexion);
                    reader = resultQuery.ExecuteReader();

                    if (reader.HasRows || reader.RecordsAffected > 0)
                    {
                        lectura = true;

                        if (reader.Read())
                        {
                            result = reader.GetString(0);
                        }
                    }
                   
                    reader.Close();
                }
                catch (Exception ex)
                {
                    estatusReport = "DB error de lectura" + ex + "\r\n";
                }
            }
            else
            {
                estatusReport = "DB: No hay conexion a mysql \r\n";
            }

            return lectura;
        }
        /********************************************************************************/
        public bool update(string queryText)
        {
            bool lectura = false;

            if (conectado)
            {
                try
                {
                    resultQuery = new MySqlCommand(queryText, conexion);
                    reader = resultQuery.ExecuteReader();

                    if (reader.RecordsAffected > 0)
                    {
                        lectura = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    estatusReport = "DB error de lectura" + ex + "\r\n";
                }
            }
            else
            {
                estatusReport = "DB: No hay conexion a mysql \r\n";
            }

            return lectura;
        }
    }
}
