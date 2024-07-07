using CSharpContactListCrud.controllers;
using System;
using System.Text;

namespace CSharpContactListCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            ContactListController controller = new ContactListController();
            Boolean end = true;
            while (end)
            {
                Console.WriteLine("Kontakt siyahısına baxmaq üçün 1, Kontak əlavə etmək üçün 2, Kontaktı silmək üçün 3, Kontaktı axtarmaq üçün 4, Kontaktı yeniləmək üçün 5, Çıxmaq üçün 0 seçin");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            controller.viewContacts();
                            break;
                        case 2:
                            Console.WriteLine("Kontaktın adını daxil edin");
                            string fullName = Console.ReadLine();
                            Console.WriteLine("Kontaktın nömrəsini daxil edin");
                            string number = Console.ReadLine();
                            controller.addContact(fullName, number);
                            break;
                        case 3:
                            controller.viewContacts();
                            Console.WriteLine("Silmək istədiyiniz kontaktın id-sini daxil edin");
                            int id;
                            while (true)
                            {
                                string idInput = Console.ReadLine();
                                if (idInput == "geri")
                                {
                                    break;
                                }
                                if (int.TryParse(idInput, out id))
                                {
                                    controller.removeContact(id);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Düzgün ID daxil edin və ya geri yazın:");
                                }
                            }
                            break;
                        case 4:
                            Console.WriteLine("Axtarış meyarını seçin: Ad üçün 1, Nömrə üçün 2, ID üçün 3");
                            int searchType;
                            if (int.TryParse(Console.ReadLine(), out searchType))
                            {
                                Console.WriteLine("Axtarış datasını daxil edin");
                                string query = Console.ReadLine();
                                controller.SearchContact(query, searchType);
                            }
                            else
                            {
                                Console.WriteLine("Düzgün seçim daxil edin");
                            }
                            break;
                        case 5:
                            controller.viewContacts();
                            int updateId;
                            while (true)
                            {
                                Console.WriteLine("Yeniləmək istədiyiniz kontaktın id-sini daxil edin və ya geri yazın:");
                                string idInput = Console.ReadLine();
                                if (idInput == "geri")
                                {
                                    break;
                                }
                                if (int.TryParse(idInput, out updateId))
                                {
                                    Console.WriteLine("Yeniləmək istədiyiniz məlumatı seçin: Ad üçün 1, Nömrə üçün 2");
                                    int updateChoice;
                                    if (int.TryParse(Console.ReadLine(), out updateChoice))
                                    {
                                        switch (updateChoice)
                                        {
                                            case 1:
                                                Console.WriteLine("Yeni adı daxil edin");
                                                string newFullName = Console.ReadLine();
                                                controller.updateContactName(updateId, newFullName);
                                                break;
                                            case 2:
                                                Console.WriteLine("Yeni nömrəni daxil edin");
                                                string newNumber = Console.ReadLine();
                                                controller.updateContactNumber(updateId, newNumber);
                                                break;
                                            default:
                                                Console.WriteLine("Düzgün seçim daxil edin");
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Düzgün seçim daxil edin");
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Düzgün ID daxil edin və ya geri yazın:");
                                }
                            }
                            break;
                        case 0:
                            end = false;
                            break;
                        default:
                            Console.WriteLine("Düzgün seçim daxil edin");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Düzgün seçim daxil edin");
                }
            }
        }
    }
}
