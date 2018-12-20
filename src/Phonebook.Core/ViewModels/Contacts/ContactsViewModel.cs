using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

using System;
using System.Threading.Tasks;

using Phonebook.API.Service;
using Phonebook.Core.Dialog;
using Phonebook.Core.ViewModels.Item;
using MvvmCross.Navigation;
using Phonebook.Core.ViewModels.Contact;

namespace Phonebook.Core.ViewModels.Contacts
{
    public class ContactsViewModel : MvxViewModel
    {
        #region Fields
        private readonly int _count = 10;
        private int _page = 1;
        #endregion

        #region Commands
        private IMvxCommand _refreshCommand;
        public IMvxCommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(UpdateContacts));

        private IMvxCommand _gettingCommand;
        public IMvxCommand GettingContactsCommand => _gettingCommand ?? (_gettingCommand = new MvxAsyncCommand(GettingContacts));

        private IMvxCommand _itemSelectedCommand;
        public IMvxCommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new MvxAsyncCommand<ItemContact>(Transition));
        #endregion

        #region Properties

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        private ItemContact _item;
        public ItemContact Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        private MvxObservableCollection<ItemContact> _items;
        public MvxObservableCollection<ItemContact> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        #endregion

        #region Services
        private IContactService ContactService { get; }
        private IUserDialogs UserDialogs { get; }
        private IMvxNavigationService NavigationService { get; }
        #endregion

        #region Constructors
        public ContactsViewModel(IContactService contactService, IMvxNavigationService mvxNavigationService)
        {
            NavigationService = mvxNavigationService;
            ContactService = contactService;
            if (Mvx.IoCProvider.CanResolve<IUserDialogs>())
                UserDialogs = Mvx.IoCProvider.Resolve<IUserDialogs>();
            Items = new MvxObservableCollection<ItemContact>();
        }
        #endregion

        #region Private
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
                var result = await ContactService.GetContacts(_count, _page).ConfigureAwait(false);
                if (result == null)
                    UserDialogs.Alert("Contact list is empty!");
                _page++;
                var list = new MvxObservableCollection<ItemContact>();
                foreach (var contact in result.Contacts)
                    list.Add(new ItemContact(contact));
                Items.AddRange(list);
            }
            catch (Exception ex)
            {
                UserDialogs.Alert(ex.Message);
            }
        }
        #endregion

        #region Protected
        #endregion

        #region Public
        public override void ViewCreated()
        {
            base.ViewCreated();
            Task.Run(GettingContacts);
        }

        public  Task<bool> Transition(ItemContact item) => NavigationService.Navigate<ContactViewModel, API.Models.Contact>(item.Contact);
        #endregion
    }
}