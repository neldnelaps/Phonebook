using Foundation;

using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;

using System;

using UIKit;

namespace Phonebook.iOS.Views.Items
{
    internal partial class ContactsCell : MvxTableViewCell
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
                set.Bind(imageView).For(i => i.ImagePath).To(vm => vm.Image);
                set.Bind(Name).To(m => m.Name);
                set.Apply();
            });
        }
    }
}