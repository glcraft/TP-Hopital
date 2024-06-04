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

        public int Room_id
        {
            get { return roomId; }
        }

        public string Doctor_id
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
        }

        public ConsultingRoom(int room_id)
        {
            this.roomId = room_id;
        }

        public override string ToString()
        {
            return "ConsultingRoom number : " +Room_id;
        }

        public bool CreateCurrentVisit()
        {
            Visit newV = new Visit(Hospital.MyHospital.WaitingQueue.Peek(), Doctor_id, DateTime.Now, Room_id);
            CurrentVisit = newV;
            CurrentVisitList.Add(CurrentVisit);
            Console.WriteLine(CurrentVisit.ToString());
            return true;
        }
    }
}
