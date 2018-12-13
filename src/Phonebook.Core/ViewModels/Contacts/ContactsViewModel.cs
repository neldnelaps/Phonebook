using MvvmCross.Commands;
using MvvmCross.ViewModels;

using System;
using System.Threading.Tasks;

using Phonebook.API.Service;
using MvvmCross;
using Phonebook.Core.Dialog;
using Phonebook.Core.ViewModels.Item;

namespace Phonebook.Core.ViewModels.Contacts
{
    public class ContactsViewModel : MvxViewModel
    {
        private readonly int _count = 10;
        private int _page = 1;

        private IMvxCommand _refreshCommand;
        public IMvxCommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(UpdateContacts));

        private IMvxCommand _gettingCommand;
        public IMvxCommand GettingContactsCommand => _gettingCommand ?? (_gettingCommand = new MvxAsyncCommand(GettingContacts));

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value); 
        }

        private MvxObservableCollection<Item.ItemContact> _items;
        public MvxObservableCollection<Item.ItemContact> Items
        {
            get => _items; 
            set => SetProperty(ref _items, value); 
        }

        private readonly IContactService _contactService;   
        public ContactsViewModel(IContactService contactService)
        {
            _contactService = contactService;
            Items = new MvxObservableCollection<ItemContact>();
        }

        private async Task UpdateContacts()
        {
            IsRefreshing = true;
            _page = 1;
            Items.Clear();
            await GettingContacts();
            IsRefreshing = false;      
        }

        private async Task GettingContacts()
        {
            try
            {
                var result = await _contactService.GetContacts(_count, _page).ConfigureAwait(false);
                if (result == null)
                    Mvx.IoCProvider.Resolve<IUserDialogs>().Alert("Contact list is empty!");
                _page++;
                var list = new MvxObservableCollection<ItemContact>();
                foreach (var contact in result.Contacts)
                    list.Add(new ItemContact(contact));
                Items.AddRange(list);
            }
            catch (Exception ex)
            {
                Mvx.IoCProvider.Resolve<IUserDialogs>().Alert(ex.Message);
            }
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            if (Items.Count == 0)
                Task.Run(GettingContacts);
        }
    }
}