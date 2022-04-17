using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.DataAccess.Repositories;
using MediatR;

namespace DapperCrudAPIProject.Business.Commands.UserInsert
{
    public class UserInsertCommandHandler : IRequestHandler<UserInsertCommand, ResponseDto<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator mediator;

        public UserInsertCommandHandler(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            this.mediator = mediator;
        }

        public async Task<ResponseDto<int>> Handle(UserInsertCommand request, CancellationToken cancellationToken)
        {
            var id = await _userRepository.Save(request);
            return ResponseDto<int>.Success(id,200);
        }
    }
}
