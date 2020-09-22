using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Comunes
{
    class ComboItem
    {
        public Guid Id { get; set; }
        public string Dato { get; set; }

        public ComboItem()
        {
            Id = Guid.Empty;
            Dato = string.Empty;
        }

        public ComboItem(Guid gId, string strDato)
        {
            Id = gId;
            Dato = strDato;
        }

        public override string ToString()
        {
            return Dato;
        }
    }
}
