// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Phonebook.iOS.Views.Contact
{
    [Register ("ContactView")]
    partial class ContactView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Email { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        FFImageLoading.Cross.MvxCachedImageView Image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Name { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Phone { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Email != null) {
                Email.Dispose ();
                Email = null;
            }

            if (Image != null) {
                Image.Dispose ();
                Image = null;
            }

            if (Name != null) {
                Name.Dispose ();
                Name = null;
            }

            if (Phone != null) {
                Phone.Dispose ();
                Phone = null;
            }
        }
    }
}