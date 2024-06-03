using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hopital.Utils
{
    class FakeEnvironment
    {
        private static Dictionary<string, string> fakeEnv;
        private static void Init()
        {
            if (fakeEnv != null)
                return;
            fakeEnv = new Dictionary<string, string>();
            try
            {
                string content = File.ReadAllText(".env");
                foreach (string line in content.Split('\n'))
                {
                    string[] splitted = line.Split('=');
                    if (splitted.Length < 2)
                        continue;
                    fakeEnv[splitted[0]] = string.Join("=", splitted.Skip(1));
                }
            } 
            catch
            { }
        }
        public static string GetEnvVar(string variable)
        {
            Init();
            string envVar = null;
            if (fakeEnv != null)
                envVar = fakeEnv[variable];
            if (envVar != null)
                return envVar;
            envVar = Environment.GetEnvironmentVariable(variable);
            return envVar;
        }
    }
}
