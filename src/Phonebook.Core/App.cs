using MvvmCross;
using MvvmCross.ViewModels;

using Phonebook.API.Service;
using Phonebook.Core.ViewModels.Contacts;

namespace Phonebook.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Registration();
            RegisterAppStart<ContactsViewModel>();
        }

        private void Registration()
        {
            Mvx.IoCProvider.RegisterType<IContactService, ContactService>();
        }

    }
}