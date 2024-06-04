using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Hopital.Utils;

namespace Hopital.Model
{
    class SqlServer
    {
        private static SqlServer This;
        private SqlServer()
        {
            string connectionString = FakeEnvironment.GetEnvVar("SQL_PROPERTIES");
            //Console.WriteLine("connectionString: {0}", connectionString);
            if (connectionString == null)
                throw new EnvVarNotDefinedException("SQL_PROPERTIES");
            Connection = new SqlConnection(connectionString);
        }
        public static SqlServer Get()
        {
            if (This == null)
                This = new SqlServer();
            return This;
        }
        public SqlConnection Connection { get; internal set; }
    }
}
