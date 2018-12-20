using MvvmCross;
using Phonebook.Core.Dialog;
using UIKit;

namespace Phonebook.iOS.Dialog
{
    internal class UserDialogs : IUserDialogs
    {
        public void Alert(string message)
        {
            var alertController = UIAlertController.Create("Error", message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("Close", UIAlertActionStyle.Cancel, (_) => { }));
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alertController, true, null);
        }
    }
}