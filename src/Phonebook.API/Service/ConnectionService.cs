using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phonebook.API.Service
{
    public class ConnectionService : IConnectionService
    {
        private Lazy<HttpClient> HttpClient;

        public ConnectionService(HttpMessageHandler httpMessageHandler)
        {
            HttpClient = new Lazy<HttpClient>(() => new HttpClient(httpMessageHandler));
        }

        public Task<ServerResponse> Get(string url)
        {
            return SendAsync(url);
        }

        public Task<ServerResponse> Post(string url, HttpContent httpContent)
        {
            return SendAsync(url, httpContent);
        }

        private async Task<ServerResponse> SendAsync(string url, HttpContent httpContent = null)
        {
            using (var httpRequestMessage = new HttpRequestMessage(httpContent == null ? HttpMethod.Get : HttpMethod.Post, url) { Content = httpContent })
            {
                var answer = await HttpClient.Value.SendAsync(httpRequestMessage).ConfigureAwait(false); ;
                return new ServerResponse
                {
                    HttpStatusCode = answer.StatusCode,
                    HttpContent = answer.Content,
                    Url = url
                };
            }
        }
    }
}
