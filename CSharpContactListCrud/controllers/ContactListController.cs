using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpContactListCrud.models;

namespace CSharpContactListCrud.controllers
{
    internal class ContactListController
    {
        static List<Contact> contacts = new List<Contact>();

        public void viewContacts()
        {
            if (contacts.Count < 1)
            {
                Console.WriteLine("Telefonda heç bir kontakt yoxdur");
            }
            else
            {
                foreach (Contact contact in contacts)
                {
                    Console.Write($"Kontakt id: {contact.Id} , ");
                    Console.Write($"Kontakt adı: {contact.FullName} , ");
                    Console.WriteLine($"Kontakt nömrəsi: {contact.Number} , ");
                }
            }
        }

        public void addContact(string FullName, string Number)
        {
            int Id;
            if (contacts.Count < 1)
            {
                Id = 0;
            }
            else
            {
                Contact LastElementOfList = contacts[contacts.Count - 1];
                Id = LastElementOfList.Id + 1;
            }
            Contact contact = new Contact
            {
                Id = Id,
                FullName = FullName,
                Number = Number
            };
            contacts.Add(contact);
        }

        public void removeContact(int id)
        {
            var itemToRemove = contacts.SingleOrDefault(r => r.Id == id);
            if (itemToRemove != null)
            {
                contacts.Remove(itemToRemove);
                Console.WriteLine($"{itemToRemove.FullName} adlı şəxs kontakt siyahınızdan silindi.");
            }
        }

        public void SearchContact(string query, int searchType)
        {
            IEnumerable<Contact> results = null;

            switch (searchType)
            {
                case 1:
                    results = contacts.Where(c => c.FullName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);
                    break;
                case 2:
                    results = contacts.Where(c => c.Number.Contains(query));
                    break;
                case 3:
                    if (int.TryParse(query, out int id))
                    {
                        results = contacts.Where(c => c.Id == id);
                    }
                    break;
            }

            if (results != null && results.Any())
            {
                foreach (var contact in results)
                {
                    Console.Write($"Kontakt id: {contact.Id} , ");
                    Console.Write($"Kontakt adı: {contact.FullName} , ");
                    Console.WriteLine($"Kontakt nömrəsi: {contact.Number} , ");
                }
            }
            else
            {
                Console.WriteLine("Heç bir uyğun kontakt tapılmadı.");
            }
        }

        public void updateContactName(int id, string newFullName)
        {
            var contactToUpdate = contacts.SingleOrDefault(r => r.Id == id);
            if (contactToUpdate != null)
            {
                contactToUpdate.FullName = newFullName;
                Console.WriteLine($"Kontakt {id} yeniləndi.");
            }
            else
            {
                Console.WriteLine($"ID {id} olan kontakt tapılmadı.");
            }
        }

        public void updateContactNumber(int id, string newNumber)
        {
            var contactToUpdate = contacts.SingleOrDefault(r => r.Id == id);
            if (contactToUpdate != null)
            {
                contactToUpdate.Number = newNumber;
                Console.WriteLine($"Kontakt {id} yeniləndi.");
            }
            else
            {
                Console.WriteLine($"ID {id} olan kontakt tapılmadı.");
            }
        }
    }
}
