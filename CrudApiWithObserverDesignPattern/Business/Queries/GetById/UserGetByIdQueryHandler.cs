using AutoMapper;
using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.DataAccess.Repositories;
using MediatR;
namespace DapperCrudAPIProject.Business.Queries.GetById;

public class UserGetByIdQueryHandler:IRequestHandler<UserGetByIdQuery,ResponseDto<UserDto>>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UserGetByIdQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseDto<UserDto>> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.Id);
        var userDto = _mapper.Map<UserDto>(user);
        return ResponseDto<UserDto>.Success(userDto);
    }
}