

namespace miniLegacyRerater.Models;

public class Group{
    public int _groupId{get; set;}
    public string _name {get; set;}
    public string _listOfPolicies{get;set;}


    //constructor
    public Group(){}

     public Group(string name, string listOfPolicies, int groupId){
       
        _groupId = groupId;
        _name = name;
        _listOfPolicies=listOfPolicies;

    }

}