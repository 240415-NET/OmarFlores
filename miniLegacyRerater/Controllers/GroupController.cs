using miniLegacyRerater.Models;
using miniLegacyRerater.Data;

namespace miniLegacyRerater.Controllers;

public class GroupController
{

public static IGroupStorageRepo _groupData = new JsonGroupStorage();
public static void CreateGroup(string groupName,string userName)
    {
        //Creating the user
    Console.WriteLine($"This Should Add A Group {groupName}");
    //Console.ReadLine();

    

        //Creating the group
        string policiesString=getPolicies(groupName);
        if(policiesString==""){
            Console.WriteLine("Warning: No such state exists: try NY or MD or TX or FL");
        }
        else{
        Group newGroup = new Group(groupName,policiesString,_groupData.NextGroupId(),userName);
        
        //Adding a WriteLine to just verify that we got here from the presentation layer
        //Console.WriteLine($"User {newUser.userName} created using CreateUser()!");
        //Console.WriteLine($"{newUser.userId}");

        //.. eventually, we will come here and call a Data Access Layer method to store the user
        _groupData.StoreGroup(newGroup);
        }

    }

    public static string getPolicies(string groupName)
    {
        //read policies from the file and store them in a list
        List<string> policies = _groupData.FilterPolicies(groupName);
        string policies_string=string.Empty;
        if(policies.Count==0){  //if no risk state, policies is null, leave the getPolicies method
            return policies_string;
        }
        else{
        
        foreach(var p in policies){
            Console.WriteLine(p);
            policies_string += p+",";
        }
        policies_string = policies_string.Substring(0,policies_string.Length-1);  //remove the last comma
        //List<string> policyIds=new List<string>();
        Console.WriteLine("in getPolicies.................");

        return policies_string;
        }
   
    }
}