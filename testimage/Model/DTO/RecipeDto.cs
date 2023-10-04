namespace testimage.Model.DTO
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<RecipeSteps> RecipeSteps { get; set; }

        public virtual ICollection<IngredientRecipe> IngredientRecipes { get; set; }
    }
}
