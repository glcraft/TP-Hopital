using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    class ConsultingRoom
    {
        private int room_id;
        private string doctor_id;
        private Visit currentVisit;
        private List<Visit> currentVisitList;

        public int Room_id
        {
            get { return room_id; }
        }

        public string Doctor_id
        {
            get { return doctor_id; }
            set { doctor_id = value; }
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
            this.room_id = room_id;
        }
    }
}
