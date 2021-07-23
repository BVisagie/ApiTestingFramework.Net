using ApiTestingFramework.Net.Base;
using NUnit.Framework;
using System.Data.SqlClient;

namespace ApiTestingFramework.Net.Utilities
{
    public class SqlHelpers
    {
        private readonly TestInstance testInstance;

        public SqlHelpers(TestInstance testInstance)
        {
            this.testInstance = testInstance;
        }

        public SqlConnection SetupSqlConnection(string server, string db)
        {
            string dbConnectionString;
            bool integratedSecurity;

            if (testInstance.UseSqlCredential)
            {
                integratedSecurity = false;
            }
            else
            {
                integratedSecurity = true;
            }

            dbConnectionString = $"Server={TestContext.Parameters[server]};Database={TestContext.Parameters[db]};Integrated Security={integratedSecurity};MultiSubnetFailover={testInstance.MultiSubnetFailover};";

            testInstance.Logger.Debug($"DB Connection string created as: {dbConnectionString}");

            if (testInstance.UseSqlCredential)
            {
                return new SqlConnection(connectionString: dbConnectionString, credential: testInstance.SqlCredential);
            }
            else
            {
                return new SqlConnection(connectionString: dbConnectionString);
            }
        }
    }
}