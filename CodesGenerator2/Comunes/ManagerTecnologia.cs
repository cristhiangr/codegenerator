using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesGenerator2.Comunes
{
    public class ManagerTecnologia
    {

        public static Guid _ID_NET_CSHARP_ESCRITORIO = new Guid("5B7F6767-F282-47FF-BF99-8B813B93528C");
        public static Guid _ID_NET_CSHARP_WEB = new Guid("0CDE0DB9-0C5A-4AD3-A8EE-BF1930546840");
        public static Guid _ID_PHP = new Guid("6B6AE925-C086-47BE-B90D-4DEEE6A309A2");

        public Dictionary<Guid, Tecnologia> ListaTecnologias = new Dictionary<Guid, Tecnologia>();

        public ManagerTecnologia()
        {
            Tecnologia oTecnologia = new Tecnologia(_ID_NET_CSHARP_ESCRITORIO, ".NET C# Windows Form");
            ListaTecnologias.Add(_ID_NET_CSHARP_ESCRITORIO, oTecnologia);
            oTecnologia = new Tecnologia(_ID_NET_CSHARP_WEB, ".NET C# ASP MVC Web");
            ListaTecnologias.Add(_ID_NET_CSHARP_WEB, oTecnologia);
            oTecnologia = new Tecnologia(_ID_PHP, "Web PHP sin frameworks");
            ListaTecnologias.Add(_ID_PHP, oTecnologia);
        }

    }
}
