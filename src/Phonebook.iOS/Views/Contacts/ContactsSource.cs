using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Phonebook.iOS.Views.Contacts
{
    public class ContactsSource : MvxSimpleTableViewSource
    {
        public ICommand GettingContactsCommandSource { get; set; }

        public ContactsSource(IntPtr handle)
            : base(handle)
        {
        }

        public ContactsSource(UITableView tableView, string nibName, string cellIdentifier = null, NSBundle bundle = null)
           : base(tableView, nibName, cellIdentifier, bundle)
        {
        }

        public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
        {
            if (indexPath.Row >= RowsInSection(tableView, indexPath.Section) - 3 && GettingContactsCommandSource.CanExecute(null))
                GettingContactsCommandSource.Execute(null);
        }

    }
}