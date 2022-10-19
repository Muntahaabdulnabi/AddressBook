using AddressBook.Services;

IMenuManager menu = new MenuManager();

do
{
    Console.Clear();
    menu.ShowMenuOptions();

    Console.ReadKey();
}while (true);
