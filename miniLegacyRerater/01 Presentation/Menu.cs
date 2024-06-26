using System.ComponentModel.DataAnnotations;
using System.Xml.XPath;
using miniLegacyRerater.Controllers;
using miniLegacyRerater.Models;

namespace miniLegacyRerater.Presentation;

public class Menu
{
   
   //This method displays the initial menu when the user runs the program
    public static void StartMenu() {

        int userChoice = 0;
        bool validInput = true;

        Console.WriteLine("Welcome to miniLegacyRerater!");
        Console.WriteLine("1. New user");
        Console.WriteLine("2. Returning user");
        Console.WriteLine("3. Exit program");
        
        //Setting up the try-catch to handle user input with
        //do-while to let them try again
        do
        {
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1: // Creating a new user profile
                        UserCreationMenu();
                        break;
                    case 2:
                        UserLoginMenu();
                       
                        break;

                    case 3: //User chooses to exit the program
                        return; //This return exits this method, and returns us to where it was called.

                    default: // If the user enters an integer that is not 1, 2, or 3
                        Console.WriteLine("Please enter a valid choice (from the default)!");
                        validInput = false;
                        break;
                }

            }
            catch (Exception ex) 
            {   
                validInput = false;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Please enter a valid choice! (from the catch)");
            }

        } while (!validInput);

        
    }

    //This method handles the prompts for creating a new user profile
    public static void UserCreationMenu() 
    {
        
        bool validInput = true;
        string userInput = "";

        do
        {   
            //Prompting the user for a username
            Console.WriteLine("Please enter a username: ");

            //The ?? is called the null-coalescing operator
            //If the input comes back null, then we manually set it to an empty string - to avoid 
            //the possibility of this userInput string ever being null. 
            userInput = Console.ReadLine() ?? "";

            //Here we are going to trim the string, to remove any leading or trailing spaces
            userInput = userInput.Trim();

            //If else to check both of our conditions - empty string and existing username
            // if(String.IsNullOrEmpty(userInput))
            // {
            //     Console.WriteLine("Username cannot be blank, please try again.");
            //     validInput = false;
            // }else if(UserController.UserExists(userInput))
            // {
            //     Console.WriteLine("Username already exists, please choose another.");
            //     validInput = false;
            // }else{ //If neither check trips we simply call CreateUser from the UserController!
            //     UserController.CreateUser(userInput);
            //     Console.WriteLine("Profile created!");
            //     validInput = true;
            // }

        } while (!validInput); //Continue running the above block UNTIL input is valid

    }


public static void UserLoginMenu() 
    {
 
        //Declaring our flag boolean outside of our loop, setting it to true
        bool validInput = true;
        string userInput = "";

        do
        {   
            //Prompting the user for a username
            Console.WriteLine("Please enter a username: ");

            //The ?? is called the null-coalescing operator
            //If the input comes back null, then we manually set it to an empty string - to avoid 
            //the possibility of this userInput string ever being null. 
            userInput = Console.ReadLine() ?? "";

            //Here we are going to trim the string, to remove any leading or trailing spaces
            userInput = userInput.Trim();

            //If else to check both of our conditions - empty string and existing username
            // if(String.IsNullOrEmpty(userInput))
            // {
            //     Console.WriteLine("Username cannot be blank, please try again.");
            //     validInput = false;
            // }else if(!UserController.UserExists(userInput)) //if User doesn't exist
            // {
            //     Console.WriteLine("Username doesn't exist, please choose another.");
            //     validInput = false;
            // }else{ //If neither check trips we simply call CreateUser from the UserController!
            //     User existingUser = UserController.ReturnUser(userInput);
            //     Console.WriteLine("You're logged in!");
            //     Console.WriteLine($"Username: {existingUser.userName}");
            //     Console.WriteLine($"User Id: {existingUser.userId}");
            //     UserReratingMenu(userInput);
            //     validInput = true;
            //     //ItemMenu.ItemFunctionMenu(existingUser); //new line for calling item functionality menu
            // }

        } while (!validInput); //Continue running the above block UNTIL input is valid

    }

    private static void UserReratingMenu(string userInput)
    {
        
            Console.WriteLine("What do you want to do?:\n1. Add a set\n2. Delete a set\n3. Run a set\n4. Quit?");
            bool flag=false;
            int output;
            do{
                flag=int.TryParse(Console.ReadLine(), out output);
                if(flag==false){
                    Console.WriteLine("not a valid input, please enter your choice again.\nWhat do you want to do?:\n1. Add a set\n2. Delete a set\n3. Run a set\n4. Quit?");
                }
            }while(flag==false);
            
            switch(output){
                case 1: AddASet(userInput);
                break;
               // case 2: DeleteASet();
                //break;
                //case 3: RunASet();
                //break;
                default: return;


        
        }
    }

    // private static void DeleteASet()
    // {
    //     //display the list of setids and ask which setId to delete
    //     var groupStorage = GroupController._groupData;
    //     //groupStorage.AllGroupIds() reads in a list all groups, so as long as we delete from here we can write the 
    //     //update list of groups.
    //     var data = groupStorage.AllGroupIds();
    //     List<int> array = new() ;
    //     Console.WriteLine("Which setid do you want to delete?  Choose the first value.");
    //     foreach(var v in data){
    //         Console.WriteLine($"{v._groupId} {v._groupName} {v._userName}");
    //         array.Add(v._groupId);
    //     }

    //     int result;
    //     //
    //     while(!int.TryParse(Console.ReadLine(), out result) || !array.Contains(result) ){
    //         Console.WriteLine("Error: either the set is not in the existing sets or a bad input occurred, try again");
    //     }
    //     Console.WriteLine(result);
    //     //remove index at
    //     //data.RemoveAt(result);
    //     groupStorage.DeleteGroup(result);
    //     Console.WriteLine($"set corresponding to Id {result} has been deleted.  The new set list is:");
    //     //int[] array = groupStorage.AllGroupIds().Select(x=>x._groupId).ToArray();
    //     var dataAfter = groupStorage.AllGroupIds();
    //     foreach(var v in dataAfter){
    //         Console.WriteLine($"{v._groupId} {v._groupName} {v._userName}");
    //         //array.Add(data.IndexOf(v));
    //     }
    // }

    // private static void RunASet()
    // {
    //     //grab the premiums for the policies in the set and display the total
    //     var groupStorage = GroupController._groupData;
    //      var data = groupStorage.AllGroupIds();
    //      List<int> array = new() ;
    //     Console.WriteLine("Which setid do you want to run?  Choose the first value.");
    //     foreach(var v in data){
    //         Console.WriteLine($"{v._groupId} {v._groupName} {v._userName}");
    //         array.Add(v._groupId);
    //     }

    //     int result;
    //     //
    //     while(!int.TryParse(Console.ReadLine(), out result) || !array.Contains(result) ){
    //         Console.WriteLine("Error: either the set is not in the existing sets or a bad input occurred, try again");
    //     }
    //     Console.WriteLine(result);

    //     //GroupController runSet = new();
    //     Console.WriteLine($"The total premium for setid {result} is {runSet.RunSet(result)}");
    // }


    private static void AddASet(string userInput)
    {
        Console.WriteLine("For what RiskState?");
        string RiskState=Console.ReadLine();
        //GroupController.CreateGroup(RiskState,userInput);
        //get all policies from PolicyFile that are in RiskState and display them
        
    }
}