using ApiTestingFramework.Net.Base;
using NUnit.Framework;
using Serilog;
using System;
using System.IO;

namespace ApiTestingFramework.Net.Utilities
{
    public class Logging
    {
        /// <summary>
        /// Creates a folder within bin with todays date 2021-06-09 and a unique test case log file example: rsSRR6tvMkrCJJWpfyHg.txt
        /// </summary>
        /// <returns>string</returns>
        public string SetupUniqueLoggerId()
        {
            string errorDirectoryPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName;
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            return Path.Combine(errorDirectoryPath, dateTime, new Helpers().GetRandomShortUid());
        }

        /// <summary>
        /// This method will setup and return a configured ILogger logging instance.
        /// </summary>
        /// <returns>ILogger</returns>
        public ILogger SetupLogger(string loggerId)
        {
            return new LoggerConfiguration()
                .MinimumLevel
                .Debug()
                .WriteTo
                .File($"{loggerId}.txt")
                .CreateLogger();
        }

        public void LogTestCaseException(TestInstance testInstance)
        {
            foreach (var logItem in TestContext.CurrentContext.Result.Assertions)
            {
                testInstance.Logger.Error($"Assertions.Status: {logItem.Status}");
                testInstance.Logger.Error($"Assertions.Message: {logItem.Message}");
                testInstance.Logger.Error($"Assertions.StackTrace: {logItem.StackTrace}");
            }
        }
    }
}