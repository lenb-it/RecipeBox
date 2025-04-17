using Mapster;

using Recipe.Core.Models;
using Recipe.Data.Entities;

namespace Recipe.Data.MappingConfigs;

public class RecipeIngredientMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RecipeIngredientEntity, RecipeIngredient>();

        config.NewConfig<RecipeIngredient, RecipeIngredientEntity>()
            .Map(dest => dest.Ingredient, src => src.Ingredient);
    }
}
