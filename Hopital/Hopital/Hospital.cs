using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hopital
{
    public class Hospital
    {
        private  static Hospital myHospital = null;
        private Queue<int> waitingQueue = new Queue<int>();

        private Hospital()
        {
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

        public Queue<int> WaitingQueue { get => waitingQueue; set => waitingQueue = value; }
    }
}
