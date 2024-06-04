using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace Hopital.Model
{
    class DaoStaffSqlServer : IDaoStaff
    {
        SqlConnection connection = SqlServer.Get().Connection;

        public string Create(Staff obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Staff> FindAll()
        {
            List<Staff> staffList = new List<Staff>();

            string sql = "select * from Staffs";

          //  SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                string login = reader.GetString(0);  
                string password = reader.GetString(1);  
                string name = reader.GetString(2);  
                int job = reader.GetInt32(3);  

                Staff staffMember = null;

                if (job >= 1)  
                {
                    staffMember = new Doctor(login, password, name, job);
                }
                else if (job == 0)  
                {
                    staffMember = new Secretary(login, password, name, job);
                }
                else if (job == -1)
                {
                    continue;
                   // staffMember = new Doctor(login, password, name, job);
                }

                staffList.Add(staffMember);
            }
            connection.Close();
            return staffList;
        }
 
        public Staff FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Staff obj)
        {
            throw new NotImplementedException();
        }

        public Staff Login(string loginToFind, string passwordToFind)
        {
           
            Staff user = null;

            string sql = "SELECT TOP 1 * FROM Staffs WHERE login = @login AND password = @password";

            //SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.Parameters.AddWithValue("@login", loginToFind);
            command.Parameters.AddWithValue("@password", passwordToFind);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string login = reader.GetString(0);
                string password = reader.GetString(1);
                string name = reader.GetString(2);
                int job = reader.GetInt32(3);
                if (job >= 1)
                {
                   user = new Doctor(login, password, name, job);
                }
                else if (job == 0)
                {
                    user = new Secretary(login, password, name, job);
                }
                else if (job == -1)
                {
                    // staffMember = new Doctor(login, password, name, job);
                }

            }
            connection.Close();
            return user;
        }

        public int NumberOfRoom()
        {
            string sql = "SELECT COUNT(DISTINCT job) FROM Staffs WHERE job > 0";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            int nbRoom = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return nbRoom;
        }

        public List<int> ListOfRoomNumber()
        {
            List<int> listI = new List<int>();

            string sql = "SELECT DISTINCT job FROM Staffs WHERE job > 0";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                int newI = reader.GetInt32(0);
                listI.Add(newI);
            }
            connection.Close();
            return listI;
        }
    }
}
