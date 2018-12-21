using System;

using Foundation;
using UIKit;

namespace Phonebook.iOS.Views.Item
{
    public partial class ContactsCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ContactsCell");
        public static readonly UINib Nib;

        static ContactsCell()
        {
            Nib = UINib.FromName("ContactsCell", NSBundle.MainBundle);
        }

        protected ContactsCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
