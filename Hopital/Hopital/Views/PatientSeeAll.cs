using System;
using System.Collections.Generic;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientSeeAllDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" Complete list of Patients:");
            List<Patient> allPatients = new DaoPatientSqlServer().FindAll();
            
            foreach (Patient  p in allPatients)
            {
                Console.WriteLine(p);

            }

        }
    }
}