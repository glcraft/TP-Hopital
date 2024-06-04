using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hopital.Model
{
   public class Staff
    {
        private string login;
        private string password;
        private string name;
        private int job;

        public Staff(string login, string password, string name, int job)
        {
            this.login = login;
            this.password = password;
            this.name = name;
            this.job = job;
        }
        public Staff( )
        {
       

        }

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public int Job { get => job; set => job = value; }

        public override string ToString()
        {
            return $"Log : {login}, Pwd : {password}, name : {name}";
        }

    }
}
