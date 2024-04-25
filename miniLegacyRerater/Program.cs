namespace miniLegacyRerater;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to mini Legacy Rerater!\nThe Legacy Rerater is used to set the price of policies.\nGiven a rategen, the new premium is"+
        $" calculated. The process is iterated until the right price is achieved.\nIn this example, two rategens are used, one that has a factor 1.1 (10% increase) and another with 1.2.");
        /*
        object that mimics the Legacy Rerater
        - class for the UI
        - class for rating
        */
        UI_Class UI = new UI_Class();
        UI.EnterData();

    }
 
}
