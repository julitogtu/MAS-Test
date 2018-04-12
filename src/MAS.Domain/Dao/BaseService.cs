using RestSharp;

namespace MAS.Domain.Services
{
    public abstract class BaseService
    {
        internal RestClient CreateRestClient(string baseUrl) => new RestClient(baseUrl);

        internal RestRequest CreateRestRequest(string endpoint, Method method) => new RestRequest(endpoint, method);
    }
}