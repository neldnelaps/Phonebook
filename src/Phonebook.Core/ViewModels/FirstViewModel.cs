using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Phonebook.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private int count = 1;

        private void ResetText()
        {
            Text = $"{count++} нажатий!";
        }

        private string _text = "Нажми меня";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}