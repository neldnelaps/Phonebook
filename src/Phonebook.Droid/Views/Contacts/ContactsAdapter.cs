using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Phonebook.Droid.Views.Contacts
{
    internal class ContactsAdapter : MvxRecyclerAdapter
    {
        public ICommand GettingContactsCommandAdapter { get; set; }
        public ContactsAdapter(IMvxAndroidBindingContext bindingContext)
            : base(bindingContext)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var vh = new MvxRecyclerViewHolder(InflateViewForHolder(parent, viewType, itemBindingContext), itemBindingContext)
            {
                Click = ItemClick
            };
            return vh;
        }

        public override int GetItemViewType(int position) => ItemTemplateSelector.GetItemViewType(GetItem(position));

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            base.OnBindViewHolder(holder, position);
            if (position >= ItemCount - 3 && GettingContactsCommandAdapter.CanExecute(null))
                GettingContactsCommandAdapter.Execute(null);
        }
    }
}