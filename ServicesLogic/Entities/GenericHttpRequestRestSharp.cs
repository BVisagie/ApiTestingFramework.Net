using RestSharp;

namespace ApiTestingFramework.Net.ServicesLogic.Entities
{
    public class GenericHttpRequestRestSharp
    {
        public string ServiceUrl { get; set; }
        public Method HttpMethod { get; set; }
        public int RequestTimeout { get; set; } = 12000; //ms
        public object RequestBody { get; set; }
    }
}