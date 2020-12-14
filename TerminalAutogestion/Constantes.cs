using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalAutogestion
{
    public class Constantes
    {
#if DEBUG
        public static string SOAP_SERVICE_URL = "BasicHttpBinding_ISL_Soap_Local";
#else
        public static string SOAP_SERVICE_URL = "BasicHttpBinding_ISL_Soap_Azure";
#endif
    }
}
