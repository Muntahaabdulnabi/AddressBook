using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    // funktioner som behövs för att läsa och skriva
    internal interface IfileManager
    {
        public void Save(string filePath, string content);
        public string Read(string filePath);
    }
    internal class FileManager : IfileManager // implementering av interfacet
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
