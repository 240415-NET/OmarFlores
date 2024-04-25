using System.Security.Cryptography.X509Certificates;

namespace miniLegacyRerater;

public class UI_Class{

    //class that controls the information input
 public void EnterData()
    {
        bool morePolicies=false;

        //define two lists, one for the policies as they are in Prod
        //and one after rerating them with ratabase at the desired rategen
        List<Rating> ratabase_baseline_list = new List<Rating>();
        List<Rating> ratabase_list = new List<Rating>();

        Console.WriteLine("Enter the policy(ies)");
        int PolicyId;
        string EffectiveDate;
        int RateGen;
        //default premium.  In real policies it would depend on the number of vehicles, drivers, discounds, etc.
        int Premium=100;
        //declare the ratabase variable.  It will get instantiate it later.
        Rating ratabase;
        do{
                //Enter the policy data: policyId, EffectiveDate, Rategen
                Console.WriteLine("PolicyId");
                PolicyId = int.Parse(Console.ReadLine());
                // Console.WriteLine("RiskState");
                // string RiskState=Console.ReadLine();
                Console.WriteLine("EffectiveDate");
                EffectiveDate = Console.ReadLine();

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

                //instantiate the policies prior to rerating
                ratabase = new Rating(PolicyId,  EffectiveDate);
                ratabase_baseline_list.Add(ratabase);
                //instantiate the policies after rerating
                ratabase = new Rating(PolicyId,  EffectiveDate,  RateGen,Premium);
                ratabase_list.Add(ratabase);

        }while(morePolicies);


        Console.WriteLine("Current rate:");
        foreach(Rating r in ratabase_baseline_list){
            Console.WriteLine(r);
        }
        Console.WriteLine("Calling Ratabase");
        ratabase.Rate();
        Console.WriteLine("\nNewRate");
        
        foreach(Rating r in ratabase_list){
            Console.WriteLine(r);
        }
        
    }
}