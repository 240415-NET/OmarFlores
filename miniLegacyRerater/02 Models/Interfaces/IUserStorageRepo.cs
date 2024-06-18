namespace miniLegacyRerater.Models;


public interface IUserStorageRepo
{
    //Here I will add all of the storage methods
    public void StoreUser(User user);
    public Task<User> FindUser(string usernameToFind);

}