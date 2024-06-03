using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace Hopital.Model
{
    class DaoStaffSqlServer : IDaoStaff
    {
        private string connectionString = @"Data Source=ENVY\SQLEXPRESS;Initial Catalog=Hopital-tp1;Integrated Security=True";
       // SqlConnection connection = new SqlConnection(connectionString);

        public void Create(Staff obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Staff> FindAll()
        {
            List<Staff> staffList = new List<Staff>();

            string sql = "select * from Staffs";

            SqlConnection connection = new SqlConnection(connectionString);
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
 
        public Staff FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Staff obj)
        {
            throw new NotImplementedException();
        }

        public Staff Login(string loginToFind, string passwordToFind)
        {
           
            Staff user = new Staff();

            string sql = "SELECT * FROM Staffs WHERE login = @login AND password = @password";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            command.Parameters.AddWithValue("@login", loginToFind);
            command.Parameters.AddWithValue("@password", passwordToFind);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
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
                    continue;
                    // staffMember = new Doctor(login, password, name, job);
                }

            }
            connection.Close();
            return user;
        }


    }
}
