using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    public class ConsultingRoom
    {
        private int roomId;
        private string doctorId;
        private Visit currentVisit;
        private List<Visit> currentVisitList;

        public int RoomId
        {
            get { return roomId; }
        }

        public string DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        public Visit CurrentVisit
        {
            get { return currentVisit; }
            set { currentVisit = value; }
        }

        public List<Visit> CurrentVisitList
        {
            get { return currentVisitList; }
            set { currentVisitList = value; }
        }

        public ConsultingRoom(int room_id)
        {
            this.roomId = room_id;
            CurrentVisitList = new List<Visit>();
        }

        public override string ToString()
        {
            return "ConsultingRoom number : " +RoomId;
        }

        public bool CreateCurrentVisit()
        {
            if(Hospital.MyHospital.WaitingQueue.Raw.Count > 0)
            {
                int waitSec = (int)Hospital.MyHospital.WaitingQueue.TimeSinceNow().TotalSeconds;
                int newPatient = Hospital.MyHospital.DequeuePatient();
                Visit newV = new Visit(newPatient, waitSec, DoctorId, DateTime.Now, RoomId);
                CurrentVisit = newV;
                CurrentVisitList.Add(CurrentVisit);

                if (CurrentVisitList.Count == 5)
                {
                    SaveCurrentVisitList();
                }

                Console.WriteLine(CurrentVisit.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetCurrentVisitList()
        {
            foreach (Visit v in CurrentVisitList)
            {
                Console.WriteLine(v.ToString());
            }
        }

        public void SaveCurrentVisitList()
        {
            IDaoVisite x = new DaoVisitSqlServer();
            foreach (Visit v in CurrentVisitList)
            {
                x.Create(v);
            }
            currentVisitList.Clear();
        }
    }
}
