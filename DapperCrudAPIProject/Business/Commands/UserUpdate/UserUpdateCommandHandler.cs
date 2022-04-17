using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.DataAccess.Repositories;
using MediatR;

namespace DapperCrudAPIProject.API.Commands.UserUpdate
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, ResponseDto<NoContent>>
    {
        private readonly IUserRepository _repository;

        public UserUpdateCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResponseDto<NoContent>> Handle(UserUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _repository.Update(request);
            if (!result)
            {
                return ResponseDto<NoContent>.Fail("Güncelleme İşlemi başarısız.", 500);
            }

            return ResponseDto<NoContent>.Success(204);
        }
    }
}