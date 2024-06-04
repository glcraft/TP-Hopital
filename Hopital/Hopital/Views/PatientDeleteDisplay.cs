using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientDeleteDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" Patient Id svp :");
            int patientId = Convert.ToInt16(Console.ReadLine());
            new DaoPatientSqlServer().Delete(patientId);
        }
    }
}
