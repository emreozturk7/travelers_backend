using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ResetController : ControllerBase
    {
        private IResetService _resetService;

        public ResetController(IResetService resetService)
        {
            _resetService = resetService;
        }

        [HttpPost(template: "resetpassword")]
        public IActionResult SendCode(string email)
        {
            var result = _resetService.SendCode(email);
            if (result.Succes)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        
        [HttpPost(template: "checkcode")]
        public IActionResult CheckCode(string email, string code)
        {
            var result = _resetService.CheckCode(email, code);
            if (result.Succes)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
