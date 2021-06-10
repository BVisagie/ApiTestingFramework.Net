using ApiTestingFramework.Net.ServicesLogic.Entities;
using RestSharp;

namespace ApiTestingFramework.Net.ServicesLogic
{
    public class HttpServiceInteractions
    {
        public IRestResponse HttpInteraction(GenericHttpRequestRestSharp genericHttpRequest)
        {
            var request = new RestRequest(genericHttpRequest.ServiceUrl, genericHttpRequest.HttpMethod)
            {
                Timeout = genericHttpRequest.RequestTimeout //ms
            };

            if (genericHttpRequest.RequestBody != null)
            {
                request.AddJsonBody(genericHttpRequest.RequestBody);
            }

            return new RestClient().Execute(request);
        }
    }
}