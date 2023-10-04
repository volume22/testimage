using System;
using testimage.Model.Enums;

namespace testimage.Model
{
    public class IngredientRecipe
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public Ingredients Ingredient { get; set; }

        public int Counter { get; set; }
        public Dimension Dimension { get; set; }
    }
}
