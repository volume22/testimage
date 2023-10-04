using Microsoft.EntityFrameworkCore;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using testimage.Model;

namespace testimage.Context
{
    public class DataContext:DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<RecipeSteps> RecipeSteps { get; set; }
        public DbSet<Ingredients> Ingridients { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-Q61IKQ5;Initial Catalog=qq;Trusted_Connection=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          
            base.OnModelCreating(builder);

            builder.Entity<Image>()
                .HasOne(i => i.Recipe)
                .WithOne(r => r.Image)
                .HasForeignKey<Image>(i => i.RecipeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Image>()
                .HasOne(i => i.RecipeStepsStep)
                .WithOne(rs => rs.Image)
                .HasForeignKey<Image>(i => i.RecipeStepsId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<IngredientRecipe>()
        .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            builder.Entity<IngredientRecipe>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.IngredientRecipes)
                .HasForeignKey(ri => ri.RecipeId);

            builder.Entity<IngredientRecipe>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.IngredientRecipes)
                .HasForeignKey(ri => ri.IngredientId);

            builder.Entity<IngredientRecipe>()
                .Property(ri => ri.Counter)
                .IsRequired();

            builder.Entity<IngredientRecipe>()
                .Property(ri => ri.Dimension)
                .IsRequired();
            /*
                        builder.Entity<Recipe>()
                         .HasMany(c => c.Ingridients)
                         .WithMany(p => p.Recipes)
                            .Map(m => {
                                // Ссылка на промежуточную таблицу
                                m.ToTable("IngredientsRecipe");

                                // Настройка внешних ключей промежуточной таблицы
                                m.MapLeftKey("RecipeId");
                                m.MapRightKey("IngredientId");
                            });*/


        }
    }
}
