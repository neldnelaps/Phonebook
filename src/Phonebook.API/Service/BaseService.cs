using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace Phonebook.API.Service
{
    public abstract class BaseService
    {
        private IConnectionService ConnectionService { get; }

        protected BaseService(IConnectionService connectionService) => ConnectionService = connectionService;
        
        
        protected async Task<T> ParseResult<T>(ServerResponse response)
        {
            return response.HttpStatusCode == HttpStatusCode.OK ?
                Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.HttpContent.ReadAsStringAsync()) :
                default(T);
        }

        protected virtual async Task<T> Get<T>(string url) where T : class, new()
        {
            return await ParseResult<T>(await ConnectionService.Get(url));
        }

        protected virtual async Task<T> Post<T>(string url, HttpContent httpContentPost) where T : class, new()
        {
            return await ParseResult<T>(await ConnectionService.Post(url, httpContentPost));
        }

    }
}
