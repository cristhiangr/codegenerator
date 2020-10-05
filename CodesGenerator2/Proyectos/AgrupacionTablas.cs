using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Proyectos
{
    public class AgrupacionTablas
    {
        public string NombreGrupo { get; set; }
        public List<string> Tablas { get; set; }

        public AgrupacionTablas()
        {
            Tablas = new List<string>();
        }
    }
}
