using miniLegacyRerater.Models;
using miniLegacyRerater.Data;

namespace miniLegacyRerater.Controllers;

public class GroupController
{

private static IGroupStorageRepo _groupData = new JsonGroupStorage();
public static void CreateGroup(string groupName,string userName)
    {
        //Creating the user
    Console.WriteLine($"This Should Add A Group {groupName}");
    //Console.ReadLine();

    

        //Creating the group
        Group newGroup = new Group(groupName,getPolicies( groupName),_groupData.NextGroupId(),userName);
        
        //Adding a WriteLine to just verify that we got here from the presentation layer
        //Console.WriteLine($"User {newUser.userName} created using CreateUser()!");
        //Console.WriteLine($"{newUser.userId}");

        //.. eventually, we will come here and call a Data Access Layer method to store the user
        _groupData.StoreGroup(newGroup);
    

    }

    private static string getPolicies(string groupName)
    {
        //read policies from the file and store them in a list
        List<string> policies = _groupData.FilterPolicies(groupName);
        string policies_string=string.Empty;
        foreach(var p in policies){
            Console.WriteLine(p);
            policies_string += p+",";
        }
        policies_string = policies_string.Substring(0,policies_string.Length-1);  //remove the last comma
        //List<string> policyIds=new List<string>();
        Console.WriteLine("in getPolicies.................");
        // foreach(var p in policies){
        //     Console.WriteLine($"{p.PolicyId} {p.RiskState}");
        //     policyIds.Add(p.PolicyId);

        // }
        return policies_string;
    }
}