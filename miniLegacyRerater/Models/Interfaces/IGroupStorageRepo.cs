namespace miniLegacyRerater.Models;


public interface IGroupStorageRepo
{
    List<Policies> FilterPolicies(string v);

    //Here I will add all of the storage methods
    public void StoreGroup(Group newGroup);
    public int NextGroupId();

    List<Group> AllGroupIds();

    //public void DeleteGroup(List<Group> listOfGroups);  //this is for json
    public void DeleteGroup(int result);
    
}