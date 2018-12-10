using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using Phonebook.API.Service;
using System.Net.Http;

namespace Phonebook.iOS
{
    public class Setup : MvxIosSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new NSUrlSessionHandler()));
        }
    }
}
