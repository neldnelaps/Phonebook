﻿using Newtonsoft.Json;

namespace Phonebook.API.Models
{
    public class Contact
    {
        public Name Name { get; set; }

        [JsonProperty("picture")]
        public Picture Image { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
