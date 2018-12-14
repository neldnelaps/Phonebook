namespace Phonebook.Core.ViewModels.Item
{
    public class ItemContact
    {   
        public string Name => $"{Contact.Name.Title} {Contact.Name.Last} {Contact.Name.First}";
        public string Image => Contact.Image.Large;
        public API.Models.Contact Contact { get; }
        public ItemContact(API.Models.Contact contact) => Contact = contact;
    }
}