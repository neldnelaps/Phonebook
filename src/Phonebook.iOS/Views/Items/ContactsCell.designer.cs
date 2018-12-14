using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using FFImageLoading;

namespace Phonebook.iOS.Views.Items
{
    [Register("ContactsCell")]
    partial class ContactsCell
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UILabel Name { get; set; }

        [Outlet]
        FFImageLoading.Cross.MvxCachedImageView imageView { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (Name != null)
            {
                Name.Dispose();
                Name = null;
            }
            if (imageView != null)
            {
                imageView.Dispose();
                imageView = null;
            }
        }
    }
}