using System;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientNextDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" --- Next Patient : \n");
            if (Hospital.MyHospital.WaitingQueue.Raw.Count > 0)
            {
                int next = Hospital.MyHospital.WaitingQueue.Peek();
                TimeSpan waitTime = Hospital.MyHospital.WaitingQueue.TimeSinceNow();
                Patient p = new DaoPatientSqlServer().FindById(next);
                Console.WriteLine($"{p} (waiting for {waitTime})");
            }
            else Console.WriteLine(" +++++++++++ No Patient in the queue +++++++++++");

            Console.WriteLine();
        }
    }
}