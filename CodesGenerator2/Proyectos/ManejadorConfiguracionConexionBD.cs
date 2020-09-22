using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Proyectos
{
    public class ManejadorConfiguracionConexionBD
    {
        public string PathProyectos { get; set; }
        public Guid ProyectoId { get; set; }

        public string MensajeError;

        public ManejadorConfiguracionConexionBD()
        {
            PathProyectos = string.Empty;
            ProyectoId = Guid.Empty;
        }

        public bool Guardar(string strInstancia, string strUsuario, string strContrasena, string strBaseDatos)
        {
            bool booOk = false;

            try
            {
                if(PathProyectos != string.Empty && ProyectoId != Guid.Empty)
                {
                    string strDirectorioProyecto = PathProyectos + "/" + ProyectoId;

                    if (Directory.Exists(strDirectorioProyecto))
                    {
                        if (Directory.CreateDirectory(strDirectorioProyecto).Exists)
                        {
                            ConfiguracionConexionBD oConfiguracion = new ConfiguracionConexionBD();
                            oConfiguracion.Instancia = strInstancia;
                            oConfiguracion.Usuario = strUsuario;
                            oConfiguracion.Contrasena = strContrasena;
                            oConfiguracion.BaseDatos = strBaseDatos;

                            string cadenaJson = JsonConvert.SerializeObject(oConfiguracion);

                            string strPathConfiguracion = strDirectorioProyecto + "/" + "ConfiguracionConexionBD.json";

                            System.IO.File.WriteAllText(strPathConfiguracion, cadenaJson);

                            if (File.Exists(strPathConfiguracion))
                            {
                                booOk = true;
                            }
                        }
                    }
                    else
                    {
                        MensajeError = "No existe el directorio con ese ID";
                    }
                }
                else
                {
                    MensajeError = "Los campos PathProyectos y ProyectoId no tienen contenido";
                }
            }
            catch(Exception ex)
            {
                MensajeError = ex.Message;
            }

            return booOk;
        }


        public ConfiguracionConexionBD Get()
        {
            ConfiguracionConexionBD oConfiguracion = null;

            try
            {
                if (PathProyectos.Length > 0)
                {
                    string strRutaProyecto = PathProyectos + "/" + ProyectoId;

                    if (Directory.Exists(strRutaProyecto))
                    {
                        string strRutaJsonProyecto = strRutaProyecto + "/ConfiguracionConexionBD.json";

                        using (StreamReader jsonStream = File.OpenText(strRutaJsonProyecto))
                        {
                            var json = jsonStream.ReadToEnd();
                            oConfiguracion = JsonConvert.DeserializeObject<ConfiguracionConexionBD>(json);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }

            return oConfiguracion;
        }
    }
}
