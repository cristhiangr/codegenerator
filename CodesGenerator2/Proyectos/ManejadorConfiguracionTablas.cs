using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Proyectos
{
    public class ManejadorConfiguracionTablas
    {
        public string PathProyectos = "";
        public string MensajeError = "";
        public Guid ProyectoId { get; set; }

        public ManejadorConfiguracionTablas()
        {

        }

        public bool Guardar(List<string> listaTablas)
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
                            ConfiguracionTablas oConfiguracionTablas = new ConfiguracionTablas();
                            oConfiguracionTablas.Tablas = listaTablas;
                            
                            string cadenaJson = JsonConvert.SerializeObject(oConfiguracionTablas);

                            string strPathConfiguracion = strDirectorioProyecto + "/" + "ConfiguracionTablas.json";

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
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }

            return booOk;
        }

        public ConfiguracionTablas Get()
        {
            ConfiguracionTablas oConfiguracion = null;

            try
            {
                if (PathProyectos.Length > 0)
                {
                    string strRutaProyecto = PathProyectos + "/" + ProyectoId;

                    if (Directory.Exists(strRutaProyecto))
                    {
                        string strRutaJsonProyecto = strRutaProyecto + "/ConfiguracionTablas.json";

                        using (StreamReader jsonStream = File.OpenText(strRutaJsonProyecto))
                        {
                            var json = jsonStream.ReadToEnd();
                            oConfiguracion = JsonConvert.DeserializeObject<ConfiguracionTablas>(json);
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
