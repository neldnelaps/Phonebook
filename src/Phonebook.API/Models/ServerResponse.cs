using System.Net;
using System.Net.Http;

namespace Phonebook.API.Service
{
    public class ServerResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public HttpContent HttpContent { get; set; }
        public string Url { get; set; }
    }
}
