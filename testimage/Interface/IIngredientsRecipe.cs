using testimage.Model;
using testimage.Model.Enums;

namespace testimage.Interface
{
    public interface IIngredientsRecipe
    {
        Task<IngredientRecipe> CreateIngredientRecipe(Guid RecipeId,int IngredientsId,int count,Dimension dimension);
    }
}
