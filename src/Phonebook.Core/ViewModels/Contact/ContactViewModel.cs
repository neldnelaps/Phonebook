using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API.Models;
using Phonebook.API.Service;
using Phonebook.Core.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core.ViewModels.Contact
{
    public class ContactViewModel : MvxViewModel<API.Models.Contact>
    {
        #region Fields
        private API.Models.Contact contact;
        public string Image => contact.Image.Large;
        public string Name => $"{contact.Name.Title} {contact.Name.Last} {contact.Name.First}";
        public string Phone => contact.Phone;
        public string Email => contact.Email;
        #endregion

        #region Commands
        private IMvxAsyncCommand _navigateToPhotoCommand;
        public IMvxAsyncCommand NavigateToPhotoCommand => _navigateToPhotoCommand ?? (_navigateToPhotoCommand = new MvxAsyncCommand(NavigateToPhoto));
        #endregion

        #region Services
        private IMvxNavigationService NavigationService { get; }
        #endregion

        #region Constructors
        public ContactViewModel(IMvxNavigationService mvxNavigationService)
        {
            NavigationService = mvxNavigationService;
        }
        #endregion

        #region Private
        private Task<bool> NavigateToPhoto() => NavigationService.Navigate<ContactImageViewModel, string>(Image);
        #endregion

        #region Public
        public override void Prepare(API.Models.Contact parameter) => contact = parameter;
        #endregion
    }
}
