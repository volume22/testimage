using Microsoft.EntityFrameworkCore;
using testimage.Context;
using testimage.Interface;
using testimage.Model;

namespace testimage.Service
{
    public class RatingService : IRatingService
    {
        private readonly DataContext _dbContext;

        public RatingService(DataContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<string> AddRatingToRecipe(Guid RecipeId, double remark, string comments)
        {
            try
            {
                var data = await _dbContext.Recipes.FindAsync(RecipeId);

                var mark = new Rating
                {
                    RecipeId = RecipeId,
                    Remark = remark,
                    Comments = comments
                };

                /*_dbContext.Images.Add(mark);
                await _dbContext.SaveChangesAsync();
                return mark;*/
                /*.Select(s => new Rating
                {
                    RecipeId = RecipeId,
                    Remark = remark,
                    Comments = comments
                })
                .FirstOrDefault();*/

                _dbContext.Ratings.Add(mark);
                await _dbContext.SaveChangesAsync();

                return "Вы успешно оценили!";
            }
            catch (Exception ex)
            {
                return "Попробуйте позже";
            }
        }

        public async Task<double> CalculateAverageRating(Guid RecipeId)
        {
            var ratingsTask = _dbContext.Ratings
                .Where(r => r.RecipeId == RecipeId)
                .ToListAsync();

            var ratings = await ratingsTask;

            // Рассчет среднего значения рейтингов
            double averageRating = 0.0;
            if (ratings.Count > 0)
            {
                averageRating = ratings.Average(r => r.Remark);
            }

            // Возвращение среднего значения рейтинга
            return averageRating;
        }
    }
}
