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
            string sql = "INSERT INTO Visits OUTPUT INSERTED.ID values (@patient_id, @doctor_id, @date, @room_id, @fee)";

            SqlConnection connection = SqlServer.Get().Connection;
            SqlCommand command = connection.CreateCommand();

            command.CommandText = sql;
            command.Parameters.Add("patient_id", SqlDbType.Int).Value = v.PatientId;
            command.Parameters.Add("doctor_id", SqlDbType.NVarChar).Value = v.DoctorId;
            command.Parameters.Add("date", SqlDbType.DateTime).Value = v.Date;
            command.Parameters.Add("room_id", SqlDbType.Int).Value = v.RoomId;
            command.Parameters.Add("fee", SqlDbType.Int).Value = v.Fee ;

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
                Visit newV = new Visit(
                    (int)reader["id"],
                    (int)reader["patient_id"],
                    (int)reader["wait_time"],
                    (string)reader["doctor_id"],
                    (DateTime)reader["id"],
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
                Visit newV = new Visit(
                    (int)reader["id"],
                    (int)reader["patient_id"],
                    (int)reader["wait_time"],
                    (string)reader["doctor_id"],
                    (DateTime)reader["id"],
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
