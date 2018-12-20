using System.Windows.Input;

using Android.Support.V7.Widget;
using Android.Views;

using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Phonebook.Droid.Adapters
{
    internal class ContactsAdapter : MvxRecyclerAdapter
    {
        public ICommand GettingContactsCommandAdapter { get; set; }
        public ContactsAdapter(IMvxAndroidBindingContext bindingContext)
            : base(bindingContext)
        {
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);
            if (position >= ItemCount - 3 && GettingContactsCommandAdapter.CanExecute(null))
                GettingContactsCommandAdapter.Execute(null);
        }
    }
}