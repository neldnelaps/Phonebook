using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Views;

using Phonebook.Core.ViewModels.Contact;

using UIKit;

namespace Phonebook.iOS.Views.Contact
{
    public partial class ContactView : MvxViewController<ContactViewModel>
    {
        public ContactView() : base("ContactView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ContactView, ContactViewModel>();
            set.Bind(Image).For(i => i.ImagePath).To(vm => vm.Image);
            set.Bind(Image).For(img => img.BindTap()).To(vm => vm.NavigateToPhotoCommand);
            set.Bind(Name).To(vm => vm.Name);
            set.Bind(Phone).To(vm => vm.Phone);
            set.Bind(Email).To(vm => vm.Email);
            set.Apply();

            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;
            }
        }
    }
}

