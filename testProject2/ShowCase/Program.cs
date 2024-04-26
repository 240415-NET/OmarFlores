namespace UtilityLibraries;

public class Program{
    public static void Main(string[] args){
        bool cont = true;


        
        string word;
        //StringLibrary check = new StringLibrary();
        do{
        Console.WriteLine("Enter a word");
        word = Console.ReadLine();
        //check.IsCapital(word);
        Console.WriteLine($"{word} first letter is capital {(word.StartsWithUpper() ? "Y":"N")}");
        Console.WriteLine("do you want to continue y/n");
        
        if(Console.ReadLine().ToLower()=="y")
        cont=true;
        else cont = false;

        }while(cont);
    }
}