using Mapster;

using Recipe.Core.Models;
using Recipe.Data.Entities;

namespace Recipe.Data.MappingConfigs;
public class TagMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TagEntity, Tag>();

        config.NewConfig<Tag, TagEntity>()
            .AfterMapping((src, dest) =>
            {
                if (dest.Recipes is null)
                    dest.Recipes = [];
            });
    }
}
