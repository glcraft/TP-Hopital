using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;


namespace Hopital
{
    // Singleton Hospital.myHospital 
    public class Hospital
    {
        private  static Hospital myHospital = null;
        private Queue<int> waitingQueue = new Queue<int>();
        private List<Staff> activeStaff = new List<Staff>();


        private Hospital()
        {
            Console.WriteLine("creation de l'hopital");
        }

        public static  Hospital MyHospital
        {
            get
            {
                if (myHospital == null)
                {
                    myHospital = new Hospital();
                }
                return myHospital;
            }
        }
        // Queue de id de patient
        public Queue<int> WaitingQueue { get => waitingQueue; set => waitingQueue = value; }
        public List<Staff> ActiveStaff { get => activeStaff; set => activeStaff = value; }
    }
}
