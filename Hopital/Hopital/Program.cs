using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;
using Hopital.Views;

namespace Hopital
{
    class TestVisits
    {
        public static void TestCreateVisit()
        {
            IDaoVisite x = new DaoVisitSqlServer();
            x.Create(new Visit(1, 120, "a", DateTime.Now, 1));
        }

        public static void TestDeleteVisit()
        {
            IDaoVisite x = new DaoVisitSqlServer();
            x.Delete(2);
        }

        public static void TestFindByDoctorID()
        {
            IDaoVisite x = new DaoVisitSqlServer();
            List<Visit> listV = x.FindByDoctorID("a");
            Console.WriteLine("Visit found: {0}", listV.Count);
            foreach (Visit v in listV)
            {
                Console.WriteLine(v);
            }
        }
        public static void TestFindByPatientID()
        {
            IDaoVisite x = new DaoVisitSqlServer();
            List<Visit> listV = x.FindByPatientID(1);
            foreach (Visit v in listV)
            {
                Console.WriteLine(v);
            }
        }
    }
    class TestStaff
    {
        public static void TestSelectAll()
        {
            List<Staff> x = new DaoStaffSqlServer().FindAll();
            foreach (Staff p in x)
                Console.WriteLine(p.Name + "login =" + p.Login + "password =" + p.Password);
        }

        public static void TestLog()
        {
            Console.WriteLine(new DaoStaffSqlServer().Login("a", "a"));
        }

        public static void TestNumberOfRoom()
        {
            Console.WriteLine(new DaoStaffSqlServer().NumberOfRoom());
        }
        public static void TestListOfRoomNumber()
        {
            List<int> liste = new DaoStaffSqlServer().ListOfRoomNumber();
            foreach (int i in liste)
            {
                Console.WriteLine(i);
            }
        }

    }

    class TestPatient
    {
        public static void CreatePatient()
        {
            new DaoPatientSqlServer().Create(new Patient("Jean", "DURANT", "3 rue des brions", 34, "0123456789"));
        }
        public static void FindAllPatient()
        {
            List<Patient> pats = new DaoPatientSqlServer().FindAll();
            Console.WriteLine("Number of patient: {0}", pats.Count);
            foreach (Patient pat in pats)
            {
                Console.WriteLine("- {0}", pat);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NewLogin();
            //TestStaff.TestListOfRoomNumber();
            //List<ConsultingRoom> listeC = Hospital.MyHospital.ConsultingRooms;
            //Console.WriteLine(listeC.Count);
            //listeC[0].ToString();
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

                // check if username exists in ActiveStaff and in room is free for use
                bool alreadyActive = false;
                foreach (Staff s in Hospital.MyHospital.ActiveStaff)
                {
                    if (s.Login == username)
                    {
                        alreadyActive = true;
                        break;
                    }
                    if (s.Job == user.Job && s.Login != username)
                    {
                        Console.WriteLine($"\n Sorry Docteur {user.Name} your room isn't available. Docteur {s.Name} is present.");
                        user = null;
                    }
                }

                if (user != null)
                {
                    if (!alreadyActive)
                        Hospital.MyHospital.ActiveStaff.Add(user);

                    Console.WriteLine("\nToday active Staff  : ");
                    foreach (Staff s in Hospital.MyHospital.ActiveStaff)
                    {
                        Console.WriteLine($"\t - {s.Name}  ");
                    }
                    Console.WriteLine("Have a nice day. \n");
                    switch (user)
                    {
                        case Doctor doctor:
                            new DoctorDisplay(doctor).Display();
                            break;
                        case Secretary secretary:
                            new SecretaryDisplay(secretary).Display();
                            break;
                        case Admin admin:
                            new AdminDisplay(admin).Display();
                            break;
                        default:
                            Console.WriteLine("Unknown staff type.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n------- Access denied ------\n");
                }
                Console.WriteLine("Do you want shut down the application  y/n ?");
                string resp = Console.ReadLine();
                if (resp == "y")
                {
                    Console.WriteLine("Are you sure ?  y/n ?");
                    string confirm = Console.ReadLine();
                    if (confirm == "y")
                        goOn = false;
                }
                Console.Clear();
            } while (goOn);
        }
    }
}
