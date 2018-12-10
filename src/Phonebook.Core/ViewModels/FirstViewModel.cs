using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using Phonebook.API.Service;

using System.Linq;
using System;

namespace Phonebook.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private string _text = "Нажми меня";
        private readonly int count = 10;
        private int page = 1;

        readonly IContactService СontactService;

        public FirstViewModel(IContactService contactService)
        {
            СontactService = contactService;
        }

        private async void ResetText()
        {
            await GettingContacts();
        }

        private async Task GettingContacts()
        {
            try
            {
                var result = await СontactService.GetContacts(count, page).ConfigureAwait(false);
                page++;
                string strContacts = "";
                foreach (var item in result.Contacts)
                {
                    strContacts += $"{item.Name.Last.ToString()} {item.Name.First}\n";
                }
                Text = strContacts;
            }
            catch (Exception ex)
            {
                Text = ex.Message;
            }
        }

        private async Task<API.Models.ContactResult> GetContacts()
        {
            var listContact = await СontactService.GetContacts(10, 1);
            return listContact;
        }


        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}