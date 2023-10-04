using System.ComponentModel.DataAnnotations;

namespace testimage.Model
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(300, MinimumLength = 20)]
        public virtual Image Image { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; } = null!;
        public virtual ICollection<RecipeSteps> RecipeSteps { get; set; } = null!;
        public virtual ICollection<IngredientRecipe> IngredientRecipes { get; set; }=null!;
        public Recipe()
        {
            Ratings = new List<Rating>();
            RecipeSteps= new List<RecipeSteps>();
            IngredientRecipes = new List<IngredientRecipe>();
        }
    }
}
