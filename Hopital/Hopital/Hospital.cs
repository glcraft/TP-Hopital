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
        public Queue<int> WaitingQueue { get; }
        public List<Staff> ActiveStaff { get; }
    }
}
