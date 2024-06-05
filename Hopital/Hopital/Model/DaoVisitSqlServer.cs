using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hopital.Model
{
    class DaoVisitSqlServer : IDaoVisite
    {
        public int Create(Visit v)
        {
            string sql = "INSERT INTO Visits (patient_id, doctor_id, date, room_id, fee, wait_time) OUTPUT INSERTED.id VALUES(@patient_id, @doctor_id, @date, @room_id, @fee, @wait_time)";

            SqlConnection connection = SqlServer.Get().Connection;
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("patient_id", v.PatientId);
            command.Parameters.AddWithValue("doctor_id", v.DoctorId);
            command.Parameters.AddWithValue("date", v.Date);
            command.Parameters.AddWithValue("room_id", v.RoomId);
            command.Parameters.AddWithValue("fee", v.Fee) ;
            command.Parameters.AddWithValue("wait_time", v.WaitTime);

            connection.Open();
            int id = (int)command.ExecuteScalar();
            //Console.WriteLine("Insertion of a visit in the database.");
            connection.Close();
            return id;
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Visits WHERE id = " + id;

            SqlConnection connection = SqlServer.Get().Connection;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sql;

            connection.Open();

            int nb = command.ExecuteNonQuery();
            //if (nb > 0)
            //{
            //    Console.WriteLine("Suppression of visit in the database ID : " + id);
            //}

            connection.Close();
        }

        public List<Visit> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Visit> FindByDoctorID(string id_doct)
        {
            List<Visit> listeV = new List<Visit>();

            SqlConnection connection = SqlServer.Get().Connection;
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Visits WHERE doctor_id = @id_doct";
            command.Parameters.AddWithValue("id_doct", id_doct);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //Console.WriteLine("Search visits with doctor ID : " + id_doct);
            while (reader.Read())
            {
                int? waitTime = null;
                if (!reader.IsDBNull(reader.GetOrdinal("wait_time")))
                    waitTime = (int)reader["wait_time"];
                Visit newV = new Visit(
                    (int)reader["id"],
                    (int)reader["patient_id"],
                    waitTime,
                    (string)reader["doctor_id"],
                    (DateTime)reader["date"],
                    (int)reader["room_id"],
                    (int)reader["fee"]
                );
                listeV.Add(newV);
            }
            connection.Close();

            return listeV;
        }

        public Visit FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Visit> FindByPatientID(int id_pat)
        {
            List<Visit> listeV = new List<Visit>();

            SqlConnection connection = SqlServer.Get().Connection;
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Visits WHERE patient_id = @id_pat";
            command.Parameters.AddWithValue("id_pat", id_pat);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //Console.WriteLine("Search visits with patient ID : " + id_pat);
            
            while (reader.Read()) 
            {
                int? waitTime = null;
                if (!reader.IsDBNull(reader.GetOrdinal("wait_time")))
                    waitTime = (int)reader["wait_time"];
                Visit newV = new Visit(
                    (int)reader["id"],
                    (int)reader["patient_id"],
                    waitTime,
                    (string)reader["doctor_id"],
                    (DateTime)reader["date"],
                    (int)reader["room_id"],
                    (int)reader["fee"]
                );
                listeV.Add(newV);
            }
            connection.Close();

            return listeV;
        }

        public void Update(Visit v)
        {
            throw new NotImplementedException();
        }
    }
}
