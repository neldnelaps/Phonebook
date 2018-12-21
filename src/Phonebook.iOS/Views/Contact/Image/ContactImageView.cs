using System;

using UIKit;

namespace Phonebook.iOS.Views.Contact.Image
{
    public partial class ContactImageView : UIViewController
    {
        public ContactImageView() : base("ContactImageView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

