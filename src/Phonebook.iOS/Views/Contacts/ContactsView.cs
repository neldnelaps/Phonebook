using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Platforms.Ios.Binding.Views;

using Phonebook.Core.ViewModels.Contacts;
using Phonebook.iOS.Views.Items;

namespace Phonebook.iOS.Views.Contacts
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class ContactsView : MvxViewController<ContactsViewModel>
    {
        private MvxUIRefreshControl _refresh;
        public ContactsView() : base("ContactsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _refresh = new MvxUIRefreshControl();
            tableView.RefreshControl = _refresh;

            NavigationItem.Title = "Contacts";

            var source = new ContactsSource(tableView, ContactsCell.Key, ContactsCell.Key);

            var set = this.CreateBindingSet<ContactsView, ContactsViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Bind(source).For(s => s.GettingContactsCommandSource).To(vm => vm.GettingContactsCommand);
            set.Bind(_refresh).For(r => r.RefreshCommand).To(vm => vm.RefreshCommand);
            set.Bind(_refresh).For(r => r.IsRefreshing).To(vm => vm.IsRefreshing);
            set.Apply();

            tableView.Source = source;
            tableView.ReloadData();
        }
    }
}