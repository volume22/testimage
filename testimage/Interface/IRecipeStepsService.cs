using testimage.Model.DTO;
using testimage.Model;

namespace testimage.Interface
{
    public interface IRecipeStepsService
    {
        Task<RecipeSteps> CreateRecipeSteps(Guid RecipeId, string description);
        Task<List<RecipeStepsDto>> GetRecipeWithImages(Guid RecipeId);
        /*Task<RecipeSteps> GetRecipe(Guid RecipeStepsId);*/
    }
}
