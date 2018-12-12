
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using Phonebook.Core.ViewModels.Item;
using System;
using UIKit;

namespace Phonebook.iOS.Views
{
    partial class Listitem : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("Listitem");
        public static readonly UINib Nib;

        static Listitem()
        {
            Nib = UINib.FromName("Listitem", NSBundle.MainBundle);
        }

        protected Listitem(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<Listitem, Items>();
                set.Bind(imageView).For(i => i.ImagePath).To(vm => vm.Image);
                set.Bind(Name).To(m => m.Name);
                set.Apply();
            });
        }
    }
}