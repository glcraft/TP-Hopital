using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    class Admin : Staff
    {
        public Admin(string login, string password, string name, int job)
            : base(login, password, name, job)
        {
        }

        public override string ToString()
        {
            return base.ToString() + ", I am a Boss";
        }
    }
}
