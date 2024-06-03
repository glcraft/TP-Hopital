using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital
{
    class Program
    {
        static void Main(string[] args)
        {

            //TestSelectAll();
            //TestLog();
            NewLogin();
        }

        static void TestSelectAll()
        {
            List<Staff> x = new DaoStaffSqlServer().FindAll();
            foreach (Staff p in x)
                Console.WriteLine(p.Name + "login =" + p.Login + "password =" + p.Password);
        }

        static void TestLog()
        {
            Console.WriteLine(new DaoStaffSqlServer().Login("a", "a"));
        }

        static void NewLogin()
        {
            Console.WriteLine("Welcome to the Console Login App");
            Console.WriteLine(" ___  ___ _  _    __    __ ______ ______ __     ____    __  __   ___    __  ____  __ ______  ___  __   ");
            Console.WriteLine(@" ||\\//|| \\//    ||    || | || | | || | ||    ||       ||  ||  // \\  (( \ || \\ || | || | // \\ ||   ");
            Console.WriteLine(@" || \/ ||  )/     ||    ||   ||     ||   ||    ||==     ||==|| ((   ))  \\  ||_// ||   ||   ||=|| ||   ");
            Console.WriteLine(@" ||    || //      ||__| ||   ||     ||   ||__| ||___    ||  ||  \\_//  \_)) ||    ||   ||   || || ||__|");
            Console.WriteLine();
            bool goOn = true;

            do
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                Staff user = null;
                user = new DaoStaffSqlServer().Login(username, password);

                if (user != null)
                {
                    Console.WriteLine("Login successful!" + user.ToString());
                    // TODO: Add logic to navigate to the main application functionality.
                    switch (user)
                    {
                        case Doctor doctor:
                            DoctorInterface(doctor);
                            break;
                        case Secretary secretary:
                            SecretaryInterface(secretary);
                            break;
                        default:
                            Console.WriteLine("Unknown staff type.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                    Console.WriteLine("Access denied.");
                }

                Console.WriteLine("Do you want to quit the application  y/n ?");
                char resp = Convert.ToChar(Console.ReadLine());
                if (resp == 'y') goOn = false;
            } while (goOn);




        }

        static void DoctorInterface(Doctor doctor)
        {
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine($"Hello Doctor {doctor.Name}");
                Console.WriteLine($"-----------------------------------");
                Console.WriteLine($" 1 - Display the queue");
                Console.WriteLine($" 2 - Following Patient");
                Console.WriteLine($" 3 - See all recorded visits");
                Console.WriteLine($" 10 - Logout");

                int resp = Convert.ToInt16(Console.ReadLine());
                switch (resp)
                {
                    case 10:
                        logout = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;  
                }
            }
        }

        static void SecretaryInterface(Secretary secretary)
        {
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine($"Hello Miss {secretary.Name}");
                Console.WriteLine($"-----------------------------------");
                Console.WriteLine($" 1 - Inqueue a new patient");
                Console.WriteLine($" 2 - Following Patient");
                Console.WriteLine($" 3 - See all recorded visits");
                Console.WriteLine($" 10 - Logout");

                int resp = Convert.ToInt16(Console.ReadLine());
                switch (resp)
                {
                    case 10:
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
