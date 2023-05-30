using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int favoriteId)
        {
            var result = _favoriteService.GetById(favoriteId);
            if (result.Succes)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(Favorite favorite)
        {
            var result = _favoriteService.Add(favorite);
            if (result.Succes)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Favorite favorite)
        {
            var result = _favoriteService.Update(favorite);
            if (result.Succes)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
