using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testimage.Context;
using testimage.Interface;
using testimage.Model;
using testimage.Model.DTO;

namespace testimage.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly DataContext _dbContext;
        public RecipeService(DataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task <Recipe> CreateRecipe(string name)
        {
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Name = name,
                
            };

            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();

            return recipe;
        }

        public async Task<RecipeDto> GetRecipe(Guid RecipeId)
        {
            var recipeDto = await _dbContext.Recipes
            .Where(r => r.Id == RecipeId)
            .Select(r => new RecipeDto
            {
                Id = r.Id,
                Name = r.Name,
                Image = r.Image,
                Ratings = r.Ratings,
                RecipeSteps = r.RecipeSteps,
                IngredientRecipes = r.IngredientRecipes
            })
            .FirstOrDefaultAsync();

            if (recipeDto == null)
            {
                throw new NullReferenceException($"Рецепт с идентификатором {RecipeId} не найден.");
            }

            return recipeDto;
        }
        public async Task<List<Recipe>> GetRecipeWithImages(Guid RecipeId)
        {
            return await _dbContext.Recipes
            .Where(r => r.Id == RecipeId)
            .Join(_dbContext.Images, r => r.Id, i => i.RecipeId, (r, i) => r)
            .ToListAsync();
        }
    }
}
