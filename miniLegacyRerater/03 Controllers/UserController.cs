using miniLegacyRerater.Models;
using miniLegacyRerater.Data;
using Microsoft.AspNetCore.Mvc;

namespace miniLegacyRerater.Controllers;

//This is my "controller"
//This controller handles all business logic related to the user class
//It will contain mostly if not only methods, atleast until we decide to add things like logging
//later on during training. 
[ApiController]
[Route("Users")]
public class UserController : ControllerBase
{

    private readonly ISQLUserStorage _context;
       public UserController(ISQLUserStorage contextFromBuilder)
    {
        _context = contextFromBuilder;
    }
    // public static void CreateUser(string userName)
    // {
    //     //Creating the user
    //     User newUser = new User(userName);
        
    //     //Adding a WriteLine to just verify that we got here from the presentation layer
    //     //Console.WriteLine($"User {newUser.userName} created using CreateUser()!");
    //     //Console.WriteLine($"{newUser.userId}");

    //     //.. eventually, we will come here and call a Data Access Layer method to store the user
    //     _userData.StoreUser(newUser);
    // }

    //This function will *eventually* be used to check if a given username already exists in our data store
    [HttpGet("/Users/{userName}")] 
    public async Task<bool> UserExists(string userName)

    {
        Console.WriteLine(userName);
        //We will need to write some method in our UserStorage.cs (Data Access Layer) that can find a user
        //if they exist
        //if a user was never created, this fails since there is no user.json.  In that case just don't check
        User f = await _context.FindUser(userName);
        if(f != null)
        {
            Console.WriteLine($"{f.userId}-{f.userName}");
            return true;
            //HACK
        }

        return false;
    }


    // // This function returns user information from our data layer
    // public async Task<User> ReturnUser (string userName)

    // {
    //     User existingUser = await _context.FindUser(userName);
    //     return existingUser;
    // }
    
}