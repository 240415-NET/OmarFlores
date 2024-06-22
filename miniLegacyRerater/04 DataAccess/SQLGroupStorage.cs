using Microsoft.EntityFrameworkCore;
using miniLegacyRerater.Models;
using System.Data.SqlClient;
using System.Text.Json;

namespace miniLegacyRerater.Data;

public class SQLGroupStorage : IGroupStorageRepo
{
    public static string filePathGroups = "./GroupsFile.json";
    public static string filePathPolicies="./PolicyFile.json";

    public static string connectionString = File.ReadAllText(@"ConnectionString.txt");

    private readonly miniLegacyReraterContext _context;

    public SQLGroupStorage(miniLegacyReraterContext contextFromBuilder) {
        _context = contextFromBuilder;
    }

    public List<Group> AllGroupIds()
    {
        throw new NotImplementedException();
    }

    public void DeleteGroup(int result)
    {
        throw new NotImplementedException();
    }

    public async Task<List<int>> FilterPolicies(string v)
    {
        List<Policies> p = await _context.policies.Where(x => x.RiskState == v).ToListAsync();
        List<int> l=new();
        l = p.Select(x=>x.PolicyId).ToList();
        return l;
    }

    public decimal getPremiums(int result)
    {
        throw new NotImplementedException();
    }

    public int NextGroupId()
    {
        throw new NotImplementedException();
    }

    public void StoreGroup(Group newGroup)
    {
        throw new NotImplementedException();
    }

    // public string FilterPolicies(string riskState)
    // {
    //     Console.WriteLine($"riskState-SQL Approach {riskState}");

    //      using SqlConnection sqlConnection = new SqlConnection(connectionString);
    //     //try{

    //         sqlConnection.Open();
    //         string cmdText = @"Select PolicyId, RiskState, premium from dbo.Policies";
    //         using SqlCommand cmd = new SqlCommand(cmdText,sqlConnection);  

    //         //cmd.Parameters.AddWithValue("@userToFind",userNameToFind);

    //         using SqlDataReader reader = cmd.ExecuteReader();

    //         List<Policies> allPolicies= new List<Policies>();
    //         while(reader.Read())
    //         {
    //             Policies policies = new Policies();
    //             policies.PolicyId=reader.GetInt32(0);

    //             policies.RiskState=reader.GetString(1);
    //             policies.premium=reader.GetDecimal(2);
    //             Console.WriteLine($"in filterPolicies {policies.PolicyId} {policies.RiskState}");
    //             allPolicies.Add(policies);
    //         }
    //         sqlConnection.Close();

    //         List<Policies> filtered = allPolicies.Where(x=>x.RiskState==riskState).ToList();

    //         string _policies = string.Empty;
    //         filtered.ForEach(x=>_policies += x.PolicyId+" ");

    //         _policies = _policies.TrimEnd().Replace(" ",",");


    //         return _policies;
    // }

    // public int NextGroupId()
    // {
    //     string existingGroups = File.ReadAllText(filePathGroups);

    //         //Then, we need to serialize the string back into a List of User objects
    //         List<Group> existingGroupList = JsonSerializer.Deserialize<List<Group>>(existingGroups);

    //         return existingGroupList.Select(group => group._groupId).Max()+1;

    // }

    //  public List<Group> AllGroupIds()
    // {
    //     string connection = File.ReadAllText("ConnectionString.txt");
    //     SqlConnection conn = new SqlConnection(connection);
    //     string cmdText = "select _groupID,_groupName,_userName from dbo.Groups;";
    //     conn.Open();
    //         using SqlCommand cmd = new SqlCommand(cmdText,conn);  

    //         //cmd.Parameters.AddWithValue("@userToFind",userNameToFind);

    //         using SqlDataReader reader = cmd.ExecuteReader();

    //         List<Group> existingGroupList = new List<Group>();
    //         while(reader.Read()){
    //             Group group = new Group();
    //             group._groupId=reader.GetInt32(0);
    //             group._groupName=reader.GetString(1);
    //             //group._policies=reader.GetString(2);
    //             group._userName=reader.GetString(2);
    //             existingGroupList.Add(group);
    //             //Console.WriteLine($"{group._groupId} {group._name} {group._listOfPolicies} {group._userName}");
    //         }

    //     conn.Close();

    //       return existingGroupList.Select(group => group).ToList();



    // }

    // public void StoreGroup(Group group){

    //     //store the group in the db via inserts

    //      using SqlConnection sqlConnection = new SqlConnection(connectionString);
    //     //try{

    //     sqlConnection.Open();


    //     //insert group name and user name in groups
    //         string cmdText= @"INSERT INTO dbo.Groups(_groupName,_userName,_datecreated,_policies)
    //                         VALUES(@groupName,@userName,@dateCreated,@policies);";
    //     using SqlCommand cmd = new SqlCommand(cmdText,sqlConnection);
    //     cmd.Parameters.AddWithValue("@groupName",group._groupName);
    //     cmd.Parameters.AddWithValue("@userName",group._userName);
    //     cmd.Parameters.AddWithValue("@dateCreated",group._dateCreated);
    //     cmd.Parameters.AddWithValue("@policies",group._policies);
    //     cmd.ExecuteNonQuery();

    //     //get the last group id
    //      cmdText= @"SELECT max(_groupid) as groupId from dbo.Groups";
    //     using SqlCommand cmd2 = new SqlCommand(cmdText,sqlConnection);
    //     //cmd2.ExecuteNonQuery();
    //     SqlDataReader reader = cmd2.ExecuteReader();
    //     int groupId=0;
    //     while(reader.Read())

    //     {
    //      groupId = reader.GetInt32(0);
    //     }

    //     //insert policies in policyDetails
    //     //policyDetails MUST have groupId
    //     List<string> pols = group._policies.Split(",").ToList();

    //     foreach(var p in pols){
    //         cmdText= @"INSERT INTO dbo.policyDetails(policyId,premium,riskState,groupId)
    //                         VALUES(@policyId,@premium,@riskState,@groupId);";
    //     using SqlCommand cmd1 = new SqlCommand(cmdText,sqlConnection);
    //     cmd1.Parameters.AddWithValue("@policyId",p);
    //     cmd1.Parameters.AddWithValue("@premium","100");
    //     cmd1.Parameters.AddWithValue("@riskState",group._groupName);
    //     cmd1.Parameters.AddWithValue("@groupId",groupId);
    //     cmd1.ExecuteNonQuery();
    //     }

    //     sqlConnection.Close();


    // }
    // public void DeleteGroup(int result){

    //        Console.WriteLine($"SQL delete group {result}");

    //      using SqlConnection sqlConnection = new SqlConnection(connectionString);
    //     //try{

    //         sqlConnection.Open();
    //     //delete from Group
    //    string cmdText= $"delete from dbo.Groups where _groupId={result}";
    //     using SqlCommand cmd = new SqlCommand(cmdText,sqlConnection);

    //     cmd.ExecuteNonQuery();

    //     //delete from PolicyDetails
    //     string cmdText1= $"delete from dbo.policyDetails where groupId={result}";
    //     using SqlCommand cmd1 = new SqlCommand(cmdText1,sqlConnection);

    //     cmd1.ExecuteNonQuery();

    //     sqlConnection.Close();


    // }

    // public decimal getPremiums(int result)
    //     {
    //         string connection = File.ReadAllText("ConnectionString.txt");
    //         SqlConnection conn = new SqlConnection(connection);
    //         string cmdText = "select premium from dbo.PolicyDetails where groupId = @groupId";
    //         conn.Open();
    //             using SqlCommand cmd = new SqlCommand(cmdText,conn);  

    //             cmd.Parameters.AddWithValue("@groupId",result);

    //             using SqlDataReader reader = cmd.ExecuteReader();

    //             List<Group> existingGroupList = new List<Group>();
    //             decimal totalPremium = 0;
    //             Console.WriteLine("The individual premiums are:");
    //             while(reader.Read()){
    //                 totalPremium += Decimal.Parse(reader.GetString(0));

    //                 Console.WriteLine($"{reader.GetString(0)}");
    //             }

    //         conn.Close();

    //           return totalPremium;
    //     }
}