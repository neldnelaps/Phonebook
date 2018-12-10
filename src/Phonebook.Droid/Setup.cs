using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using Phonebook.API.Service;
using Xamarin.Android.Net;

namespace Phonebook.Droid
{
    public class Setup: MvxAndroidSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new AndroidClientHandler()));
        }
    }
}
