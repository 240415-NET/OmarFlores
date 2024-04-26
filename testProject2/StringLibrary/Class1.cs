namespace UtilityLibraries;

public static class StringLibrary{


    public static bool StartsWithUpper(this string? str){
        char ch = str[0];
        return char.IsUpper(ch);
    }
}