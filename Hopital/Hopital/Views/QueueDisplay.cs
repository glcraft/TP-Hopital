using System;
using Hopital.Model;

namespace Hopital.Views
{
    class QueueDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" --- Actually waiting for consultation : \n");
            foreach (var elt in Hospital.MyHospital.WaitingQueue.Raw)
            {
                Console.WriteLine(new DaoPatientSqlServer().FindById(elt.value));
            }
            Console.WriteLine();
            
        }
    }
}
