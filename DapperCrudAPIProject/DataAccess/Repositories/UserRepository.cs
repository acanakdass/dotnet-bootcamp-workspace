using System.Data;
using Dapper;
using DapperCrudAPIProject.API.Commands.UserUpdate;
using DapperCrudAPIProject.Business.Commands.UserDelete;
using DapperCrudAPIProject.Business.Commands.UserInsert;
using DapperCrudAPIProject.Entities;

namespace DapperCrudAPIProject.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _connection;

    public UserRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<User>> GetAll()
    {
        var query = "select * from users";
        var users = await _connection.QueryAsync<User>(query);
        var res = users.ToList();
        return res;
    }

    public async Task<User> GetById(int id)
    {
        var query = "select * from users where id=@id";
        var user = await _connection.QueryFirstOrDefaultAsync<User>(query, new {id = id});
        return user;
    }

    public async Task<List<User>> GetAllWithPage(int page, int pageSize)
    {
        var offset = (page - 1) * pageSize;
        var query = "select * from users order by id desc limit @pagesize offset @offset";
        var users = await _connection.QueryAsync<User>(query, new {pagesize = pageSize, offset = offset});
        return users.ToList();
    }

    public async Task<int> Save(UserInsertCommand userInsertCommand)
    {
        var command ="insert into users(name,password,email,phone) values(@name,@password,@email,@phone) returning id";
        var id = await _connection.ExecuteScalarAsync<int>(command, userInsertCommand.userToAdd);
        return id;
    }

    public async Task<bool> Update(UserUpdateCommand userUpdateCommand)
    {
        var command = "update users set name=@name,password=@password,email=@email,phone=@phone where id=@id";
        return await _connection.ExecuteAsync(command, userUpdateCommand.UserToUpdate)>0;
    }



    public async Task<bool> Delete(UserDeleteCommand userDeleteCommand)
    {
        var command = "delete from users where id=@id";
        return await _connection.ExecuteAsync(command, userDeleteCommand)>0;
    }

}