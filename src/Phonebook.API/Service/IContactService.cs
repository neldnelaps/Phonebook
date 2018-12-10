using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Phonebook.API.Models;

namespace Phonebook.API.Service
{
    public interface IContactService
    {
        Task<ContactResult> GetContacts(int count, int page);
    }
}
