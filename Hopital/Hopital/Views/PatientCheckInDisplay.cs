using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientCheckInDisplay :IDisplay
    { 
 
        public PatientCheckInDisplay()
        {
        }

        public void Display()
        {
            Console.WriteLine(" Patient Id svp :");
            int patientId = Convert.ToInt16(Console.ReadLine());
            // check if patient exist
            Patient newPatient = new DaoPatientSqlServer().FindById(patientId);

            if (newPatient != null)
            {

                Console.WriteLine(newPatient);
                Hospital.MyHospital.AddPatientToQueue(patientId);

            }
            else
            {
                // saisie du nouveau patient
                Console.WriteLine("Name :");
                string lastname = Convert.ToString(Console.ReadLine());
                Console.WriteLine("First Name :");
                string firstname = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Address :");
                string address = Convert.ToString(Console.ReadLine());
                Console.WriteLine("PhoneNumber :");
                string phoneNumber = Convert.ToString(Console.ReadLine());
                Console.WriteLine("age :");
                int age = Convert.ToInt16(Console.ReadLine());
                Patient p = new Patient(firstname, lastname, address, age, phoneNumber);
                int id =  new DaoPatientSqlServer().Create(p);

                Hospital.MyHospital.AddPatientToQueue(id);

            }
            Console.WriteLine("Patient added in the active queue");
        }
    }
}
