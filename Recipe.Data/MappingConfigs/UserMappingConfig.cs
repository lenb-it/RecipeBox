﻿using Mapster;

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
                    dest.Roles = [];

                if (dest.Recipes == null)
                    dest.Recipes = [];

                if (dest.RecipeFavorites == null)
                    dest.RecipeFavorites = [];
            });
    }
}