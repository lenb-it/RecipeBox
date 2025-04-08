using Mapster;

using Recipe.Core.Models;
using Recipe.Data.Entities;

namespace Recipe.Data.MappingProfiles;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserEntity, User>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Login, src => src.Login)
            .Map(dest => dest.PasswordHash, src => src.PasswordHash)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email)
            .IgnoreNonMapped(true);

        config.NewConfig<User, UserEntity>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Login, src => src.Login)
            .Map(dest => dest.PasswordHash, src => src.PasswordHash)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email)
            .AfterMapping((src, dest) =>
            {
                if (dest.Roles == null)
                    dest.Roles = new List<RoleEntity>();

                if (dest.Recipes == null)
                    dest.Recipes = new List<RecipeEntity>();

                if (dest.RecipeFavorites == null)
                    dest.RecipeFavorites = new List<RecipeFavoriteEntity>();
            })
            .IgnoreNonMapped(true);
    }
}
