namespace miniLegacyRerater.Models;


public interface IGroupStorageRepo
{
    Task<List<int>> FilterPolicies(string v);

    //Here I will add all of the storage methods
    Task<string> StoreGroup(Group newGroup);
    public int NextGroupId();

    List<Group> AllGroupIds();

    //public void DeleteGroup(List<Group> listOfGroups);  //this is for json
    public void DeleteGroup(int result);
    //public void RunSet(int result);
    public decimal getPremiums(int result);
    
}