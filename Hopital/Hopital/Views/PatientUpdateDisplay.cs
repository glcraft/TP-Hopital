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
            Console.Write($" Enter new address (leave empty for no modification) : ");
            string newAddress = Console.ReadLine();
            if (newAddress.Length > 0)
                currentPatient.Address = newAddress;

            Console.WriteLine($"Current phone number of the patient: {phoneNumber}");
            Console.Write($" Enter new phone number (leave empty for no modification) : ");
            string newPhoneNumber = Console.ReadLine();
            if (newPhoneNumber.Length > 0)
                currentPatient.PhoneNumber = newPhoneNumber;

            new DaoPatientSqlServer().Update(currentPatient);
            
            Console.WriteLine($"Patient updated: {currentPatient}");
        }
    }
}
