using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Platforms.Ios.Binding.Views;

using Phonebook.Core.ViewModels;

namespace Phonebook.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        MvxUIRefreshControl _refresh;
        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _refresh = new MvxUIRefreshControl();
            tableView.RefreshControl = _refresh;

            NavigationItem.Title = "Contacts";

            var source = new MvxSimpleTableViewSource(tableView, "Listitem", Listitem.Key);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Bind(_refresh).For(r => r.RefreshCommand).To(vm => vm.RefreshCommand);
            set.Bind(_refresh).For(r => r.IsRefreshing).To(vm => vm.IsRefreshing);
            set.Apply();

            tableView.Source = source;
            tableView.ReloadData();
        }
    }
}