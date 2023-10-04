using Microsoft.EntityFrameworkCore;
using testimage.Context;
using testimage.Interface;
using testimage.Model;
using testimage.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-Q61IKQ5;Initial Catalog=qq;Trusted_Connection=True;Encrypt=False");
});
builder.Services.AddControllers();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IIngredientService, IngredientServicecs>();
builder.Services.AddScoped<IRecipeStepsService, RecipeStepsService>();
builder.Services.AddScoped<IIngredientsRecipe, IngredientsRecipeService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
