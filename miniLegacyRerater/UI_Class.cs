using System.Security.Cryptography.X509Certificates;

namespace miniLegacyRerater;

public class UI_Class{
 public void EnterData()
    {
        bool morePolicies=false;
        // Rating ratabase = new Rating();
        List<Rating> ratabase_baseline_list = new List<Rating>();
        List<Rating> ratabase_list = new List<Rating>();
        //public void EnterData(){
        Console.WriteLine("Enter the policy(ies)");
        int PolicyId;
        string EffectiveDate;
        int RateGen;
        int Premium=100;
        Rating ratabase;// = new Rating();
        do{
                Console.WriteLine("PolicyId");
                PolicyId = int.Parse(Console.ReadLine());
                // Console.WriteLine("RiskState");
                // string RiskState=Console.ReadLine();
                Console.WriteLine("EffectiveDate");
                EffectiveDate = Console.ReadLine();
                // Console.WriteLine("NumberOfVehicles");
                // int NumberOfVehicles=int.Parse(Console.ReadLine());
                // Console.WriteLine("NumberofDrivers");
                // int NumberofDrivers=int.Parse(Console.ReadLine());
                // Console.WriteLine("NumberOfOccurrences");
                // int NumberOfOccurrences=int.Parse(Console.ReadLine());
                Console.WriteLine("RateGen 1 or 2");
                RateGen=int.Parse(Console.ReadLine());
                bool flag=false;
                do{

                    if (RateGen!=1 && RateGen !=2){
                    flag=true;
                    Console.WriteLine("RateGen 1 or 2");
                    RateGen=int.Parse(Console.ReadLine());
                    }else{flag=false;}

                }while(flag);

                Console.WriteLine("More Policies?  y/n");
                string resp = Console.ReadLine().ToLower();

                if(resp=="y"){
                    morePolicies=true;
                }else{morePolicies=false;}
                ratabase = new Rating(PolicyId,  EffectiveDate);
                ratabase_baseline_list.Add(ratabase);
                ratabase = new Rating(PolicyId,  EffectiveDate,  RateGen,Premium);
                ratabase_list.Add(ratabase);

        }while(morePolicies);


        
        
        //to do:  in a list, put all the policies (create a do loop to enter policies)
        //once all are in, print them prior to "send them to ratabase"
        //send them to ratabase and based on the rategen use either 1.1 or 1.2 to multiply the baseline by
        
        //ratabase_baseline_list.Add(ratabase_baseline);
        Console.WriteLine("Current rate:");
        foreach(Rating r in ratabase_baseline_list){

        
        Console.WriteLine(r);
        }
        Console.WriteLine("Calling Ratabase");
        ratabase.Rate();
        //Rating ratabase = new Rating( PolicyId,  EffectiveDate,  RateGen,Premium);
        // ratabase_list.Add(ratabase);
        Console.WriteLine("\nNewRate");
        foreach(Rating r in ratabase_list){

        
        Console.WriteLine(r);
        }
        
        //Rating ratabase = new Rating( PolicyId,  EffectiveDate,  RateGen,Premium);
        //Console.WriteLine(ratabase);
        //}
    }
}