using Android.App;
using Android.OS;

using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

using Phonebook.Core.ViewModels.Contacts;
using Phonebook.Droid.Adapters;

namespace Phonebook.Droid.Views.Contacts
{
    [MvxActivityPresentation]
    [Activity(Label = "Phonebook")]
    public class ContactsView : MvxAppCompatActivity<ContactsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Contacts);

            var mvxRecyclerView = FindViewById<MvxRecyclerView>(Resource.Id.mvxRecyclerView);
            var mvxRecyclerAdapter = new ContactsAdapter((IMvxAndroidBindingContext)BindingContext);

            var set = this.CreateBindingSet<ContactsView, ContactsViewModel>();
            set.Bind(mvxRecyclerAdapter).For(x => x.GettingContactsCommandAdapter).To(x => x.GettingContactsCommand);
            set.Apply();

            mvxRecyclerView.Adapter = mvxRecyclerAdapter;
        }
    }
}
