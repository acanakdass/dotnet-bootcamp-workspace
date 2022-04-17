using AspectOriented.Entities;

namespace AspectOriented.Business;

public interface IUserService
{
    User Add(User user);
    List<User> GetAll();
    User GetById(int id);
    
    void Update(User user);

    void Delete(int id);
}