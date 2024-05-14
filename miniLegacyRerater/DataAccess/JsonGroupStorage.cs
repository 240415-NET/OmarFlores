using miniLegacyRerater.Models;
using System.Text.Json;

namespace miniLegacyRerater.Data;

public class JsonGroupStorage : IGroupStorageRepo
{
    public static string filePathGroups = "./GroupsFile.json";
    public static string filePathPolicies="./PolicyFile.json";

    public List<string> FilterPolicies(string riskState)
    {
        Console.WriteLine($"riskState {riskState}");
        string policies = File.ReadAllText(filePathPolicies);

            //Once you get the string from the file, THEN you can deserialize it.
            List<Policies> filtered = JsonSerializer.Deserialize<List<Policies>>(policies);
            
            var v =filtered.Where(x=>x.RiskState==riskState).Select(x=>x.PolicyId);

            List<string> policyIds =  new List<string>();
             foreach(var f in v){
                //Console.WriteLine($"{f}");
                policyIds.Add(f);
            }

            // int maxGroup = NextGroupId();
            // policyIds.Add(maxGroup.ToString());

            return policyIds;
    }

    public int NextGroupId()
    {
        string existingGroups = File.ReadAllText(filePathGroups);

            //Then, we need to serialize the string back into a List of User objects
            List<Group> existingGroupList = JsonSerializer.Deserialize<List<Group>>(existingGroups);

            return existingGroupList.Select(group => group._groupId).Max()+1;

    }

    public void StoreGroup(Group group){
        if(File.Exists(filePathGroups))
        {
            string existingGroupsJson = File.ReadAllText(filePathGroups);

            //Once you get the string from the file, THEN you can deserialize it.
            List<Group> existingGroupsList = JsonSerializer.Deserialize<List<Group>>(existingGroupsJson);
            
            //Once we deserialize our exisitng JSON text from the file into a new List<User> object
            //We will then simply add it to the list, using the Add() method
            existingGroupsList.Add(group);

            //Here we will serialize our list of users, into a JSON text string
            string jsonExistingGroupsListString = JsonSerializer.Serialize(existingGroupsList);

            //Now we will store our jsonUsersString to our file
            File.WriteAllText(filePathGroups, jsonExistingGroupsListString);

        }
        else if (!File.Exists(filePathGroups)) //The first time the program runs, the file probably doesn't exist
        {
            //Creating a blank list to use later
            List<Group> initialGroupsList = new List<Group>();

            //Adding our user to our list, PRIOR to serializing it
            initialGroupsList.Add(group);

            //Here we will serialize our list of users, into a JSON text string
            string jsonGroupsListString = JsonSerializer.Serialize(initialGroupsList);

            //Now we will store our jsonUsersString to our file
            File.WriteAllText(filePathGroups, jsonGroupsListString);
        }

    }
}