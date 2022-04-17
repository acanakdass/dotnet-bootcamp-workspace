using DapperCrudAPIProject.API.Commands.UserUpdate;
using DapperCrudAPIProject.Business.Commands.UserDelete;
using DapperCrudAPIProject.Business.Commands.UserInsert;
using DapperCrudAPIProject.Entities;

namespace DapperCrudAPIProject.DataAccess.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task<List<User>> GetAllWithPage(int page, int pageSize);
    Task<int> Save(UserInsertCommand userInsertCommand);
    Task<bool> Update(UserUpdateCommand userUpdateCommand);
    Task<bool> Delete(UserDeleteCommand userDeleteCommand);
}