using Serilog;

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
    }
}