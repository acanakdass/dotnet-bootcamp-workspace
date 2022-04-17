using DapperCrudAPIProject.DataAccess.DTOs;
using MediatR;

namespace DapperCrudAPIProject.Business.Queries.GetById;

public class UserGetByIdQuery:IRequest<ResponseDto<UserDto>>
{
    public int Id { get; set; }
}