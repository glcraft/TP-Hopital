using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    interface IDaoVisite : IDao<Visit, int>
    {
        List<Visit> FindByPatientID(int id);
        List<Visit> FindByDoctorID(string id);
    }
}
