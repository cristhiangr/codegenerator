using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Proyectos
{
    public class ConfiguracionPersistencia
    {
        public int GenerarClasesGenerales { get; set; }
        public int GenerarClasesDeDominio { get; set; }
        public int GenerarClasesManejadoras { get; set; }

        public ConfiguracionPersistencia()
        {
            GenerarClasesDeDominio = 2;
            GenerarClasesGenerales = 2;
            GenerarClasesManejadoras = 2;
        }
    }
}