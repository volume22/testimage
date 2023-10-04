using Microsoft.AspNetCore.Mvc;
using testimage.Interface;
using testimage.Model;

namespace testimage.Controllers
{
    [ApiController]
    [Route("api/ingr")]
    public class IngredientsController:ControllerBase
    {
        private readonly IIngredientService _ingredient;

        public IngredientsController(IIngredientService ingredient)
        {
            _ingredient = ingredient;
        }
        [HttpPost]
        public async Task<IActionResult> CreateIngredient(string comments)
        {
            var recipe = await _ingredient.CreateIngredients(comments); 
            return Ok(recipe);
        }
    }
}
