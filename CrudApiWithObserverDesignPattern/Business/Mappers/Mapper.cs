using AutoMapper;
using DapperCrudAPIProject.DataAccess.DTOs;
using DapperCrudAPIProject.Entities;

namespace DapperCrudAPIProject.Business.Mappers;

public class Mapper:Profile
{
    public Mapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}