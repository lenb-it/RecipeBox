using AutoMapper;

using Recipe.Core.Models;
using Recipe.Data.Entities;

namespace Recipe.Data.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserEntity, User>();
        CreateMap<User, UserEntity>();
    }
}
