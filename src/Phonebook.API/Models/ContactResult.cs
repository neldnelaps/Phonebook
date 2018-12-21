using System.Collections.Generic;

using Newtonsoft.Json;

namespace Phonebook.API.Models
{
    public class ContactResult
    {
        [JsonProperty("results")]
        public List<Contact> Contacts { get; set; }
    }
}
