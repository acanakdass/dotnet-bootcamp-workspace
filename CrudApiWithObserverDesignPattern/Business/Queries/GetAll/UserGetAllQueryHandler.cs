using AutoMapper;
using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.DataAccess.Repositories;
using MediatR;

namespace DapperCrudAPIProject.Business.Queries.GetAll;

public class UserGetAllQueryHandler:IRequestHandler<UserGetAllQuery,ResponseDto<List<UserDto>>>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UserGetAllQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<ResponseDto<List<UserDto>>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAll();
        var userDtos = _mapper.Map<List<UserDto>>(users);
        return ResponseDto<List<UserDto>>.Success(userDtos, 200);
    }
}