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
            Console.WriteLine(" Enter the patient ID :");
            int patientId = Convert.ToInt32(Console.ReadLine());
            List<Visit> myVisits = new DaoVisitSqlServer().FindByPatientID(patientId);

            if (myVisits.Count==0)
            {
                Console.WriteLine($" Sorry, no visits for patient {patientId}");
                return;
            }
            Console.WriteLine($" Visits for patient {patientId}:");
            foreach (Visit v in myVisits)
            {
                string waitTime = null;
                if (v.WaitTime != null)
                    waitTime = $" (waiting for {(int)v.WaitTime}) seconds";
                Console.WriteLine($" - {v.Date} - Doctor {v.DoctorId}{waitTime}");
            }
        }
    }
}
