using miniLegacyRerater.Models;
using System.Text.Json;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using miniLegacyRerater.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;

namespace miniLegacyRerater.Data;

public class SQLUserStorage : ISQLUserStorage
{
    public static string connectionString = File.ReadAllText(@"ConnectionString.txt");
     private readonly miniLegacyReraterContext _context;
     

       public SQLUserStorage(miniLegacyReraterContext contextFromBuilder)
    {
        _context = contextFromBuilder;
    }

    public async Task<User> FindUser(string userNameToFind){
        Console.WriteLine(userNameToFind);
        //userNameToFind="Omar";
        //try{
        User foundUser = await _context.Users.FirstOrDefaultAsync(x=>x.userName==userNameToFind);
        Console.WriteLine(foundUser.userName);
         
        if(string.IsNullOrEmpty(foundUser.userName))
        {
            return null;
        }

            
        //}
        // catch(Exception e){
        //     Console.WriteLine(e.StackTrace);
        // }
        return foundUser;
        

    }

    public void StoreUser(User user)
    {
        throw new NotImplementedException();
    }

    // public void StoreUser(User user){
    //    using SqlConnection connection = new SqlConnection(connectionString);
    //    connection.Open();
    //    string cmdText= @"INSERT INTO dbo.Users(userId,userName)
    //                         VALUES(@userId,@userName);";
    //     using SqlCommand cmd = new SqlCommand(cmdText,connection);

    //     cmd.Parameters.AddWithValue("@userId",user.userId);
    //     cmd.Parameters.AddWithValue("@userName",user.userName);
    //     cmd.ExecuteNonQuery();
    //     connection.Close();
    // }


}