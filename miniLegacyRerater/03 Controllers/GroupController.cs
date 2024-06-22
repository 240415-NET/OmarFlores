using miniLegacyRerater.Models;
using miniLegacyRerater.Data;
using Microsoft.AspNetCore.Mvc;

namespace miniLegacyRerater.Controllers;

[ApiController]
[Route("Group")]
public class GroupController : ControllerBase
{

//public static IGroupStorageRepo _groupData = new SQLGroupStorage();
 private readonly IGroupStorageRepo _context;
       public GroupController(IGroupStorageRepo contextFromBuilder)
    {
        _context = contextFromBuilder;
    }



    [HttpGet("/Groups")]
    public async Task<List<int>> FilterPols(string state)
    {
        List<int> p = await _context.FilterPolicies(state);
        return p;
     }
// public static void CreateGroup(string groupName,string userName)
//     {
//         //Creating the user
//     Console.WriteLine($"This Should Add A Group {groupName}");
//     //Console.ReadLine();

    

//         //Creating the group
//         string policies = _groupData.FilterPolicies(groupName);
//         //string policiesString=getPolicies(groupName);
//         if(policies.Length==0){
//             Console.WriteLine("Warning: No such state exists: try NY or MD or TX or FL or VA or KS");
//         }
//         else{
//         Group newGroup = new Group(groupName,_groupData.NextGroupId(),userName,DateTime.Now,policies);
        
//         //Adding a WriteLine to just verify that we got here from the presentation layer
//         //Console.WriteLine($"User {newUser.userName} created using CreateUser()!");
//         //Console.WriteLine($"{newUser.userId}");

//         //.. eventually, we will come here and call a Data Access Layer method to store the user
//         _groupData.StoreGroup(newGroup);
//         }

//     }

//     public static string getPolicies(string groupName)
//     {
//         //read policies from the file and store them in a list
//         string policies = _groupData.FilterPolicies(groupName);
//         string policies_string=string.Empty;
//         if(policies.Length==0){  //if no risk state, policies is null, leave the getPolicies method
//             return policies_string;
//         }
//         else{
        
//         foreach(var p in policies){
//             Console.WriteLine(p);
//             policies_string += p+",";
//         }
//         policies_string = policies_string.Substring(0,policies_string.Length-1);  //remove the last comma
//         //List<string> policyIds=new List<string>();
//         Console.WriteLine("in getPolicies.................");

//         return policies_string;
//         }
   
//     }

    //  public decimal RunSet(int result)
    // {
    //     Console.WriteLine($"Running the set {result} now...");
    //     return 0; // _groupData.getPremiums(result);
    // }
}