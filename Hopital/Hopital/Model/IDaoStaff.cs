using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
 
    interface IDaoStaff : IDao<Staff, int>
    {
        List<Staff> FindByNom(string nom);
    }
}
