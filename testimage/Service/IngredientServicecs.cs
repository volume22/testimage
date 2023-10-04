using testimage.Context;
using testimage.Interface;
using testimage.Model;

namespace testimage.Service
{
    public class IngredientServicecs : IIngredientService
    {
        private readonly DataContext _dbContext;

        public IngredientServicecs(DataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

       
        public async Task<Ingredients> CreateIngredients(string name)
        {
            var ingredient = new Ingredients
            {
                Name = name
            };

            _dbContext.Ingridients.Add(ingredient);
            await _dbContext.SaveChangesAsync();
            return ingredient;
        }
    }
}
