using miniLegacyRerater.Models;
using System.Text.Json;
using System.Data.SqlClient;

namespace miniLegacyRerater.Data;

public class SQLUserStorage : IUserStorageRepo
{
    public static string connectionString = File.ReadAllText(@"ConnectionString.txt");

    public User FindUser(string userNameToFind){
        User foundUser = new User();
         using SqlConnection sqlConnection = new SqlConnection(connectionString);
        try{
           
            sqlConnection.Open();
            string cmdText = @"Select userId, userName from dbo.Users
                                where userName=@userToFind;";
            using SqlCommand cmd = new SqlCommand(cmdText,sqlConnection);  

            cmd.Parameters.AddWithValue("@userToFind",userNameToFind);

            using SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                foundUser.userId = reader.GetGuid(0);
                foundUser.userName=reader.GetString(1);
            }
            sqlConnection.Close();
        if(string.IsNullOrEmpty(foundUser.userName))
        {
            return null;
        }

            return foundUser;

        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }


        return null;
    }

    public void StoreUser(User user){
       using SqlConnection connection = new SqlConnection(connectionString);
       connection.Open();
       string cmdText= @"INSERT INTO dbo.Users(userId,userName)
                            VALUES(@userId,@userName);";
        using SqlCommand cmd = new SqlCommand(cmdText,connection);

        cmd.Parameters.AddWithValue("@userId",user.userId);
        cmd.Parameters.AddWithValue("@userName",user.userName);
        cmd.ExecuteNonQuery();
        connection.Close();
    }

    
}