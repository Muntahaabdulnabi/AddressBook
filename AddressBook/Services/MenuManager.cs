using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    // ett interface om de metoder som behövs till adressboken
    internal interface IMenuManager
    {
        public void ShowMenuOptions();   
        public void ShowAddressBook();
        public void ShowContactDetails(string id);
        public void ShowUpdateContact(Contact contact);
        public void DeleteContact(string id);
        public void ShowAddContact();
        public void ShowSettings();

    }
    internal class MenuManager : IMenuManager
    {
        public void DeleteContact(string id)
        {
            throw new NotImplementedException();
        }

        public void ShowAddContact()
        {
            throw new NotImplementedException();
        }

        public void ShowAddressBook()
        {
            throw new NotImplementedException();
        }

        public void ShowContactDetails(string id)
        {
            throw new NotImplementedException();
        }

        public void ShowMenuOptions()
        {
            throw new NotImplementedException();
        }

        public void ShowSettings()
        {
            throw new NotImplementedException();
        }

        public void ShowUpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
