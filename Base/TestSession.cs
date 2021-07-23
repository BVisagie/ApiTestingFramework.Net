using ApiTestingFramework.Net.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Security;

namespace ApiTestingFramework.Net.Base
{
    public class TestSession
    {
        public TestInstance SetupTest()
        {
            Logging loggingHelper = new();
            string uniqueLoggerId = loggingHelper.SetupUniqueLoggerId();

            var testInstance = new TestInstance
            {
                Logger = loggingHelper.SetupLogger(loggerId: uniqueLoggerId),
                LoggerUniqueIdentifier = uniqueLoggerId,
                EnvironmentUnderTest = TestContext.Parameters[Constants.EnvironmentUnderTest],
                EnvironmentUnderTestDomain = TestContext.Parameters[Constants.EnvironmentUnderTestDomain],
                EnvironmentUnderTestPort = TestContext.Parameters[Constants.EnvironmentUnderTestPort],
                ExampleDbServer = TestContext.Parameters[Constants.ExampleDbServer],
                ExampleDb = TestContext.Parameters[Constants.ExampleDb],
                UseSqlCredential = string.Equals(TestContext.Parameters[Constants.UseSqlCredential], "true", StringComparison.OrdinalIgnoreCase),
                MultiSubnetFailover = string.Equals(TestContext.Parameters[Constants.MultiSubnetFailover], "true", StringComparison.OrdinalIgnoreCase),
            };

            if (testInstance.UseSqlCredential)
            {
                testInstance.SqlUsername = TestContext.Parameters[Constants.SqlUsername];
                testInstance.SqlPassword = TestContext.Parameters[Constants.SqlPassword];

                SecureString theSecureString = new NetworkCredential(userName: testInstance.SqlUsername, password: testInstance.SqlPassword).SecurePassword;
                theSecureString.MakeReadOnly();

                testInstance.SqlCredential = new SqlCredential(userId: testInstance.SqlUsername, password: theSecureString);
            }

            return testInstance;
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