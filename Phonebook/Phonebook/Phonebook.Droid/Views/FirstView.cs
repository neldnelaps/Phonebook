using Android.App;
using Android.OS;

namespace Phonebook.Droid.Views
{
    [Activity(Label = "Phonebook")]
    public class FirstView : BaseView
    {
        protected override int LayoutResource => Resource.Layout.FirstView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
        }
    }
}
