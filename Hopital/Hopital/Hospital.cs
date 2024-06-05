using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Hopital.Model;


namespace Hopital
{
    public class QueueTimed<T>
    {
        private Queue<Item> queue;
        public class Item
        {
            public T value;
            public DateTime time;
        }
        public QueueTimed()
        {
            queue = new Queue<Item>();
        }
        public Queue<Item> Raw { get => queue; }
        public void Enqueue(T value)
        {
            queue.Enqueue(new Item{ value = value, time = DateTime.Now });
        }

        public T Peek()
        {
            return queue.Peek().value;
        }
        public DateTime PeekTime()
        {
            return queue.Peek().time;
        }
        public T Dequeue()
        {
            return queue.Dequeue().value;
        } 
        public TimeSpan TimeSinceNow()
        {
            return DateTime.Now - PeekTime();
        }

    }
    
    // Singleton Hospital.myHospital 
    public class Hospital
    {
        private  static Hospital myHospital = null;

        private Hospital()
        {
            Console.WriteLine("creation de l'hopital");
            ActiveStaff = new List<Staff>();
            WaitingQueue = new QueueTimed<int>();
            ConsultingRooms = new List<ConsultingRoom>();

            List<int> listeI = new DaoStaffSqlServer().ListOfRoomNumber();
            //Console.WriteLine(listeI.Count);
            for (int i = 0; i < listeI.Count; i++)
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
        public QueueTimed<int> WaitingQueue { get; }
        public List<Staff> ActiveStaff { get; }

        public List<ConsultingRoom> ConsultingRooms { get; }
    }
}

