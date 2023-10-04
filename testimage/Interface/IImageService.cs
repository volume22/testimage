using Microsoft.AspNetCore.Mvc;
using testimage.Model;

namespace testimage.Interface
{
    public interface IImageService
    {
        Task<Image> AddImageToRecipe(Guid RecipeId,byte[] ImageData);
        Task<Image> AddImageToRecipeSteps(Guid RecipeStepsId, byte[] ImageData);
        Task<IActionResult> GetImageById(Guid RecipeId);
        Task<IActionResult> GetImageByStepsId(Guid RecipeStepsId);
        Task<List<RecipeSteps>> GetRecipeWithImages(Guid recipeId);
        Task<Image> DeleteImage(Guid RecipeId);
    }
}
