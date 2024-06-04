using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    class Patient
    {
        private int id;
        private string firstname;
        private string lastname;
        private int age;
        private string address;
        private string phoneNumber;
        public Patient(string firstname, string lastname, string address, int age, string phoneNumber)
        {
            id = 0;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Address = address;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
        }
        public Patient(int id, string firstname, string lastname, string address, int age, string phoneNumber): this(firstname, lastname, address, age, phoneNumber)
        {
            this.id = id;
        }

        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public int Age { get => age; set => age = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Id { get => id; }

        public override string ToString()
        {
            return $"{Id} - {Firstname} {Lastname}, {Age} ans, {Address} ({PhoneNumber})";
        }

    }
}
