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
        public void ShowMenuOptions();   // En metod för att visa menyn
        public void ShowAddressBook();
        public void ShowContactDetails(string id);
        public void ShowUpdateContact(Contact contact);
        public void DeleteContact(Guid id);
        public void ShowAddContact();
        public void ShowSettings();

    }
    internal class MenuManager : IMenuManager  //Implementera interfacet
    {
        public void ShowMenuOptions()
        {
            Console.Clear();
            Console.WriteLine("¤¤¤¤¤¤ Menu ¤¤¤¤¤¤");
            Console.WriteLine("1. View Address Book");
            Console.WriteLine("2. Add New Contact");
            Console.WriteLine("3. Settings");
            Console.WriteLine();
            Console.Write("Choose one option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowMenuOptions();
                    break;
                                   
                case "2":
                    ShowAddContact();
                    break;
                
                case "3":
                    ShowSettings();
                    break;
                    
                default:
                    Console.WriteLine("Enter a valid option");
                    break;

            }

        }
        public void ShowAddressBook()
        {
            throw new NotImplementedException();
        }
        public void ShowContactDetails(string id)
        {
            throw new NotImplementedException();
        }
        public void ShowUpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
        public void DeleteContact(Guid id)
        {
            throw new NotImplementedException();
        }
        public void ShowAddContact()
        {
            throw new NotImplementedException();
        }      
        public void ShowSettings()
        {
            throw new NotImplementedException();
        }      
    }
}
