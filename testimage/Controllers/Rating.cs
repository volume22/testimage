using Microsoft.AspNetCore.Mvc;
using testimage.Interface;
using testimage.Model;

namespace testimage.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class Rating : ControllerBase
    {
        private readonly IRatingService _ratingservice;

        public Rating(IRatingService ratingservice)
        {
            _ratingservice = ratingservice;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRating(Guid RecipeId, double remark, string? comments)
        {
                var recipe = await _ratingservice.AddRatingToRecipe(RecipeId, remark, comments);
                return Ok(recipe);
        }
        [HttpGet]
        public async Task<IActionResult> ShowAvg(Guid RecipeId)
        {

            var recipe = await _ratingservice.CalculateAverageRating(RecipeId);
            return Ok(recipe);


        }
    }
}
