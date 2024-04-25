namespace miniLegacyRerater;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to mini Legacy Rerater!");
        /*
        object that mimics the Legacy Rerater
        - class for the UI
        - class for rating
        - class for parsing
        - producing the results
        */
        UI_Class UI = new UI_Class();
        UI.EnterData();


    }

   

    
}
