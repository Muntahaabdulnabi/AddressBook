using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    // funktionaliteter som behövs för att läsa och skriva
    internal interface IFileManager        //Behövs inte men det är bra att ha
    {
        public void Save(string filePath, string content);  
        public string Read(string filePath);         
    }
    internal class FileManager : IFileManager // implementering av interfacet
    {
           public string Read(string filePath)

           {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
       
           }


        public void Save(string filePath, string content)
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(content);
        }
    }
}

/* Förutsättning att allting är i sträng format.
 All annan logik måste ligga i en annan ställe(Sevice)*/ 