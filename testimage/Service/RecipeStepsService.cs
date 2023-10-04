using testimage.Context;
using testimage.Model.DTO;
using testimage.Model;
using testimage.Interface;
using Microsoft.EntityFrameworkCore;

namespace testimage.Service
{
    public class RecipeStepsService:IRecipeStepsService
    {
        private readonly DataContext _dbContext;
        public RecipeStepsService(DataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<RecipeSteps> CreateRecipeSteps(Guid RecipeId, string description)
        {
            var recipe = new RecipeSteps
            {
                Id = Guid.NewGuid(),
                RecipeId= RecipeId,
                Description = description,
            };

            _dbContext.RecipeSteps.Add(recipe);
            await _dbContext.SaveChangesAsync();

            return recipe;
        }
        public async Task<List<RecipeSteps>> GetRecipeStepsWithImages()
        {
            return await _dbContext.RecipeSteps
                .Include(rs => rs.Image)
                .ToListAsync();
        }

        public async Task<List<RecipeStepsDto>> GetRecipeWithImages(Guid recipeId)
        {
            /*            var result = await _dbContext.RecipeSteps.Where(w=>w.RecipeId == recipeId).ToListAsync();
                        return result;
            */

            var recipeDto = await _dbContext.RecipeSteps
                .Where(r => r.RecipeId == recipeId)
                .Select(r => new RecipeStepsDto
                {
                    Id = r.Id,
                    Description = r.Description,
                    Image = r.Image,
                    RecipeId = r.RecipeId
                })
                .ToListAsync();

            if (recipeDto == null)
            {
                throw new NullReferenceException($"Рецепт с идентификатором {recipeId} не найден.");
            }

            return recipeDto;
        }

      /*  public Task<List<RecipeSteps>> GetRecipeWithImages(Guid RecipeStepsId)
        {
            throw new NotImplementedException();
        }*/
        /* public async Task<RecipeSteps> GetRecipe(Guid RecipeId)
{
var recipeDto = await _dbContext.Recipes
.Where(r => r.Id == RecipeId)
.Select(r => new RecipeDto
{
Id = r.Id,
Name = r.Name,
Image = r.Image,
Ratings = r.Ratings
})
.FirstOrDefaultAsync();

if (recipeDto == null)
{
throw new NullReferenceException($"Рецепт с идентификатором {RecipeId} не найден.");
}

return recipeDto;
}*/
    }
}
