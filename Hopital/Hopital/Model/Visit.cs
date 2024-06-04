﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
    class Visit
    {
        private int id;
        private int patientId;
        private string doctorId;
        private DateTime date;
        private int roomId;
        private const int fee = 23; //prix fixe pour l'instant

        public int Id
        {
            get { return id; }
        }

        public int PatientId
        {
            get { return patientId; }
        }

        public string DoctorId
        {
            get { return doctorId; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public int RoomId
        {
            get { return roomId; }
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
            this.patientId = patient_id;
            this.doctorId = doctor_id;
            this.date = date;
            this.roomId = room_id;
        }
        public Visit(int patient_id, string doctor_id, DateTime date, int room_id) //constructeur de creation avec l'auto incremente de l'id
        {
            this.patientId = patient_id;
            this.doctorId = doctor_id;
            this.date = date;
            this.roomId = room_id;
        }

        public override string ToString()
        {
            return "Visit - ID : " +Id+ "\tPatient ID : " +PatientId+ "\tDoctor ID : " +DoctorId+ "\tDate : " +Date+ "\tRoom ID : " +RoomId+ "\tFee : " +Fee;
        }
    }
}
