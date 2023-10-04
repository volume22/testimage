using System.ComponentModel.DataAnnotations;

namespace testimage.Model
{
    public class RecipeSteps
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid RecipeId { get; set; }
        public virtual Image Image { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
