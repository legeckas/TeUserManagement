using AutoMapper;
using TeUserManagement.Domain.Dtos.User;
using TeUserManagement.Domain.Models.User;

namespace TeUserManagement.Service.Utils.AutoMapper
{
    internal static class AutoMapperMappings
    {
        internal static MapperConfiguration GetMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, GetUserDto>();
            });
        }
    }
}
