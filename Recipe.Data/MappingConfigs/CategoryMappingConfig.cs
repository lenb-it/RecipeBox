using Mapster;

using Recipe.Core.Models;
using Recipe.Data.Entities;

namespace Recipe.Data.MappingConfigs;
public class CategoryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CategoryEntity, Category>();

        config.NewConfig<Category, CategoryEntity>()
            .AfterMapping((src, dest) =>
            {
                if (dest.Recipes is null)
                    dest.Recipes = [];
            });
    }
}
