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
        private string _filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\file.Json"; 
        public void ShowMenuOptions()
        {
            Console.Clear();
            Console.WriteLine("¤¤¤¤¤¤ Menu ¤¤¤¤¤¤");
            Console.WriteLine("1. View Address Book");
            Console.WriteLine("2. Add New Contact");
            Console.WriteLine("3. Settings");            
            Console.Write("Choose one option: ");
            var option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1":
                    ShowAddressBook();
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
            // För att konvertera listan skapas Json file. 
            try
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(_fileManager.Read(_filePath));
            } 
            catch { } 
            
            Console.Clear();
            Console.WriteLine("¤¤¤¤¤¤ Address Book ¤¤¤¤¤¤");
            foreach (var contact in _contacts)
                Console.WriteLine($"{contact.Id} {contact.FirstName} {contact.LastName}");
            if(_contacts.Count > 0)
            {
                Console.WriteLine();
                Console.Write("View Contact Details? (y/n): ");
            
                var option = Console.ReadLine();
                if (option?.ToLower() == "y")
                {
                    Console.Write("Enter Contact Id: ");
                    var id = Console.ReadLine();

                    if (!string.IsNullOrEmpty(id))
                    {
                        ShowContactDetails(id);
                    }
                }
            }           
        }
        public void ShowContactDetails(string id)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == new Guid(id));

            Console.Clear();
            Console.WriteLine("¤¤¤¤¤¤ View Contacts Details ¤¤¤¤¤¤");
            Console.WriteLine($"ID:         \t {contact?.Id}");
            Console.WriteLine($"FirstName:  \t {contact?.FirstName}");
            Console.WriteLine($"LastName:   \t {contact?.LastName}");
            Console.WriteLine($"Email:      \t {contact?.Email}");
            Console.WriteLine($"StreetName: \t {contact?.StreetName}");
            Console.WriteLine($"PostalCode: \t {contact?.PostalCode}");
            Console.WriteLine($"City:       \t {contact?.City}");
            Console.WriteLine();

            Console.WriteLine("1. Edit");
            Console.WriteLine("2. Delete");
            Console.Write("Choose one option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowUpdateContact(contact);
                    break;

                case "2":
                    DeleteContact(contact.Id);
                    break;

                default: 
                    Console.WriteLine("Enter a valid option");
                    break;
            }
        }
        public void ShowUpdateContact(Contact contact)
        {
           var index = _contacts.IndexOf(contact);

            Console.Write("Enter contact first name:  ");
            var firstName = Console.ReadLine();
            if(!string.IsNullOrEmpty(firstName))
                contact.FirstName = firstName;  

            Console.Write("Enter contact last name: ");
            var lastName = Console.ReadLine();
            if(!string.IsNullOrEmpty(lastName))
                contact.LastName = lastName;

            Console.Write("Enter contact email: ");
            var email = Console.ReadLine();
            if(!string.IsNullOrEmpty(email))
                contact.Email = email;

            Console.Write("Enter street name: ");
            var streetName = Console.ReadLine();
            if(!string.IsNullOrEmpty(streetName))
                contact.StreetName = streetName;

            Console.Write("Enter postal code: ");
            var postalCode = Console.ReadLine();
            if(!string.IsNullOrEmpty(postalCode))
                contact.PostalCode = postalCode;

            Console.Write("Enter city: ");
            var city = Console.ReadLine();
            if(!string.IsNullOrEmpty(city))
                contact.City = city;

            _fileManager.Save(_filePath, JsonConvert.SerializeObject(_contacts));

        }
        public void DeleteContact(Guid id)
        {
           _contacts = _contacts.Where(x => x.Id != id).ToList(); //Lambda expression
            _fileManager.Save(_filePath, JsonConvert.SerializeObject(_contacts));
        }
        public void ShowAddContact()
        {
            var contact = new Contact();

            Console.Clear();    
            Console.WriteLine("¤¤¤¤¤¤ Add New Contact ¤¤¤¤¤¤");

            Console.Write("Enter contact first name: ");
            var firstName = Console.ReadLine();

            Console.Write("Enter contact last name: ");
            var lastName = Console.ReadLine();

            Console.Write("Enter email: ");
            var email = Console.ReadLine();

            Console.Write("Enter Street name: ");
            var streetName = Console.ReadLine();

            Console.Write("Enter postal code: ");
            var postalCode = Console.ReadLine();

            Console.Write("Enter city: ");
            var city = Console.ReadLine();

            _contacts.Add(contact);

            _fileManager.Save(_filePath, JsonConvert.SerializeObject(_contacts));
        }      
        public void ShowSettings()
        {
            throw new NotImplementedException();
        }      
    }
}
