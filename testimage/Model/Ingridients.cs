using System.ComponentModel.DataAnnotations;

namespace testimage.Model
{
    public class Ingredients
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IngredientRecipe> IngredientRecipes { get; set; }
        public Ingredients() {
            IngredientRecipes = new List<IngredientRecipe>();
        }
    }
}
