using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CodesGenerator2.Comunes
{
    public class ConexionBD
    {
        public SqlConnection Conexion;
        protected SqlCommand Comando;
        public SqlDataReader Reader;

        public string Servidor;
        public string Usuario;
        public string Clave;

        public string BaseDatos;

        public string CadenaConexion;

        private Logger Logger;

        public ConexionBD()
        {
            Logger = new Logger();
            Servidor = string.Empty;
            Usuario = string.Empty;
            Clave = string.Empty;
            BaseDatos = string.Empty;
        }

        public Respuesta LoadData()
        {
            Respuesta Respuesta = new Respuesta();

            try
            {
                if (Servidor != string.Empty &&
                    Usuario != string.Empty &&
                    Clave != string.Empty)
                {
                    CadenaConexion = "Data Source=" + Servidor + ";User ID=" + Usuario + ";Password=" + Clave + ";Initial Catalog=" + BaseDatos;

                    Conexion = new SqlConnection(CadenaConexion);

                    Respuesta.SetSuccess("Datos cargados correctamente");
                }
                else
                {
                    Respuesta.SetError("Faltan datos");
                }
            }
            catch (Exception ex)
            {
                Respuesta.LoadFromException(ex);
                Logger.WriteException(this, ex);
            }

            return Respuesta;

        }

        public Respuesta _EjecutarConsulta(String pSql)
        {
            Respuesta Respuesta = new Respuesta();

            try
            {
                Respuesta = this.LoadData();

                if (Respuesta.Success)
                {
                    Conexion.Open();
                    Comando = new SqlCommand(pSql, Conexion);
                    Comando.ExecuteNonQuery();

                    Respuesta.SetSuccess("Consulta ejecutada correctamente");
                }
            }
            catch (Exception ex)
            {
                CerrarConexion();
                Respuesta.LoadFromException(ex);
                Logger.WriteException(this, ex);
            }

            return Respuesta;
        }

        public Respuesta _EjecutarSelect(String pSql)
        {
            Respuesta Respuesta = new Respuesta();

            try
            {
                Reader = null;
                Respuesta = this.LoadData();

                if (Respuesta.Success)
                {
                    Conexion.Open();
                    Comando = new SqlCommand(pSql, Conexion);
                    Reader = Comando.ExecuteReader();

                    Respuesta.SetSuccess("Consulta ejecutadda correctamente");
                }
            }
            catch (Exception ex)
            {
                CerrarConexion();
                Respuesta.LoadFromException(ex);
                Logger.WriteException(this, ex);
            }

            return Respuesta;
        }

        public Respuesta CerrarConexion()
        {
            Respuesta Respuesta = new Respuesta();

            try
            {
                // close the reader
                if (Reader != null)
                {
                    Reader.Close();
                }

                // 5. Close the chjonnection
                if (Conexion != null)
                {
                    Conexion.Close();
                }
            }
            catch (Exception ex)
            {
                Respuesta.LoadFromException(ex);
                Logger.WriteException(this, ex);
            }

            return Respuesta;
        }

    }
}
