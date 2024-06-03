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
                string login = reader.GetString(0); // Supposons que le login est à l'index 1
                string password = reader.GetString(1); // Supposons que le mot de passe est à l'index 2
                string name = reader.GetString(2); // Supposons que le Nom est à l'index 3
                int job = reader.GetInt32(3); // Supposons que le job est à l'index 4

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
                    staffMember = new Doctor(login, password, name, job);
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

        public List<Staff> FindByNom(string nom)
        {
            throw new NotImplementedException();
        }

        public void Update(Staff obj)
        {
            throw new NotImplementedException();
        }
    }
}
