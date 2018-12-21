using System;

using Foundation;

using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;

using UIKit;

namespace Phonebook.iOS.Views.Item
{
    public partial class ContactsCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("ContactsCell");
        public static readonly UINib Nib;

        static ContactsCell()
        {
            Nib = UINib.FromName("ContactsCell", NSBundle.MainBundle);
        }

        protected ContactsCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ContactsCell, Core.ViewModels.Item.ItemContact>();
                set.Bind(Image).For(i => i.ImagePath).To(vm => vm.Image);
                set.Bind(Title).To(m => m.Name);
                set.Apply();
            });
        }
    }
}
