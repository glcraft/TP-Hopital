using System;
using Hopital.Model;

namespace Hopital.Views
{
    class QueueDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" --- Actually waiting for consultation : \n");
            if (Hospital.MyHospital.WaitingQueue.Raw.Count > 0)
            foreach (var elt in Hospital.MyHospital.WaitingQueue.Raw)
            {
                Patient p = new DaoPatientSqlServer().FindById(elt.value);
                TimeSpan duration = DateTime.Now - elt.time;
                Console.WriteLine($"{p} (waiting for {duration})");
            }
            else 
                Console.WriteLine(" +++++++++++ No Patient in the queue +++++++++++");
            Console.WriteLine();
            
        }
    }
}
