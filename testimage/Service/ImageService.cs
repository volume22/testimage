using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testimage.Context;
using testimage.Interface;
using testimage.Model;
using static System.Net.Mime.MediaTypeNames;
using Image = testimage.Model.Image;

namespace testimage.Service
{
    public class ImageService : IImageService
    {
        private readonly DataContext _dbContext;
        public ImageService(DataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Image> AddImageToRecipe(Guid RecipeId, byte[] ImageData)
        {
            var recipe = await _dbContext.Recipes.FindAsync(RecipeId);

            var image = new Image
            {
                RecipeId = RecipeId,
                ImageData = ImageData
            };

            _dbContext.Images.Add(image);
            await _dbContext.SaveChangesAsync();
            return image;
        }
        public async Task<Image> AddImageToRecipeSteps( Guid RecipeStepsId, byte[] ImageData)
        {
            var image = new Image
            {
                RecipeStepsId = RecipeStepsId,
                ImageData = ImageData
            };
            _dbContext.Images.Add(image);
            await _dbContext.SaveChangesAsync();
            return image;
        }
        public async Task<Image> DeleteImage(Guid RecipeId)
        {
            var image = await _dbContext.Images.Where(w=>w.RecipeId == RecipeId).FirstAsync();
            _dbContext.Images.Remove(image);
            await _dbContext.SaveChangesAsync();
            return image;
        }

        public async Task<IActionResult> GetImageById(Guid RecipeId)
        {
            var recipe = await _dbContext.Recipes
        .Include(r => r.Image)
        .FirstOrDefaultAsync(r => r.Id == RecipeId);

            

            byte[] imageData = recipe.Image.ImageData;

            // Возвращаем фотографию в виде FileContentResult с указанием типа содержимого
            return new FileContentResult(imageData, "image/jpeg");
        }

        public async Task<IActionResult> GetImageByStepsId(Guid RecipeStepsId)
        {
            var recipe = await _dbContext.RecipeSteps.Include(r => r.Image)
                .FirstOrDefaultAsync(r => r.Id == RecipeStepsId);

            byte[] imageData = recipe.Image.ImageData;

            // Возвращаем фотографию в виде FileContentResult с указанием типа содержимого
            return new FileContentResult(imageData, "image/jpeg");
        }
        public async Task<List<RecipeSteps>> GetRecipeWithImages(Guid recipeId)
        {
            var recipe= await _dbContext.RecipeSteps
                .Include(rs => rs.Image)
                .Where(rs => rs.RecipeId == recipeId)
                .ToListAsync();
           /* byte[] imageData = recipe.FirstOrDefault().Image.ImageData;*/

            // Возвращаем фотографию в виде FileContentResult с указанием типа содержимого
            return recipe;
        }
    }
}
