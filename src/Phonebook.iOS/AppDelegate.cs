using Foundation;
using MvvmCross.Platforms.Ios.Core;

namespace Phonebook.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<Core.App>, Core.App>
    {
        int g = 0;
    }
}

