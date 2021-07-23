using ApiTestingFramework.Net.Base;
using ApiTestingFramework.Net.ServicesLogic.Entities;
using RestSharp;

namespace ApiTestingFramework.Net.Utilities
{
    public class ApiTestLogger
    {
        private readonly TestInstance testInstance;

        public ApiTestLogger(TestInstance testInstance)
        {
            this.testInstance = testInstance;
        }

        public void LogGenericIRestResponseError(GenericHttpRequestRestSharp genericHttpRequestRestSharp, IRestResponse restResponse)
        {
            testInstance.Logger.Error($"An exception has been encountered while trying to contact the requested service URL: {genericHttpRequestRestSharp.ServiceUrl}");
            testInstance.Logger.Error($"Response status: {restResponse.ResponseStatus}");
            testInstance.Logger.Error($"Response status code: {restResponse.StatusCode}");
            testInstance.Logger.Error($"Response status description: {restResponse.StatusDescription}");
            testInstance.Logger.Error($"Response content: {restResponse.Content}");
            testInstance.Logger.Error($"Response error message: {restResponse.ErrorMessage}");
            testInstance.Logger.Error($"Response error exception: {restResponse.ErrorException}");
        }
    }
}