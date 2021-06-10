using ApiTestingFramework.Net.Base;
using Dapper;
using System.Data.SqlClient;

namespace ApiTestingFramework.Net.SQL
{
    public class ExampleQueries
    {
        private readonly TestInstance testInstance;

        public ExampleQueries(TestInstance testInstance)
        {
            this.testInstance = testInstance;
        }

        public string GetConnectionString(string server, string db)
        {
            return $"Server={server};Database={db};Integrated Security=True;";
        }

        public int GetRandomSomething()
        {
            string dbConnectionString = GetConnectionString(testInstance.ExampleDbServer, testInstance.ExampleDb);

            const string getRandomSomethingQuery = @"
                                                   SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
                                                   SELECT TOP 1 td.[Value]
                                                   FROM TestData td
                                                   WHERE td.ClassName = 'Testing'
                                                   AND td.IsActive = 1
                                                   ORDER BY NEWID();
                                                   ";

            using var connection = new SqlConnection(dbConnectionString);

            return connection.ExecuteScalar<int>(getRandomSomethingQuery, commandTimeout: 60);
        }
    }
}