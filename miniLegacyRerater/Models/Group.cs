

namespace miniLegacyRerater.Models;

public class Group{
    public int _groupId{get; set;}
    public string _name {get; set;}
    public List<int> _policies{get;set;}
    public string _userName{get;set;}


    //constructor
    public Group(){}

     public Group(string name, List<int> policies, int groupId,string userName){
       
        _groupId = groupId;
        _name = name;
        _policies=policies;
        _userName = userName;

    }

}