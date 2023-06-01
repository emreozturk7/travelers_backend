using Business.Abstract;
using Business.Constants;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost(template: "add")]
        public IActionResult Add([FromForm] Images image)
        {
            var result = _imageService.Add(image);
            if (result.Succes)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
