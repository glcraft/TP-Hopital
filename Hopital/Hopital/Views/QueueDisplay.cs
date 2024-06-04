using System;
using Hopital.Model;

namespace Hopital.Views
{
    class QueueDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" --- Actually waiting for consultation : \n");
            foreach (int elt in Hospital.MyHospital.WaitingQueue)
            {
                Console.WriteLine(new DaoPatientSqlServer().FindById(elt));
            }
            Console.WriteLine();
            
        }
    }
}
