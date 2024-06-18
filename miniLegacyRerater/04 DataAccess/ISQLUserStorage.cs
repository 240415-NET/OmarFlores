
namespace miniLegacyRerater.Data;
using miniLegacyRerater.Models;

public interface ISQLUserStorage {

public Task<User> FindUser(string userNameToFind);
public void StoreUser(User user);

}