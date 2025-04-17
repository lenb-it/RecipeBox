using Mapster;

using Recipe.Core.Models;
using Recipe.Data.Entities;

namespace Recipe.Data.MappingConfigs;

public class IngredientMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<IngredientEntity, Ingredient>();
        config.NewConfig<Ingredient, IngredientEntity>();
    }
}
