using ApiTestingFramework.Net.Base;
using ApiTestingFramework.Net.SQL;
using NUnit.Framework;

namespace ApiTestingFramework.Net.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]
    public class ExampleTests
    {
        private TestInstance testInstance;

        [TearDown]
        protected void Cleanup()
        {
            new TestSession().TeardownLogic(testInstance);
        }

        [TestCase(TestName = "[TestAreaAbc] Random data test")]
        [Description("[12345] - The purpose of this test case is to check that the values returned on a fully randomised xyz can pass validation.")]
        [Category("[TestAreaAbc] Regression Test Pack")]
        public void FullRandomCarRequestValidation()
        {
            testInstance = new TestSession().SetupTest();
            string targetEndpoint = $"https://{testInstance.EnvironmentUnderTest}.{testInstance.EnvironmentUnderTestDomain}:{testInstance.EnvironmentUnderTestPort}/Api/FunctionAbc";
            var someRandomData = new ExampleQueries(testInstance).GetRandomSomething();
        }
    }
}