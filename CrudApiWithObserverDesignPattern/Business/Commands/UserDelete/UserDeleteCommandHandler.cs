using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.DataAccess.Repositories;
using MediatR;

namespace DapperCrudAPIProject.Business.Commands.UserDelete;

public class UserDeleteCommandHandler:IRequestHandler<UserDeleteCommand,ResponseDto<NoContent>>
{
    private readonly IUserRepository _userRepository;

    public UserDeleteCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResponseDto<NoContent>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.Delete(request);
        if (!result)
        {
            return ResponseDto<NoContent>.Fail("Veri Silme İşlemi Başarısız.",500);
        }
        return ResponseDto<NoContent>.Success(204);
    }
}