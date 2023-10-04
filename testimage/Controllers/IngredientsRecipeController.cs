using Microsoft.AspNetCore.Mvc;
using testimage.Interface;
using testimage.Model.Enums;

namespace testimage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsRecipeController:ControllerBase
    {
        private readonly IIngredientsRecipe _ingredient;

        public IngredientsRecipeController(IIngredientsRecipe ingredient)
        {
            _ingredient = ingredient;
        }
        [HttpPost]
        public async Task<IActionResult> CreateIngredient(Guid RecipeId, int IngredientsId, int count, Dimension dimension)
        {
            var recipe = await _ingredient.CreateIngredientRecipe( RecipeId,  IngredientsId,  count,  dimension);
            return Ok(recipe);
        }
    }
}
