using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testimage.Model
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? RecipeId { get; set; } = null;
        public Guid? RecipeStepsId { get; set; } = null;
        public byte[] ImageData { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe? Recipe { get; set; } = null;
        [ForeignKey(nameof(RecipeStepsId))]
        public virtual RecipeSteps? RecipeStepsStep { get; set; } = null;
    }
}
