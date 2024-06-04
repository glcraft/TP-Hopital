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
            Console.WriteLine(" Enter the patient ID for update :");
            int patientId = Convert.ToInt16(Console.ReadLine());
            // check if patient exist
            Patient currentPatient = new DaoPatientSqlServer().FindById(patientId);

            if (currentPatient == null)
                return;
            // patient info 
            string phoneNumber = currentPatient.PhoneNumber;
            string address = currentPatient.Address;

            Console.WriteLine($" {currentPatient.Firstname} {currentPatient.Lastname}, Actually :");

            Console.WriteLine($"Current address of the patient: {address}");
            Console.Write($" Enter new Address : ");
            string newAddress = Console.ReadLine();

            Console.WriteLine($"Current phone number of the patient: {phoneNumber}");
            Console.Write($" Enter new phone Number : ");
            string newPhoneNumber = Console.ReadLine();
            if (address != newAddress) currentPatient.Address = newAddress;
            if (phoneNumber != newPhoneNumber) currentPatient.PhoneNumber = newPhoneNumber;

            Console.WriteLine(currentPatient.ToString());

            new DaoPatientSqlServer().Update(currentPatient);
        }
    }
}
