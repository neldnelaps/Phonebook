using Phonebook.API.Models;

namespace Phonebook.Core.ViewModels.Item
{
    public class Items
    {   
        public string Name => $"{Contact.Name.Title} {Contact.Name.Last} {Contact.Name.First}";
        public string Image => Contact.Image.Large;
        public Contact Contact { get; }
        public Items(Contact contact) => Contact = contact;
    }
}