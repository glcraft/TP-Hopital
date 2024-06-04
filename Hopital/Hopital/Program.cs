using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital
{
    class TestVisits 
    {
        static void TestCreateVisit()
        {
            DaoVisite x = new DaoVisitSqlServer();
            x.Create(new Visit(1, "123456", DateTime.Now, 1));
        }

        static void TestDeleteVisit()
        {
            DaoVisite x = new DaoVisitSqlServer();
            x.Delete(2);
        }

        static void TestFindByDoctorID()
        {
            DaoVisite x = new DaoVisitSqlServer();
            List<Visit> listV = x.FindByDoctorID("123456");
            foreach (Visit v in listV)
            {
                Console.WriteLine(v);
            }
        }
        static void TestFindByPatientID()
        {
            DaoVisite x = new DaoVisitSqlServer();
            List<Visit> listV = x.FindByPatientID(1);
            foreach (Visit v in listV)
            {
                Console.WriteLine(v);
            }
        }
    }
    class TestStaff 
    {
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            NewLogin();
        }
        static void NewLogin()
        {
          
            bool goOn = true;

            do
            {
                Console.WriteLine("Welcome to the Console App");
                Console.WriteLine(" ___  ___ _  _    __    __ ______ ______ __     ____    __  __   ___    __  ____  __ ______  ___  __   ");
                Console.WriteLine(@" ||\\//|| \\//    ||    || | || | | || | ||    ||       ||  ||  // \\  (( \ || \\ || | || | // \\ ||   ");
                Console.WriteLine(@" || \/ ||  )/     ||    ||   ||     ||   ||    ||==     ||==|| ((   ))  \\  ||_// ||   ||   ||=|| ||   ");
                Console.WriteLine(@" ||    || //      ||__| ||   ||     ||   ||__| ||___    ||  ||  \\_//  \_)) ||    ||   ||   || || ||__|");
                Console.WriteLine();
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                Staff user = null;
                user = new DaoStaffSqlServer().Login(username, password);

                if (user != null)
                {
                    Hospital.MyHospital.ActiveStaff.Add(user);

                    Console.WriteLine("Active Staff  : ");
                    foreach (Staff s in Hospital.MyHospital.ActiveStaff)
                    {
                        Console.WriteLine(s.Name);
                    }


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
                    Console.WriteLine("\nInvalid username or password.");
                    Console.WriteLine("------- Access denied ------\n");
                }

                Console.WriteLine("Do you want shut down the application  y/n ?");
                string resp = Console.ReadLine();
                if (resp == "y") goOn = false;
                Console.Clear();
            } while (goOn);
        }

        static void DoctorInterface(Doctor doctor)
        {
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine (doctor);

                Console.WriteLine("\n"+$"Hello Doctor {doctor.Name} you are logged as a doctor.");
                
                Console.WriteLine($"-----------------------------------");
                Console.WriteLine($"Your current patient is ..... : ");
                Console.WriteLine();
                Console.WriteLine($" 1 - Display the queue");
                Console.WriteLine($" 2 - Next Patient");
                Console.WriteLine($" 3 - Display lasts visits (not saved)");
                Console.WriteLine($" 4 - Save lasts visits in DB");
                Console.WriteLine($" 5 - See all recorded visits (from db)");
                Console.WriteLine($" 10 - Logout");
                Console.WriteLine($" 11 - Quit service");
                Console.Write($"\n--> Your choise : ");

                int resp = Convert.ToInt16(Console.ReadLine());
                switch (resp)
                {
                    case 10:
                        logout = true;
                        break;
                    case 11:
                        Staff toremove = Hospital.MyHospital.ActiveStaff.Find( r => r.Login == doctor.Login );
                        Hospital.MyHospital.ActiveStaff.Remove(toremove);
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

            Hospital.MyHospital.WaitingQueue.Enqueue(1);

            while (!logout)
            {
                Console.WriteLine($"Hello Miss {secretary.Name} you are logged as a secretary.");
                Console.WriteLine($"-----------------------------------");
                Console.WriteLine($" 1 - Inqueue a new patient");
                Console.WriteLine($" 2 - Display the queue");
                Console.WriteLine($" 3 - Display the next Patient");
                Console.WriteLine($" 4 - Display all visits of a patient");
                Console.WriteLine($" 5 - Update patient information");
                Console.WriteLine($" 10 - Logout");
                Console.WriteLine($" 11 - Quit service");
                Console.Write($"\n--> Your choise : ");

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
