
using System.ComponentModel.DataAnnotations;
namespace miniLegacyRerater.Models;

public class Group{
    [Key]
    public int _groupId{get; set;}
        
//    [StringLength(40)]
    public string _groupName {get; set;}
    public string _userName{get;set;}
    public DateTime _dateCreated{get;set;}

    public string _policies{get; set;}


    //constructor
    public Group(){}

     public Group(string groupName, int groupId,string userName, DateTime dateCreated,string policies){
       
        _groupId = groupId;
        _groupName = groupName;
        _userName = userName;
        _dateCreated = dateCreated;
        _policies = policies;

    }

}