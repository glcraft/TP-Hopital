﻿using System;

using Hopital.Model;

namespace Hopital.Views
{
    class AdminDisplay : IDisplay
    {

        Admin admin;

        public AdminDisplay(Admin admin)
        {
            this.admin = admin;
        }

        public void Display()
        {
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine(admin);

                Console.WriteLine("\n" + $"Hello {admin.Name} you are logged as an administrateur.");

                Console.WriteLine($"-----------------------------------");
                Console.WriteLine();
                Console.WriteLine($" 1 - Add a new patient");
                Console.WriteLine($" 2 - Delete a patient");
                Console.WriteLine($" 3 - Update a patient");
                Console.WriteLine($" 4 - See all patients");
                Console.WriteLine($" 5 - See a spécific patient");
                Console.WriteLine($" 10 - Logout");
                Console.WriteLine($" 11 - Quit service");
                Console.Write($"\n--> Your choise : ");

                int resp = Convert.ToInt16(Console.ReadLine());
                switch (resp)
                {
                    case 1:
                        new PatientAddNewDisplay().Display();
                        break;
                    case 10:
                        logout = true;
                        break;
                    case 11:
                        Staff toremove = Hospital.MyHospital.ActiveStaff.Find(r => r.Login == admin.Login);
                        Hospital.MyHospital.ActiveStaff.Remove(toremove);
                        logout = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
