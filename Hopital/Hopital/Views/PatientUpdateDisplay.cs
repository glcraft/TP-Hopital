using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientUpdateDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" Patient Id for update  :");
            int patientId = Convert.ToInt16(Console.ReadLine());
            // check if patient exist
            Patient currentPatient = new DaoPatientSqlServer().FindById(patientId);

            if (currentPatient != null)
            {

                // patient info 
                string firstname = currentPatient.Firstname;
                string lastname = currentPatient.Lastname;
                string phoneNumber = currentPatient.PhoneNumber;
                string address = currentPatient.Address;

                Console.WriteLine($" {firstname} {lastname}, Actually :");

                Console.WriteLine($"Address : {address}");
                Console.Write($" Enter new Address : ");
                string newAddress = Convert.ToString(Console.ReadLine());

                Console.WriteLine($"PhoneNumber : {phoneNumber}");
                Console.Write($" Enter new phone Number :");
                string newPhoneNumber = Convert.ToString(Console.ReadLine());
                Console.WriteLine("nnnn "+ newPhoneNumber + "  " + newAddress);
                if ( address != newAddress) currentPatient.Address = newAddress;
                if (phoneNumber != newPhoneNumber) currentPatient.PhoneNumber = newPhoneNumber;

                Console.WriteLine(currentPatient.ToString());

               new DaoPatientSqlServer().Update(currentPatient);
            }
            else
            {

            }

        }
    }
}
