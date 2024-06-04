using System;
using Hopital.Model;

namespace Hopital.Views
{
    class PatientNextDisplay : IDisplay
    {
        public void Display()
        {
            Console.WriteLine(" --- Next Patient : \n");
            int next = Hospital.MyHospital.WaitingQueue.Peek();
            Console.WriteLine(new DaoPatientSqlServer().FindById(next));
            Console.WriteLine();
        }
    }
}