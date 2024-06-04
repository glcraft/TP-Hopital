using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
            ActiveStaff = new List<Staff>();
            WaitingQueue = new Queue<int>();
            ConsultingRooms = new List<ConsultingRoom>();

            List<int> listeI = new DaoStaffSqlServer().ListOfRoomNumber();
            //Console.WriteLine(listeI.Count);
            for (int i = 0; i < new DaoStaffSqlServer().NumberOfRoom(); i++)
            {
                ConsultingRoom newCR = new ConsultingRoom(listeI[i]);
                //Console.WriteLine(newCR.ToString());
                ConsultingRooms.Add(newCR);
            }
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

        public void AddPatientToQueue(int patient_id)
        {
            DateTime now = DateTime.Now;

            using (StreamWriter file = File.AppendText("patients_log.txt"))
            {
                file.WriteLine($"{patient_id},{now.ToShortDateString()},{now.ToLongTimeString()}");
            }
            WaitingQueue.Enqueue(patient_id);
        }
        // Queue de id de patient
        public Queue<int> WaitingQueue { get; }
        public List<Staff> ActiveStaff { get; }

        public List<ConsultingRoom> ConsultingRooms { get; }
    }
}

