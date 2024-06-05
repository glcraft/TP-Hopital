using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientSpecificDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" Patient Id svp :");
            int patientId = Convert.ToInt16(Console.ReadLine());
            Patient p = new DaoPatientSqlServer().FindById(patientId);
            Console.WriteLine($"Selected patient: {p}");
        }
    }
}
