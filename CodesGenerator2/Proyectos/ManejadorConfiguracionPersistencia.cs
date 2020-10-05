using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Proyectos
{
    public class ManejadorConfiguracionPersistencia
    {
        public string PathProyectos = "";
        public string MensajeError = "";
        public Guid ProyectoId { get; set; }

        public ManejadorConfiguracionPersistencia()
        {

        }

        public bool Guardar(ConfiguracionPersistencia oConfiguracion)
        {
            bool booOk = false;

            try
            {
                if (PathProyectos != string.Empty && ProyectoId != Guid.Empty)
                {
                    string strDirectorioProyecto = PathProyectos + "/" + ProyectoId;

                    if (Directory.Exists(strDirectorioProyecto))
                    {
                        if (Directory.CreateDirectory(strDirectorioProyecto).Exists)
                        {

                            string cadenaJson = JsonConvert.SerializeObject(oConfiguracion);

                            string strPath = strDirectorioProyecto + "/" + "ConfiguracionPersistencia.json";

                            System.IO.File.WriteAllText(strPath, cadenaJson);

                            if (File.Exists(strPath))
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
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }

            return booOk;
        }

        public ConfiguracionPersistencia Get()
        {
            ConfiguracionPersistencia oConfiguracion = null;

            try
            {
                if (PathProyectos.Length > 0)
                {
                    string strRutaProyecto = PathProyectos + "/" + ProyectoId;

                    if (Directory.Exists(strRutaProyecto))
                    {
                        string strRutaJsonProyecto = strRutaProyecto + "/ConfiguracionPersistencia.json";

                        using (StreamReader jsonStream = File.OpenText(strRutaJsonProyecto))
                        {
                            var json = jsonStream.ReadToEnd();
                            oConfiguracion = JsonConvert.DeserializeObject<ConfiguracionPersistencia>(json);
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
