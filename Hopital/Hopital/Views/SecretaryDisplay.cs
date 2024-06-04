using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital.Views
{
    class SecretaryDisplay
    {
        Secretary secretary;

        public SecretaryDisplay(Secretary sec)
        {
            this.secretary = sec;
        }

        public void Display()
        {
            bool logout = false;



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
                    case 1:
                        new PatientCheckInDisplay().Display();
                        break;
                    case 2:
                        new QueueDisplay().Display();
                        break;
                    case 3:
                        new PatientNextDisplay().Display();
                        break;
                    case 4:
                        new PatientAllVisitsDisplay().Display();
                        break;
                    case 5:
                        new PatientUpdateDisplay().Display();
                        break;
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
