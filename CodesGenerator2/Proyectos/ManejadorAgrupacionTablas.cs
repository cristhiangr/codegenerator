using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Proyectos
{
    public class ManejadorAgrupacionTablas
    {
        public string PathProyectos = "";
        public string MensajeError = "";
        public Guid ProyectoId { get; set; }

        public ManejadorAgrupacionTablas()
        {

        }

        public bool Guardar(List<AgrupacionTablas> listaAgrupaciones)
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
                            ListaAgrupacionesTablas olistaAgrupaciones = new ListaAgrupacionesTablas();
                            olistaAgrupaciones.AgrupacionesTablas = listaAgrupaciones;

                            string cadenaJson = JsonConvert.SerializeObject(olistaAgrupaciones);

                            string strPathAgrupaciones = strDirectorioProyecto + "/" + "AgrupacionesTablas.json";

                            System.IO.File.WriteAllText(strPathAgrupaciones, cadenaJson);

                            if (File.Exists(strPathAgrupaciones))
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

        public ListaAgrupacionesTablas Get()
        {
            ListaAgrupacionesTablas oAgrupaciones = null;

            try
            {
                if (PathProyectos.Length > 0)
                {
                    string strRutaProyecto = PathProyectos + "/" + ProyectoId;

                    if (Directory.Exists(strRutaProyecto))
                    {
                        string strRutaJsonProyecto = strRutaProyecto + "/AgrupacionesTablas.json";

                        using (StreamReader jsonStream = File.OpenText(strRutaJsonProyecto))
                        {
                            var json = jsonStream.ReadToEnd();
                            oAgrupaciones = JsonConvert.DeserializeObject<ListaAgrupacionesTablas>(json);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }

            return oAgrupaciones;
        }
    }
}