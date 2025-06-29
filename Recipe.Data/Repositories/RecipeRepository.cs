using MapsterMapper;

using Microsoft.EntityFrameworkCore;

using Recipe.Core.Exceptions;
using Recipe.Core.Repositories.Interfaces;
using Recipe.Data.Contexts;
using Recipe.Data.Entities;

namespace Recipe.Data.Repositories;

public class RecipeRepository(
    RecipeContext dbContext,
    IMapper mapper) : IRecipeRepository
{
    public async Task<IReadOnlyCollection<Core.Models.Recipe>> GetShortInfoPartOfRecipesAsync(
        int startPosition,
        int count,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Recipes
            .AsNoTracking()
            .Skip(startPosition)
            .Take(count)
            .Select(r => mapper.Map<Core.Models.Recipe>(r))
            .ToArrayAsync(cancellationToken);
    }

    public async Task<Core.Models.Recipe?> GetOrDefaultAsync(
        int recipeId,
        CancellationToken cancellationToken = default)
    {
        var recipe = await dbContext.Recipes
            .AsNoTracking()
            .Include(r => r.Tags)
            .Include(r => r.Ratings)
            .Include(r => r.Ingredients)
            .Include(r => r.Categories)
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Id == recipeId, cancellationToken);

        if (recipe is null)
            return null;

        return mapper.Map<Core.Models.Recipe>(recipe);
    }

    // todo check the method for correctness
    public async Task AddAsync(
        Core.Models.Recipe recipe,
        Guid ownerId,
        CancellationToken cancellationToken = default)
    {
        var userOwner = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == ownerId, cancellationToken)
            ?? throw new NotFoundException($"User with id:\'{ownerId}\' not found");

        var recipeEntity = mapper.Map<RecipeEntity>(recipe);
        recipeEntity.User = userOwner;

        //await AddTags(recipeEntity, cancellationToken);
        //await AddCategoriesToRecipe1(recipeEntity, cancellationToken);
        await AddIngredients(recipeEntity, cancellationToken);

        await dbContext.Recipes.AddAsync(recipeEntity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task AddTags(
        RecipeEntity recipeEntity,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private async Task AddCategoriesToRecipe1(
        RecipeEntity recipeEntity,
        CancellationToken cancellationToken)
    {
        var addRecipeCategories = new List<RecipeCategoryEntity>();

        var categoriesIds = recipeEntity
            .Categories
            .Select(i => i.Id);

        var categories = await dbContext.Categories
            .Where(i => categoriesIds.Contains(i.Id))
            .ToListAsync(cancellationToken);

        foreach (CategoryEntity recipeCategory in recipeEntity.Categories)
        {
            var category = categories.FirstOrDefault(
                i => recipeCategory.Id == i.Id);

            if (category is null)
                continue;

            addRecipeCategories.Add(new RecipeCategoryEntity
            {
                CategoryId = category.Id,
                RecipeId = recipeEntity.Id,
            });
        }
        
        recipeEntity.Categories = categories;
        //await dbContext.RecipeCategories.AddRangeAsync(
        //    addRecipeCategories,
        //    cancellationToken);
    }

    private async Task AddIngredients(
        RecipeEntity recipeEntity,
        CancellationToken cancellationToken)
    {
        var addRecipeIngredients = new List<RecipeIngredientEntity>();

        var ingredientIds = recipeEntity
            .Ingredients
            .Select(i => i.Ingredient.Id);

        var ingredients = dbContext.Ingredients
            .Where(i => ingredientIds.Contains(i.Id));

        foreach(RecipeIngredientEntity recipeIngredient in recipeEntity.Ingredients)
        {
            var ingredient = ingredients.FirstOrDefault(
                i => recipeIngredient.Ingredient.Id == i.Id);

            if (ingredient is null)
                continue;

            addRecipeIngredients.Add(new RecipeIngredientEntity
            {
                Ingredient = ingredient,
                Quantity = recipeIngredient.Quantity,
                Recipe = recipeEntity,
                Unit = recipeIngredient.Unit,
            });
        }

        recipeEntity.Ingredients = addRecipeIngredients;
        //await dbContext.RecipeIngredients.AddRangeAsync(addRecipeIngredients);
    }

    public async Task RemoveAsync(
        int recipeId,
        CancellationToken cancellationToken = default)
    {
        var recipeEntity = await dbContext.Recipes
            .FirstOrDefaultAsync(r => r.Id == recipeId, cancellationToken);

        if (recipeEntity is null)
            return;

        dbContext.Recipes.Remove(recipeEntity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    // todo check the method for correctness
    public async Task UpdateAsync(
        Core.Models.Recipe recipe,
        CancellationToken cancellationToken = default)
    {
        var recipeEntity = await dbContext.Recipes
            .Where(r => recipe.Id == r.Id)
            .Include(r => r.User)
            .Include(r => r.Tags)
            .Include(r => r.Categories)
            .Include(r => r.Ingredients)
            .FirstOrDefaultAsync(cancellationToken);

        if (recipeEntity is null)
            throw new ArgumentException($"Recipe with id = {recipe.Id} doesn't exist");

        //todo categories, tags
        UpdateRecipeRecord(recipeEntity, recipe);
        //RemoveDeleted(recipeEntity, recipe);
        //UpdateIngredients(recipeEntity, recipe);
        //AddNewIngredients(recipeEntity, recipe);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private static void UpdateRecipeRecord(
        RecipeEntity entity,
        Core.Models.Recipe recipe)
    {
        entity.Title = recipe.Title;
        entity.CookingTime = recipe.CookingTime;
        entity.Description = recipe.Description;
        entity.Instructions = recipe.Instructions;
        entity.AmountServings = recipe.AmountServings;
        entity.PreparationTime = recipe.PreparationTime;
    }

    //private void RemoveDeleted(RecipeEntity entity, Core.Models.Recipe recipe)
    //{
    //    var removeCategories = entity.Categories
    //        .Where(rc => recipe.Categories.Exists(c => c.Id == rc.Id))
    //        .ToList();

    //    foreach (var recipeCategoryEntity in entity.Categories)
    //    {
    //        if (recipe.Categories.Exists(c => c.Id != recipeCategoryEntity.Id))
    //            entity.Categories.Remove(recipeCategoryEntity);
    //    }

    //    foreach (var recipeTagEntity in entity.Tags)
    //    {
    //        if (recipe.Tags.Exists(c => c.Id != recipeTagEntity.Id))
    //            entity.Tags.Remove(recipeTagEntity);
    //    }

    //    foreach (var recipeIngredientEntity in entity.Ingredients)
    //    {
    //        if (recipe.Ingredients.Exists(c => c.Id != recipeIngredientEntity.Id))
    //            entity.Ingredients.Remove(recipeIngredientEntity);
    //    }
    //}

    //private void UpdateIngredients(RecipeEntity entity, Core.Models.Recipe recipe)
    //{
    //    foreach (var recipeIngredientEntity in entity.Ingredients)
    //    {
    //        var ingredient = recipe.Ingredients
    //            .First(c => c.Id == recipeIngredientEntity.Id);

    //        var ingredientEntity = mapper.Map<IngredientEntity>(ingredient.Ingredient);

    //        recipeIngredientEntity.Unit = ingredient.Unit;
    //        recipeIngredientEntity.Quantity = ingredient.Quantity;
    //        recipeIngredientEntity.Ingredient = ingredientEntity;
    //    }
    //}

    //private void AddNewIngredients(RecipeEntity entity, Core.Models.Recipe recipe)
    //{
    //    var addIngredients = recipe.Ingredients.Where(i => i.Id == 0);

    //    foreach (var ingredient in addIngredients)
    //    {
    //        var ingredientEntity = mapper.Map<RecipeIngredientEntity>(ingredient);
    //        entity.Ingredients.Add(ingredientEntity);
    //    }
    //}
}