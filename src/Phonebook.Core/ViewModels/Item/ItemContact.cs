using Phonebook.API.Models;

namespace Phonebook.Core.ViewModels.Item
{
    public class ItemContact
    {   
        public string Name => $"{Contact.Name.Title} {Contact.Name.Last} {Contact.Name.First}";
        public string Image => Contact.Image.Large;
        public Contact Contact { get; }
        public ItemContact(Contact contact) => Contact = contact;
    }
}