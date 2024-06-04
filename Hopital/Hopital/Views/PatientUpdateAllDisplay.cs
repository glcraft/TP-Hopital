using System;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientUpdateAllDisplay : IDisplay
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
            string firstname = currentPatient.Firstname;
            string lastname = currentPatient.Lastname;
            string phoneNumber = currentPatient.PhoneNumber;
            string address = currentPatient.Address;
            int age = currentPatient.Age;

            Console.WriteLine($" Patient id n° {patientId}, Actually :");

            Console.WriteLine($"Current firstname of the patient: {firstname}");
            Console.Write($" Enter new firstname (leave empty for no modification) : ");
            string newfirstname = Console.ReadLine();
            if (newfirstname.Length > 0)
                currentPatient.Firstname = newfirstname;

            Console.WriteLine($"Current lastname of the patient: {lastname}");
            Console.Write($" Enter new lastname (leave empty for no modification) : ");
            string newlastname = Console.ReadLine();
            if (newlastname.Length > 0)
                currentPatient.Lastname = newlastname;

            Console.WriteLine($"Current age of the patient: {age}");
            Console.Write($" Enter new age (leave empty for no modification) : ");
            string newAge = (Console.ReadLine());
            if (newAge.Length > 0)
                currentPatient.Age = Convert.ToUInt16(newAge);

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
