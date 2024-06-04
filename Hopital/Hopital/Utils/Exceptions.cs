using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Utils
{
    class EnvVarNotDefinedException : ApplicationException
    {
        public EnvVarNotDefinedException() : base()
        { }
        public EnvVarNotDefinedException(string variable) : base($"La variable d'envionnement {variable} n'est pas défini.")
        { }
        public EnvVarNotDefinedException(string message, Exception innerException) : base (message, innerException)
        { }
    }
}
