using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CodesGenerator2.Proyectos
{
    public class ManejadorProyectos
    {

        public static string PathProyectos = "";
        public string MensajeError = "";

        public ManejadorProyectos()
        {

        }

        public bool Guardar(Guid gProyectoId, string strNombre, string strDescripcion, Guid gTecnologiaId)
        {
            bool booOk = false;

            try
            {

                string strDirectorioProyecto = PathProyectos + "/" + gProyectoId;

                if (!Directory.Exists(strDirectorioProyecto))
                {
                    if (Directory.CreateDirectory(strDirectorioProyecto).Exists)
                    {
                        Proyecto oProyecto = new Proyecto();
                        oProyecto.ProyectoId = gProyectoId.ToString();
                        oProyecto.Nombre = strNombre;
                        oProyecto.Descripcion = strDescripcion;
                        oProyecto.TecnologiaId = gTecnologiaId.ToString();

                        string cadenaJson = JsonConvert.SerializeObject(oProyecto);

                        string strDirectorio = strDirectorioProyecto;
                        string strPathParametrizacion = strDirectorio + "/" + "Proyecto.json";

                        System.IO.File.WriteAllText(strPathParametrizacion, cadenaJson);

                        if(File.Exists(strPathParametrizacion))
                        {
                            booOk = true;
                        }
                    }
                }
                else
                {
                    MensajeError = "Ya existe un directorio de proyecto con el mismo ID";
                }
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }

            return booOk;
        }

        public List<Proyecto> GetProyectos()
        {
            List<Proyecto> Lista = new List<Proyecto>();

            try
            {
                if (PathProyectos.Length > 0)
                {
                    ManejadorIO mgrIo = new ManejadorIO();
                    DirectoryInfo[] directorios = mgrIo.GetSubDirectorios(PathProyectos);

                    if(directorios != null && directorios.Length > 0)
                    {
                        foreach(DirectoryInfo directorio in directorios)
                        {
                            string strPathProyecto = directorio.FullName + "/proyecto.json";
                            Proyecto oProyecto = new Proyecto();

                            using (StreamReader jsonStream = File.OpenText(strPathProyecto))
                            {
                                var json = jsonStream.ReadToEnd();
                                oProyecto = JsonConvert.DeserializeObject<Proyecto>(json);

                                Lista.Add(oProyecto);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MensajeError = ex.Message;
            }

            return Lista;
        }

        public Proyecto Get(Guid gId)
        {
            Proyecto oProyecto = null;

            try
            {
                if (PathProyectos.Length > 0)
                {
                    string strRutaProyecto = PathProyectos + "/" + gId;

                    if(Directory.Exists(strRutaProyecto))
                    {
                        string strRutaJsonProyecto = strRutaProyecto + "/proyecto.json";

                        using (StreamReader jsonStream = File.OpenText(strRutaJsonProyecto))
                        {
                            var json = jsonStream.ReadToEnd();
                            oProyecto = JsonConvert.DeserializeObject<Proyecto>(json);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }

            return oProyecto;
        }
    }
}
