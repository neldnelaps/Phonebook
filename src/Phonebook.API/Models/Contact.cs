using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.API.Models
{
    internal class Contact
    {
        private Name Name { get; set; }
        private Picture Image { get; set; }
        private string Phone { get; set; }
        private string Email { get; set; }
    }
}
