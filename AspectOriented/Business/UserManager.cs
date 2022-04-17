using AspectOriented.Core.Aspects.Autofac.Logging;
using AspectOriented.Core.Aspects.Autofac.Validation;
using AspectOriented.DataAccess;
using AspectOriented.Entities;
using AspectOriented.Validators;

namespace AspectOriented.Business;
public class UserManager : IUserService
{
    private Repository _repository = new Repository();
    

    [LogAspect]
    [ValidationAspect(typeof(UserValidator))]
    public User Add(User user)
    {
        _repository.Save(user);
        return user;
    }

    [LogAspect]
    public List<User> GetAll()
    {

        return _repository.GetAll();
    }
    [LogAspect]
    public User GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Update(User user)
    {
        _repository.Update(user);
    }

    [LogAspect]
    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}