using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using Phonebook.Core.ViewModels;

namespace Phonebook.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class FirstView : MvxTabBarViewController<FirstViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(Button).To(vm => vm.ResetTextCommand);
            set.Apply();
        }
    }
}
