using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Comunes
{
    public class Tecnologia
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public Tecnologia()
        {
            Id = Guid.Empty;
            Nombre = string.Empty;
        }

        public Tecnologia(Guid gId, string strNombre)
        {
            Id = gId;
            Nombre = strNombre;
        }
    }
}
