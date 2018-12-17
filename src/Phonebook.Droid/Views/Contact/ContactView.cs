using Android.OS;
using Android.Views;
using Android.Runtime;

using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

using Phonebook.Core.ViewModels.Contacts;
using Phonebook.Core.ViewModels.Contact;
using Android.App;

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