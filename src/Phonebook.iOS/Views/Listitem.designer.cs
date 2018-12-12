// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Phonebook.iOS.Views
{
    [Register ("Listitem")]
    partial class Listitem
    {
        [Outlet]
        FFImageLoading.Cross.MvxCachedImageView imageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Name { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imageView != null) {
                imageView.Dispose ();
                imageView = null;
            }

            if (Name != null) {
                Name.Dispose ();
                Name = null;
            }
        }
    }
}