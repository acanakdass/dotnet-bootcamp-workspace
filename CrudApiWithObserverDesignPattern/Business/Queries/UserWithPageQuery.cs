
using DapperCrudAPIProject.DataAccess.DTOs;
using MediatR;

namespace DapperCrudAPIProject.Business.Queries
{
    public class UserWithPageQuery : IRequest<ResponseDto<List<UserDto>>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
