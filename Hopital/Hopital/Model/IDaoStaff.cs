using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
 
    interface IDaoStaff : IDao<Staff, int>
    {
        Staff Login(string login, string password);
    }
}
