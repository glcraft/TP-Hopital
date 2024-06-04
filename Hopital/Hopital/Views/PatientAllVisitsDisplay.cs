using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital.Views 
{
    class PatientAllVisitsDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" Patient Id svp :");
            int patientId = Convert.ToInt16(Console.ReadLine());
            List < Visit > myVisits = new DaoVisitSqlServer().FindByPatientID(patientId);

            if (myVisits.Count==0)
            {
                Console.WriteLine(" Sorry no visits for you");
            }
            else
            {
                Console.WriteLine(" Here are your visits :");
                foreach (Visit v in myVisits)
                {
                    Console.WriteLine($" - {v.Date} - Doctor {v.DoctorId}");
                }
            }

        }
    }
}
