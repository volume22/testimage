using Microsoft.AspNetCore.Mvc;
using testimage.Model;
using testimage.Model.DTO;

namespace testimage.Interface
{
    public interface IRecipeService
    {
        Task<Recipe> CreateRecipe(string name);
        Task<RecipeDto> GetRecipe(Guid RecipeId);
        Task<List<Recipe>> GetRecipeWithImages(Guid RecipeId);
    }
}
