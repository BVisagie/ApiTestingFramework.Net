using ApiTestingFramework.Net.Base;
using ApiTestingFramework.Net.Utilities;
using Dapper;

namespace ApiTestingFramework.Net.SQL
{
    public class ExampleQueries
    {
        private readonly TestInstance testInstance;

        public ExampleQueries(TestInstance testInstance)
        {
            this.testInstance = testInstance;
        }

        public int GetRandomSomething()
        {
            const string getRandomSomethingQuery = @"
                                                   SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
                                                   SELECT TOP 1 td.[Value]
                                                   FROM TestData td
                                                   WHERE td.ClassName = 'Testing'
                                                   AND td.IsActive = 1
                                                   ORDER BY NEWID();
                                                   ";

            var newSqlConnection = new SqlHelpers(testInstance).SetupSqlConnection(server: testInstance.ExampleDbServer, db: testInstance.ExampleDb);

            using (newSqlConnection)
            {
                return newSqlConnection.ExecuteScalar<int>(getRandomSomethingQuery, commandTimeout: 60);
            }
        }
    }
}