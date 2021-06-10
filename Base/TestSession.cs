using ApiTestingFramework.Net.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace ApiTestingFramework.Net.Base
{
    public class TestSession
    {
        public TestInstance SetupTest()
        {
            Logging loggingHelper = new();
            string uniqueLoggerId = loggingHelper.SetupUniqueLoggerId();

            return new TestInstance
            {
                Logger = loggingHelper.SetupLogger(loggerId: uniqueLoggerId),
                LoggerUniqueIdentifier = uniqueLoggerId,
                EnvironmentUnderTest = TestContext.Parameters[Constants.EnvironmentUnderTest],
                EnvironmentUnderTestDomain = TestContext.Parameters[Constants.EnvironmentUnderTestDomain],
                EnvironmentUnderTestPort = TestContext.Parameters[Constants.EnvironmentUnderTestPort],
                ExampleDbServer = TestContext.Parameters[Constants.ExampleDbServer],
                ExampleDb = TestContext.Parameters[Constants.ExampleDb],
            };
        }

        public void TeardownLogic(TestInstance testInstance)
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success && TestContext.CurrentContext.Result.Outcome != ResultState.Inconclusive)
            {
                new Logging().LogTestCaseException(testInstance);
            }

            if (testInstance != null)
            {
                AttachCurrentTestLogFile(testInstance);
            }
        }

        private void AttachCurrentTestLogFile(TestInstance testInstance)
        {
            TestContext.AddTestAttachment($"{testInstance.LoggerUniqueIdentifier}.txt");
        }
    }
}