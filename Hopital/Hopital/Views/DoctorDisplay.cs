using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital.Views
{
    class DoctorDisplay : IDisplay
    {
        Doctor doctor ;
        ConsultingRoom consultingRoom;

        public  DoctorDisplay(Doctor doc)
        {
            doctor = doc;
            consultingRoom = Hospital.MyHospital.ConsultingRooms.Find(cr => cr.RoomId == doctor.Job);
            consultingRoom.DoctorId = doctor.Login;
        }

        public void Display()
        {
            bool logout = false;
            while (!logout)
            {
                Console.WriteLine(doctor);

                Console.WriteLine($"Consulting room ID : {consultingRoom.RoomId}\tDoctor ID : {consultingRoom.DoctorId}");

                Console.WriteLine("\n" + $"Hello Doctor {doctor.Name} you are logged as a doctor.");

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
                    case 1:
                        new QueueDisplay().Display();
                        break;
                    case 2:
                        consultingRoom.CreateCurrentVisit();
                        break;
                    case 3:
                        consultingRoom.GetCurrentVisitList();
                        break;
                    case 4:
                        consultingRoom.SaveCurrentVisitList();
                        break;
                    case 10:
                        logout = true;
                        break;
                    case 11:
                        Staff toremove = Hospital.MyHospital.ActiveStaff.Find(r => r.Login == doctor.Login);
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
