using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.Entities;
using MediatR;
namespace DapperCrudAPIProject.API.Commands.UserUpdate
{
    public class UserUpdateCommand : IRequest<ResponseDto<NoContent>>
    {
        public int Id { get; set; }
        public User UserToUpdate { get; set; }
    }
}
