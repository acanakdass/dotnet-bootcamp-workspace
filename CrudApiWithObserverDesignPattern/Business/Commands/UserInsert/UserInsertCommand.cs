using DapperCrudAPIProject.DataAccess.DTOs;
using MediatR;

namespace DapperCrudAPIProject.Business.Commands.UserInsert
{
    public class UserInsertCommand : IRequest<ResponseDto<int>>
    {
        
        public UserInsertDto userToAdd { get; set; }
    }
}
