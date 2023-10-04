using Microsoft.AspNetCore.Mvc;
using testimage.Interface;
using testimage.Model;
using testimage.Model.DTO;

namespace testimage.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeConrtoller : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeConrtoller(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        [HttpPost]
        public async Task<Recipe> CreateRecipe(string name)
        {

            var recipe = await _recipeService.CreateRecipe(name);
            return recipe;


        }
        [HttpGet]
        public async Task<RecipeDto> GetRecipe(Guid id)
        {

            var recipe = await _recipeService.GetRecipe(id);
            return recipe;
        }
    }
}
