using AspectOriented.Entities;

namespace AspectOriented.DataAccess;

public class Repository
{
    // private static List<User> _users = new List<User>()
    // {
    //     new() {Id = 1, Firstname = "Ahmet", Lastname = "Akdaş", Email = "acan@gmail.com",Roles = {new Role(){Name = "admin"}}},
    //     new() {Id = 2, Firstname = "Can", Lastname = "Aktaş", Email = "can@gmail.com",Roles = {new Role(){Name = "customer"}}},
    //     new() {Id = 1, Firstname = "Alper", Lastname = "Akdaş", Email = "alper@gmail.com",Roles = {new Role(){Name = "customer"}}}
    // };
    private static List<User> _users = new List<User>()
    {
        new() {Id = 1, Firstname = "Ahmet", Lastname = "Akdaş", Email = "acan@gmail.com"},
        new() {Id = 2, Firstname = "Can", Lastname = "Aktaş", Email = "can@gmail.com"},
        new() {Id = 1, Firstname = "Alper", Lastname = "Akdaş", Email = "alper@gmail.com"}
    };

    public List<User> GetAll() => _users;
    public void Save(User user) => _users.Add(user);
    public User GetById(int id) => _users.FirstOrDefault(x => x.Id == id);

    public void Update(User user)
    {
        var userIndex = _users.FindIndex(x => x.Id == user.Id);
        _users[userIndex] = user;
    }

    public void Delete(int id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);
        _users.Remove(user);
    }
}