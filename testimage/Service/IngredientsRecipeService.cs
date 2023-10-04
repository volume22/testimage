using testimage.Context;
using testimage.Interface;
using testimage.Model;
using testimage.Model.Enums;

namespace testimage.Service
{
    public class IngredientsRecipeService : IIngredientsRecipe
    {
        private readonly DataContext _dbContext;

        public IngredientsRecipeService(DataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IngredientRecipe> CreateIngredientRecipe(Guid RecipeId, int IngredientsId, int count, Dimension dimension)
        {
            IngredientRecipe ingredientRecipe = new IngredientRecipe
            {
                RecipeId = RecipeId,
                IngredientId = IngredientsId,
                Counter = count,
                Dimension = dimension
            };

            // Save the ingredientRecipe to a database or perform other required actions
            _dbContext.IngredientRecipes.Add(ingredientRecipe);
            await _dbContext.SaveChangesAsync();
            // Return the created ingredientRecipe
            return ingredientRecipe;
        }

       
    }
}
