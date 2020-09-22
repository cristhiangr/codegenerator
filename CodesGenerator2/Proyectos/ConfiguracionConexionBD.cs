using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Proyectos
{
    public class ConfiguracionConexionBD
    {
        public string Instancia { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string BaseDatos { get; set; }

        public ConfiguracionConexionBD()
        {

        }
    }
}
