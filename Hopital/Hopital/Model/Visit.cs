using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    class Visit
    {
        private int id;
        private int patient_id;
        private string doctor_id;
        private DateTime date;
        private int room_id;
        private int fee;

        public int Id
        {
            get { return id; }
        }

        public int Patient_id
        {
            get { return patient_id; }
        }

        public string Doctor_id
        {
            get { return doctor_id; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public int Room_id
        {
            get { return room_id; }
        }

        public int Fee
        {
            get { return fee; }
        }

        public Visit()
        { }

        public Visit(int id, int patient_id, string doctor_id, DateTime date, int room_id, int fee) //constructeur de recuperation
        {
            this.id = id;
            this.patient_id = patient_id;
            this.doctor_id = doctor_id;
            this.date = date;
            this.room_id = room_id;
            this.fee = fee;
        }
        public Visit(int patient_id, string doctor_id, DateTime date, int room_id, int fee) //constructeur de creation avec l'auto incremente de l'id
        {
            this.patient_id = patient_id;
            this.doctor_id = doctor_id;
            this.date = date;
            this.room_id = room_id;
            this.fee = fee;
        }

        public override string ToString()
        {
            return "Visit - ID : " +Id+ "\tPatient ID : " +Patient_id+ "\tDoctor ID : " +Doctor_id+ "\tDate : " +Date+ "\tRoom ID : " +Room_id+ "\tFee : " +Fee;
        }
    }
}
