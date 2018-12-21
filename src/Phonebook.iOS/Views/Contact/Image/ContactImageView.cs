using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;

using Phonebook.Core.ViewModels.Contact;

namespace Phonebook.iOS.Views.Contact.Image
{
    public partial class ContactImageView : MvxViewController<ContactImageViewModel>
    {
        public ContactImageView() : base("ContactImageView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ContactImageView, ContactImageViewModel>();
            set.Bind(Image).For(s => s.ImagePath).To(vm => vm.Image);
            set.Apply();
        }
    }
}

