using MvvmCross.ViewModels;

namespace Phonebook.Core.ViewModels.Contact
{
    public class ContactImageViewModel : MvxViewModel<string>
    {
        public string Image { get; set; }

        public override void Prepare(string parameter)
        {
            Image = parameter;
        }
    }
}

