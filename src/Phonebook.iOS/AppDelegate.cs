using Foundation;
using MvvmCross.Platforms.Ios.Core;

namespace Phonebook.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, Core.App>
    {
    }
}

