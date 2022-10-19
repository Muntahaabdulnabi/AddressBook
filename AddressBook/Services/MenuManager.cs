using AddressBook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AddressBook.Services
{    
    internal interface IMenuManager        // ett interface om de metoder som behövs till adressboken
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
        private List<Contact> _contacts = new(); //Skapar en lista för att spara och visa contacts 
        private IFileManager _fileManager = new FileManager(); //Funktioner för att läsa och skriva filen
        private string _filePath = ""; 
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
            // För att konvertera listan skapas Json file
            try
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(_fileManager.Read(_filePath));
            } catch { } 
            
            Console.Clear();
            Console.WriteLine("¤¤¤¤¤¤ Address Book ¤¤¤¤¤¤");
            foreach (var contact in _contacts)
                Console.WriteLine($"{contact.Id} {contact.FirstName} {contact.LastName}");
            if(_contacts.Count > 0)

            Console.WriteLine();
            Console.WriteLine("View Contact Details? (y/n): ");
            var option = Console.ReadLine();
            if (option?.ToLower() == "y")
            {
                Console.WriteLine("Enter Contact Id: ");
                var id = Console.ReadLine();

                if (!string.IsNullOrEmpty(id))
                {
                    ShowContactDetails(id);
                }
            }
           
        }
        public void ShowContactDetails(string id)
        {
            
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
