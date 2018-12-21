using System.Net.Http;
using System.Threading.Tasks;

namespace Phonebook.API.Service
{
    public interface IConnectionService
    {
        Task<ServerResponse> Get(string url);
        Task<ServerResponse> Post(string url, HttpContent httpContent);
    }
}
