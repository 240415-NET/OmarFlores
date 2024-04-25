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
        pseudoUI();
    }

    private static void pseudoUI()
    {
        Console.WriteLine("pseudo UI");
        Console.WriteLine("PolicyId");
        int PolicyId = int.Parse(Console.ReadLine());
        // Console.WriteLine("RiskState");
        // string RiskState=Console.ReadLine();
        Console.WriteLine("EffectiveDate");
        string EffectiveDate = Console.ReadLine();
        // Console.WriteLine("NumberOfVehicles");
        // int NumberOfVehicles=int.Parse(Console.ReadLine());
        // Console.WriteLine("NumberofDrivers");
        // int NumberofDrivers=int.Parse(Console.ReadLine());
        // Console.WriteLine("NumberOfOccurrences");
        // int NumberOfOccurrences=int.Parse(Console.ReadLine());
        Console.WriteLine("RateGen");
        int RateGen=int.Parse(Console.ReadLine());
        int Premium=100;
        
        //to do:  in a list, put all the policies (create a do loop to enter policies)
        //once all are in, print them prior to "send them to ratabase"
        //send them to ratabase and based on the rategen use either 1.1 or 1.2 to multiply the baseline by
        
        Console.WriteLine("Now calling Ratabase...");
        for(int i=0;i<5;i++){
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.WriteLine("\nthe base BI coverage is $100. The final premium depends on the rategen");
        Rating ratabase = new Rating( PolicyId,  EffectiveDate,  RateGen,Premium);
        Console.WriteLine(ratabase);
    }

    
}
