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
            //TestCreateVisit();
            //TestDeleteVisit();
            //TestFindByDoctorID();
            TestFindByPatientID();
        }

        static void TestCreateVisit()
        {
            DaoVisite x = new DaoVisitSqlServer();
            x.Create(new Visit(1, "123456", DateTime.Now, 1, 25));
        }

        static void TestDeleteVisit()
        {
            DaoVisite x = new DaoVisitSqlServer();
            x.Delete(1);
        }

        static void TestFindByDoctorID()
        {
            DaoVisite x = new DaoVisitSqlServer();
            List<Visit> listV = x.FindByDoctorID("123456");
            foreach (Visit v in listV)
            {
                Console.WriteLine(v);
            }
        }
        static void TestFindByPatientID()
        {
            DaoVisite x = new DaoVisitSqlServer();
            List<Visit> listV = x.FindByPatientID(1);
            foreach (Visit v in listV)
            {
                Console.WriteLine(v);
            }
        }

    }
}
