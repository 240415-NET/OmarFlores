

namespace miniLegacyRerater.Models;

public class Group{
    public int _groupId{get; set;}
    public string _name {get; set;}
    public string _listOfPolicies{get;set;}
    public string _userName{get;set;}


    //constructor
    public Group(){}

     public Group(string name, string listOfPolicies, int groupId,string userName){
       
        _groupId = groupId;
        _name = name;
        _listOfPolicies=listOfPolicies;
        _userName = userName;

    }

}