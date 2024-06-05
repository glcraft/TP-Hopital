using System;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientNextDisplay : IDisplay
    {
        public void Display()
        {
            int next = Hospital.MyHospital.WaitingQueue.Peek();
            TimeSpan waitTime = Hospital.MyHospital.WaitingQueue.TimeSinceNow();
            Patient p = new DaoPatientSqlServer().FindById(next);
            Console.WriteLine(" --- Next Patient :");
            Console.WriteLine($"{p} (waiting for {waitTime})");
            Console.WriteLine();
        }
    }
}