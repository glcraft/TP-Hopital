using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    class ConsultingRoom
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
    }
}
