using Microsoft.AspNetCore.Mvc;
using testimage.Context;
using testimage.Interface;
using testimage.Model;
using testimage.Service;

namespace testimage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImgCntrl:ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly DataContext _dataContext;
        public ImgCntrl(DataContext dataContext, IImageService imageService)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _imageService = imageService ?? throw new ArgumentNullException(nameof(imageService));
            
        }
        /*[HttpPost]
        [Route("create/")]
        public async Task<IActionResult> AddImageToRecipe(Guid RecipeId,[FromBody] byte[] ImageData)
        {
            *//*var newImage = await _imageService.AddImageToRecipe(RecipeId,ImageData);
            var imageDto = _mapper.Map<ImageDTO>(newImage);
            GenericReply<ImageDTO> reply = new();
            return Ok(reply);*/
            /*var newImage = await _imageService.AddImageToRecipe(RecipeId, ImageData);
            
            return Ok(newImage);*//*
            try
            {
                var newImage = await _imageService.AddImageToRecipe(RecipeId, ImageData);
                return Ok(newImage);
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an appropriate response
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the recipe.");
            }
            
        }*/
        [HttpPost]
        [Route("create-recipe-image/")]
        public async Task<IActionResult> UploadImageRecipe(Guid RecipeId, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                // Обработка случая, когда файл не был передан
                return BadRequest("No image file found.");
            }

            // Чтение содержимого файла в массив байтов
            byte[] ImageData;
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                ImageData = memoryStream.ToArray();
            }
            var newImage = await _imageService.AddImageToRecipe(RecipeId,ImageData);
            return Ok(newImage);   
        }
        [HttpPost]
        [Route("create-recipesteps-image/")]
        public async Task<IActionResult> UploadImageRecipeSteps(Guid RecipeStepsId, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                // Обработка случая, когда файл не был передан
                return BadRequest("No image file found.");
            }

            // Чтение содержимого файла в массив байтов
            byte[] ImageData;
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                ImageData = memoryStream.ToArray();
            }
            var newImage = await _imageService.AddImageToRecipeSteps(RecipeStepsId, ImageData);
            return Ok(newImage);
        }
        [HttpGet]
        [Route("showid/")]
        public async Task<IActionResult> GetRecipeImage(Guid RecipeId)
        {
            var newImage = await _imageService.GetImageById(RecipeId);
            return Ok(newImage);

        }
        [HttpGet]
        [Route("showstepsid/")]
        public async Task<IActionResult> GetRecipeImageSteps(Guid RecipeId)
        {
            var newImage = await _imageService.GetRecipeWithImages(RecipeId);
            return Ok(newImage);

        }
        [HttpDelete]
        [Route("delete/")]
        public async Task<IActionResult> DeleteImage(Guid RecipeId) 
        {
            var data= await _imageService.DeleteImage(RecipeId);
            return Ok(data);
        }
    }
}
