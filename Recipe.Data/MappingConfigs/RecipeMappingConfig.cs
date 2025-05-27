using Mapster;

using Recipe.Data.Entities;

namespace Recipe.Data.MappingConfigs;

public class RecipeMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RecipeEntity, Core.Models.Recipe>()
            .AfterMapping((src, dest) =>
            {
                dest.AverageRating = src.Ratings.Average(r => r.Rating);
            });

        config.NewConfig<Core.Models.Recipe, RecipeEntity>()
            .Map(dest => dest.User, src => src.User)
            .AfterMapping((src, dest) =>
            {
                if (dest.UserFavorites is null)
                    dest.UserFavorites = [];
                if (dest.Ratings is null)
                    dest.Ratings = [];
            });
        ;
    }
}
