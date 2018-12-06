using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;

namespace Phonebook.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class FirstView : MvxViewController
    {
        public FirstView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(Button).To(vm => vm.ResetTextCommand);
            set.Bind(Button).For("Title").To(vm => vm.Text);
            set.Apply();
        }
    }
}