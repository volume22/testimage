using testimage.Model;

namespace testimage.Interface
{
    public interface IIngredientService
    {
        Task<Ingredients> CreateIngredients(string name);
    }
}
