namespace testimage.Model.DTO
{
    public class RecipeStepsDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid RecipeId { get; set; }
        public virtual Image Image { get; set; }
    }
}
