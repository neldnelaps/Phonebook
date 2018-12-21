using System;

namespace Phonebook.Core.Dialog
{
    public interface IUserDialogs
    {
        void Alert(string message, Action buttonAction);
    }
}
