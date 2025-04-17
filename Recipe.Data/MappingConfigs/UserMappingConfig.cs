using Mapster;

using Recipe.Core.Models;
using Recipe.Data.Entities;

namespace Recipe.Data.MappingConfigs;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserEntity, User>();

        config.NewConfig<User, UserEntity>()
            .AfterMapping((src, dest) =>
            {
                if (dest.Roles == null)
                    dest.Roles = new List<RoleEntity>();

                if (dest.Recipes == null)
                    dest.Recipes = new List<RecipeEntity>();

                if (dest.RecipeFavorites == null)
                    dest.RecipeFavorites = new List<RecipeFavoriteEntity>();
            });
    }
}