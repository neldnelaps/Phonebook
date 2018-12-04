using Android.App;
using Android.OS;

using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using Phonebook.Core.ViewModels;

namespace Phonebook.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Phonebook")]
    public class FirstView : MvxAppCompatActivity<FirstViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);      
        }
    }
}
