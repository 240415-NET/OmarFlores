namespace miniLegacyRerater.Models;


public interface IGroupStorageRepo
{
    List<string> FilterPolicies(string v);

    //Here I will add all of the storage methods
    public void StoreGroup(Group newGroup);
    public int NextGroupId();

    List<Group> AllGroupIds();

    public void DeleteGroup(List<Group> listOfGroups);
    
}