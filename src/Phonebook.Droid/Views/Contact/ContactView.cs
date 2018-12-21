using Android.App;
using Android.OS;
using Android.Views;

using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;

using Phonebook.Core.ViewModels.Contact;

using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Phonebook.Droid.Views.Contact
{
    [MvxActivityPresentation]
    [Activity(Label = "Phonebook")]
    public class ContactView : MvxAppCompatActivity<ContactViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Contact);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Contact";
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId != Android.Resource.Id.Home)
                return base.OnOptionsItemSelected(item);

            Finish();
            return true;
        }
    }
    //[MvxFragmentPresentation(ActivityHostViewModelType = typeof(ContactsViewModel), FragmentContentId = Resource.Id.contentFrame, AddToBackStack = true)]
    //[Register(nameof(ContactView))]
    //public class ContactView : MvxFragment<ContactViewModel>
    //{
    //    public ContactView()
    //    {
    //    }

    //    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    //    {
    //        base.OnCreateView(inflater, container, savedInstanceState);

    //        ((MvxAppCompatActivity)Activity).SupportActionBar.SetDisplayHomeAsUpEnabled(true);

    //        return this.BindingInflate(Resource.Layout.Contact, null);
    //    }
    //}
}