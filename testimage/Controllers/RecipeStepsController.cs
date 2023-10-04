using Microsoft.AspNetCore.Mvc;
using testimage.Interface;
using testimage.Model;

namespace testimage.Controllers
{
    [ApiController]
    [Route("api/recipe-steps")]
    public class RecipeStepsController : ControllerBase
    {
        private readonly IRecipeStepsService _recipeStepService;

        public RecipeStepsController(IRecipeStepsService recipeStepService)
        {
            _recipeStepService = recipeStepService;
        }
        [HttpPost]
        public async Task<RecipeSteps> CreateRecipe(Guid RecipeId,string description)
        {

            var recipe = await _recipeStepService.CreateRecipeSteps(RecipeId, description);
            return recipe;
        }
        [HttpGet]
        [Route("api/recipe-steps")]
        public async Task<IActionResult> GetRecipeStepsImage(Guid RecipeId)
        {
            var recipe = await _recipeStepService.GetRecipeWithImages(RecipeId);
            return Ok(recipe);
        }
    }// вывод степов по рецепт ид
}
