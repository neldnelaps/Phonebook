using System.Threading.Tasks;

using Phonebook.API.Models;

namespace Phonebook.API.Service
{
    public class ContactService : BaseService, IContactService
    {
        public ContactService(IConnectionService connectionService) : base(connectionService) { }

        Task<ContactResult> IContactService.GetContacts(int count, int page) => Get<ContactResult>($"{Constants.Url}?results={count}&page={page}");
    }
}
