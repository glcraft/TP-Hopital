using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientAllVisitsByDoctorId : IDisplay
    {
        public void Display(string id)
        {
           
            List<Visit> myVisits = new DaoVisitSqlServer().FindByDoctorID(id);

            if (myVisits.Count == 0)
            {
                Console.WriteLine($" Sorry, no visits  ");
                return;
            }
            Console.WriteLine($" Visits :");
            foreach (Visit v in myVisits)
            {
                Console.WriteLine($" - {v.Date} - patient id  {v.PatientId}");
            }
        }

        public void Display()
        {
            throw new NotImplementedException();
        }
    }
}
