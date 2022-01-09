using AutoMapper;
using TeUserManagement.Domain.Dtos;
using TeUserManagement.Domain.Models;

namespace TeUserManagement.Service.Utils.AutoMapper
{
    internal static class AutoMapperMappings
    {
        internal static MapperConfiguration GetMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, UserDto>();
            });
        }
    }
}
