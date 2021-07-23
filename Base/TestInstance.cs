using Serilog;
using System.Data.SqlClient;

namespace ApiTestingFramework.Net.Base
{
    public class TestInstance
    {
        public ILogger Logger { get; set; }
        public string LoggerUniqueIdentifier { get; set; }
        public string EnvironmentUnderTest { get; set; }
        public string EnvironmentUnderTestDomain { get; set; }
        public string EnvironmentUnderTestPort { get; set; }
        public string ExampleDbServer { get; set; }
        public string ExampleDb { get; set; }
        public bool UseSqlCredential { get; set; }
        public SqlCredential SqlCredential { get; set; }
        public string SqlUsername { get; set; }
        public string SqlPassword { get; set; }
        public bool MultiSubnetFailover { get; set; }
    }
}