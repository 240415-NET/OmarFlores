using miniLegacyRerater.Models;
using System.Data.SqlClient;
using System.Text.Json;

namespace miniLegacyRerater.Data;

public class SQLGroupStorage : IGroupStorageRepo
{
    public static string filePathGroups = "./GroupsFile.json";
    public static string filePathPolicies="./PolicyFile.json";

    public static string connectionString = File.ReadAllText(@"ConnectionString.txt");

    public List<string> FilterPolicies(string riskState)
    {
        Console.WriteLine($"riskState-SQL Approach {riskState}");
        
         using SqlConnection sqlConnection = new SqlConnection(connectionString);
        //try{
           
            sqlConnection.Open();
            string cmdText = @"Select PolicyId, RiskState from dbo.PolicyFile";
            using SqlCommand cmd = new SqlCommand(cmdText,sqlConnection);  

            //cmd.Parameters.AddWithValue("@userToFind",userNameToFind);

            using SqlDataReader reader = cmd.ExecuteReader();
            
            List<Policies> allPolicies= new List<Policies>();
            while(reader.Read())
            {
                Policies policies = new Policies();
                policies.PolicyId=reader.GetString(0);
                
                policies.RiskState=reader.GetString(1);
                Console.WriteLine($"in filterPolicies {policies.PolicyId} {policies.RiskState}");
                allPolicies.Add(policies);
            }
            sqlConnection.Close();

            List<string> filtered = allPolicies.Where(x=>x.RiskState==riskState).Select(x=>x.PolicyId).ToList();
            
        // string policies = File.ReadAllText(filePathPolicies);

        //     //Once you get the string from the file, THEN you can deserialize it.
            // 
        //     List<string> policyIds =  new List<string>();
        //     try{  //if such state exists
            
        //     var v =filtered.Where(x=>x.RiskState==riskState).Select(x=>x.PolicyId);

            
        //      foreach(var f in v){
        //         //Console.WriteLine($"{f}");
        //         policyIds.Add(f);
        //     }
        //     }
        //     catch{  //if no such state exists;
        //         policyIds=null;
        //     }

            // int maxGroup = NextGroupId();
            // policyIds.Add(maxGroup.ToString());

            return filtered;
    }

    public int NextGroupId()
    {
        string existingGroups = File.ReadAllText(filePathGroups);

            //Then, we need to serialize the string back into a List of User objects
            List<Group> existingGroupList = JsonSerializer.Deserialize<List<Group>>(existingGroups);

            return existingGroupList.Select(group => group._groupId).Max()+1;

    }

     public List<Group> AllGroupIds()
    {
        string connection = File.ReadAllText("ConnectionString.txt");
        SqlConnection conn = new SqlConnection(connection);
        string cmdText = "select groupID,groupName,listOfPolicies,userName from dbo.Groups;";
        conn.Open();
            using SqlCommand cmd = new SqlCommand(cmdText,conn);  

            //cmd.Parameters.AddWithValue("@userToFind",userNameToFind);

            using SqlDataReader reader = cmd.ExecuteReader();
           
            List<Group> existingGroupList = new List<Group>();
            while(reader.Read()){
                 Group group = new Group();
                group._groupId=reader.GetInt32(0);
                group._name=reader.GetString(1);
                group._listOfPolicies=reader.GetString(2);
                group._userName=reader.GetString(3);
                existingGroupList.Add(group);
                //Console.WriteLine($"{group._groupId} {group._name} {group._listOfPolicies} {group._userName}");
            }

        conn.Close();
        // string existingGroups = File.ReadAllText(filePathGroups);

        //     //Then, we need to serialize the string back into a List of User objects
        //     List<Group> existingGroupList = JsonSerializer.Deserialize<List<Group>>(existingGroups);

          return existingGroupList.Select(group => group).ToList();

            

    }

    public void StoreGroup(Group group){
        
        //store the group in the db via inserts
        Console.WriteLine($"SQL store group {group._groupId}");
        
         using SqlConnection sqlConnection = new SqlConnection(connectionString);
        //try{
           
            sqlConnection.Open();
       string cmdText= @"INSERT INTO dbo.Groups(groupName,listOfPolicies,userName)
                            VALUES(@groupName,@listOfPolicies,@userName);";
        using SqlCommand cmd = new SqlCommand(cmdText,sqlConnection);

        cmd.Parameters.AddWithValue("@groupName",group._name);
        cmd.Parameters.AddWithValue("@listOfPolicies",group._listOfPolicies);
        cmd.Parameters.AddWithValue("@userName",group._userName);
        cmd.ExecuteNonQuery();
        sqlConnection.Close();


    }
    public void DeleteGroup(int result){
        // if(File.Exists(filePathGroups))
        // {
           Console.WriteLine($"SQL delete group {result}");
        
         using SqlConnection sqlConnection = new SqlConnection(connectionString);
        //try{
           
            sqlConnection.Open();
       string cmdText= $"delete from dbo.Groups where groupId={result}";
        using SqlCommand cmd = new SqlCommand(cmdText,sqlConnection);

        cmd.ExecuteNonQuery();
        sqlConnection.Close();
        // }
        // else if (!File.Exists(filePathGroups)) //The first time the program runs, the file probably doesn't exist
        // {
        //     //Creating a blank list to use later
        //     List<Group> initialGroupsList = new List<Group>();

        //     //Adding our user to our list, PRIOR to serializing it
        //     initialGroupsList.Add(group);

        //     //Here we will serialize our list of users, into a JSON text string
        //     string jsonGroupsListString = JsonSerializer.Serialize(initialGroupsList);

        //     //Now we will store our jsonUsersString to our file
        //     File.WriteAllText(filePathGroups, jsonGroupsListString);
        // }

    }
}