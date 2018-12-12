using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using Phonebook.API.Service;
using Phonebook.Core.ViewModels.Item;

using System;

namespace Phonebook.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly int _count = 10;
        private int _page = 1;

        private IMvxCommand _refreshCommand;
        public IMvxCommand RefreshCommand => _refreshCommand ?? (_refreshCommand = new MvxAsyncCommand(UpdateContacts));

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        private string _text = "";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private MvxObservableCollection<Items> _items;
        public MvxObservableCollection<Items> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        readonly IContactService _contactService;   
        public FirstViewModel(IContactService contactService)
        {
            _contactService = contactService;
            Items = new MvxObservableCollection<Items>();
        }

        private async Task UpdateContacts()
        {
            IsRefreshing = true;
            await GettingContacts();
            IsRefreshing = false;      
        }

        private async Task GettingContacts()
        {
            try
            {
                var result = await _contactService.GetContacts(_count, _page).ConfigureAwait(false);
                if (result == null)
                    return;
                _page++;
                foreach (var contact in result.Contacts)
                    Items.Add(new Items(contact));
            }
            catch (Exception ex)
            {
                Text = ex.Message;
            }
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            Task.Run(GettingContacts);
        }
    }
}