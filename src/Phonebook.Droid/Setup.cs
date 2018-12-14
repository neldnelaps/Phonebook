using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using Phonebook.API.Service;
using Phonebook.Core.Dialog;
using Phonebook.Droid.Dialog;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Android.Net;

namespace Phonebook.Droid
{
    public class Setup: MvxAndroidSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new AndroidClientHandler()));
            Mvx.IoCProvider.RegisterType<IUserDialogs>(() => new UserDialogs());
        }
    }
}
