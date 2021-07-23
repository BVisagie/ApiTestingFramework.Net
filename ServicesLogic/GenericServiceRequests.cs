using ApiTestingFramework.Net.Base;
using ApiTestingFramework.Net.ServicesLogic.Entities;
using ApiTestingFramework.Net.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace ApiTestingFramework.Net.ServicesLogic
{
    public class GenericServiceRequests
    {
        private readonly TestInstance testInstance;

        public GenericServiceRequests(TestInstance testInstance)
        {
            this.testInstance = testInstance;
        }

        public T CallTargetServiceWithARequestAndDeserializeResponse<T>(string targetEndpoint, object requestObject = null, Method httpMethod = Method.POST)
        {
            testInstance.Logger.Debug("Target Endpoint: {TargetEndpoint}", targetEndpoint);
            testInstance.Logger.Debug("Request: {@RequestObject}", requestObject);

            var request = new GenericHttpRequestRestSharp
            {
                ServiceUrl = targetEndpoint,
                HttpMethod = httpMethod
            };

            if (requestObject != null)
            {
                request.RequestBody = requestObject;
            }

            IRestResponse response = new HttpServiceInteractions().HttpInteraction(request);

            if (response.IsSuccessful)
            {
                var deserializedResponse = JsonConvert.DeserializeObject<T>(response.Content);
                testInstance.Logger.Debug("Response: {@DeserializeResponse}", deserializedResponse);

                return deserializedResponse;
            }
            else
            {
                new ApiTestLogger(testInstance).LogGenericIRestResponseError(request, restResponse: response);
                return default;
            }
        }

        public List<T> CallTargetServiceWithARequestAndDeserializeResponseAsList<T>(string targetEndpoint, object requestObject = null, Method httpMethod = Method.POST)
        {
            testInstance.Logger.Debug("Target Endpoint: {TargetEndpoint}", targetEndpoint);
            testInstance.Logger.Debug("Request: {@RequestObject}", requestObject);

            var request = new GenericHttpRequestRestSharp
            {
                ServiceUrl = targetEndpoint,
                HttpMethod = httpMethod
            };

            if (requestObject != null)
            {
                request.RequestBody = requestObject;
            }

            IRestResponse response = new HttpServiceInteractions().HttpInteraction(request);

            if (response.IsSuccessful)
            {
                var deserializedResponse = JsonConvert.DeserializeObject<List<T>>(response.Content);
                testInstance.Logger.Debug("Response: {@DeserializeResponse}", deserializedResponse);

                return deserializedResponse;
            }
            else
            {
                new ApiTestLogger(testInstance).LogGenericIRestResponseError(request, restResponse: response);
                return default;
            }
        }
    }
}