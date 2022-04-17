using AutoMapper;
using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.DataAccess.Repositories;
using MediatR;

namespace DapperCrudAPIProject.Business.Queries
{
    public class UserWithPageQueryHandler : IRequestHandler<UserWithPageQuery, ResponseDto<List<UserDto>>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserWithPageQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<UserDto>>> Handle(UserWithPageQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllWithPage(request.Page, request.PageSize);
            var result = _mapper.Map<List<UserDto>>(users);
            return ResponseDto<List<UserDto>>.Success(result, 200);
        }
    }
}
