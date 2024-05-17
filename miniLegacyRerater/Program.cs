using miniLegacyRerater.Presentation;

namespace miniLegacyRerater;

class Program
{
    static void Main(string[] args)
    {
        //Console.Clear();
        Console.WriteLine($"Welcome to mini Legacy Rerater!\nThe Legacy Rerater is used to set the price of policies.\nGiven a rategen, the new premium is" +
        $" calculated. The process is iterated until the right price is achieved.\nThe users start the process by creating a set of policies.\n" +
        $"Once the set is created, the rerating is done for the set.\n");
        /*
        object that mimics the Legacy Rerater
        - class for the UI
        - class for rating
        */
        //Menu UI = new Menu();

        Menu.StartMenu();

    }

}
