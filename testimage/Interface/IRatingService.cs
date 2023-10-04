namespace testimage.Interface
{
    public interface IRatingService
    {
        Task<string> AddRatingToRecipe(Guid RecipeId, double remark, string comments);
        Task<double> CalculateAverageRating(Guid RecipeId);
    }
}
