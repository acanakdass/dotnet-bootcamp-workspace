using DapperCrudAPIProject.DataAccess.DTOs;
using MediatR;

namespace DapperCrudAPIProject.Business.Queries.GetAll;

public class UserGetAllQuery:IRequest<ResponseDto<List<UserDto>>>
{
    
}