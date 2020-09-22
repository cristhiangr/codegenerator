using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CodesGenerator2.Comunes
{
    public class ManagerParametrizacion
    {

        public static string PathAplicacion = "";

        public string MensajeError = "";

        public ManagerParametrizacion()
        {

        }

        public Parametrizacion GetParametrizacion()
        {
            Parametrizacion oParametrizacion = null;

            try
            {
                string strDirectorio = PathAplicacion;

                if (ManejadorIO.Existe(strDirectorio, "Parametrizacion.json"))
                {
                    string strPathParametrizacion = strDirectorio + "/" + "Parametrizacion.json";
                    using (StreamReader jsonStream = File.OpenText(strPathParametrizacion))
                    {
                        var json = jsonStream.ReadToEnd();
                        oParametrizacion = JsonConvert.DeserializeObject<Parametrizacion>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeError = ex.Message;
            }

            return oParametrizacion;
        }
    }
}
