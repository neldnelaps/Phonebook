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
    public class ContactImageView : MvxAppCompatActivity<ContactImageViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.contact_image);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Image";
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
    //[MvxFragmentPresentation(
    //       ActivityHostViewModelType = typeof(ContactsViewModel),
    //       FragmentContentId = Resource.Id.frameLayout,
    //       AddToBackStack = true)]
    //[Register(nameof(ContactImageView))]
    //public class ContactImageView : MvxFragment<ContactImageViewModel>
    //{
    //    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    //    {
    //        base.OnCreateView(inflater, container, savedInstanceState);

    //        ((MvxAppCompatActivity)Activity).SupportActionBar.SetDisplayHomeAsUpEnabled(true);

    //        return this.BindingInflate(Resource.Layout.contact_image, null);
    //    }
    //}
}