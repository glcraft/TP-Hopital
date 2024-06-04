using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hopital.Model
{
    class DaoPatientSqlServer : IDaoPatient
    {
        public void Create(Patient patient)
        {
            SqlConnection connection = SqlServer.Get().Connection;
            SqlCommand command = new SqlCommand("INSERT INTO Patients (firstname, lastname, address, age, phoneNumber) VALUES(@firstname, @lastname, @address, @age, @phoneNumber)", connection);
            command.Parameters.AddWithValue("firstname", patient.Firstname);
            command.Parameters.AddWithValue("lastname", patient.Lastname);
            command.Parameters.AddWithValue("address", patient.Address);
            command.Parameters.AddWithValue("age", patient.Age);
            command.Parameters.AddWithValue("phoneNumber", patient.PhoneNumber);
            connection.Open();
            // execution de la requete
            command.ExecuteNonQuery();
            // Console.WriteLine(sql);
            connection.Close();
        }

        public void Delete(int id)
        {
            SqlConnection connection = SqlServer.Get().Connection;
            SqlCommand command = new SqlCommand("DELETE FROM Patients WHERE id=@id", connection);
            command.Parameters.AddWithValue("id", id);
            connection.Open();
            // execution de la requete
            command.ExecuteNonQuery();

            connection.Close();
        }

        public List<Patient> FindAll()
        {
            List<Patient> resp = new List<Patient>();
            SqlConnection connection = SqlServer.Get().Connection;

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Patients";

            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
                resp.Add(new Patient(
                    (int)reader["id"],
                    (string)reader["firstname"],
                    (string)reader["lastname"],
                    (string)reader["address"],
                    (int)reader["age"],
                    (string)reader["phoneNumber"]
                ));

            connection.Close();
            return resp;
        }

        public Patient FindById(int id)
        {
            Patient p = null;
            SqlConnection connection = SqlServer.Get().Connection;
            SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Patients WHERE id=@id", connection);
            command.Parameters.AddWithValue("id", id);
            connection.Open();
            // execution de la requete
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                p = new Patient(
                    (int)reader["id"], 
                    (string)reader["firstname"],
                    (string)reader["lastname"],
                    (string)reader["address"],
                    (int)reader["age"],
                    (string)reader["phoneNumber"]
                );
            connection.Close();
            return p;
        }

        public void Update(Patient patient)
        {
            SqlConnection connection = SqlServer.Get().Connection;
            SqlCommand command = new SqlCommand("UPDATE Patients SET firstname=@firstname, lastname=@lastname, address=@address, age=@age, phoneNumber=@phoneNumber WHERE id=@id", connection);
            command.Parameters.AddWithValue("id", patient.Id);
            command.Parameters.AddWithValue("firstname", patient.Firstname);
            command.Parameters.AddWithValue("lastname", patient.Lastname);
            command.Parameters.AddWithValue("address", patient.Address);
            command.Parameters.AddWithValue("age", patient.Age);
            command.Parameters.AddWithValue("phoneNumber", patient.PhoneNumber);
            connection.Open();
            // execution de la requete
            command.ExecuteNonQuery();
            // Console.WriteLine(sql);

            connection.Close();
        }
    }
}
