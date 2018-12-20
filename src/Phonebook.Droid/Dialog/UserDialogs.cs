using Android.App;

using MvvmCross;
using MvvmCross.Platforms.Android;
using Phonebook.Core.Dialog;

namespace Phonebook.Droid.Dialog
{
    internal class UserDialogs: IUserDialogs
    {
        public Activity CurrentActivity => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
        public void Alert(string message)
        {
            CurrentActivity.RunOnUiThread(() => new AlertDialog.Builder(CurrentActivity)
                .SetTitle("Exception")
                .SetMessage(message)
                .SetNegativeButton("Close", (s, e) => { }).Show()
            );
        }      
    }
}