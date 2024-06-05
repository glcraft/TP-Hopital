using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientAddNewDisplay : IDisplay
    {
        public void Display()
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
            int id = new DaoPatientSqlServer().Create(p);

            Console.WriteLine($"Patient Created id : {id}");
        }
    }
}
