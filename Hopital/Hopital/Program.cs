using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hopital.Model;

namespace Hopital
{
    class Program
    {
        static void Main(string[] args)
        {

            TestSelectAll();
            //TestLog
        }

        static void TestSelectAll()
        {
            List<Staff> x = new DaoStaffSqlServer().FindAll();
            foreach (Staff p in x)
                Console.WriteLine(p.Name + "login " + p.Login + "passwd " +  p.Password );
        }

        static void TestLog()
        {

            Console.WriteLine(new DaoStaffSqlServer().Login("a", ""));

        }




    }
}
