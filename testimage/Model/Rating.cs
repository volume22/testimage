using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace testimage.Model
{
    public class Rating
    {
        [HiddenInput(DisplayValue = false)]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [RequiredAttribute]
        [StringLength(200)]
        public double Remark { get; set; }

        [StringLength(200)]
        public string? Comments { get; set; } = null;
        public Guid RecipeId { get; set; }
        public Recipe recipe { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
