using DapperCrudAPIProject.DataAccess.DTOs;
using MediatR;

namespace DapperCrudAPIProject.Business.Commands.UserDelete;

public class UserDeleteCommand:IRequest<ResponseDto<NoContent>>
{
    public int Id { get; set; }
}