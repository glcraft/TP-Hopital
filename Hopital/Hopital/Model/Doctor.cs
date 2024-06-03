using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    class Doctor:Staff
    {
        public Doctor(string login, string password, string name, int job)
            : base(login, password, name, job)
        {
        }

    }
}
