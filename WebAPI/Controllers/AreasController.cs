using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : Controller
    {
        private IAreasService _areasService;

        public AreasController(IAreasService areasService)
        {
            _areasService = areasService;
        }

        [HttpGet(template: "getall")]
        [Authorize(Roles = "Areas.List")]
        public ActionResult GetList()
        {
            var result = _areasService.GetList();
            if (result.Succes)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet(template: "getlistcategory")]
        public IActionResult GetListCategory(int categoryid)
        {
            var result = _areasService.GetListCategory(categoryid);
            if (result.Succes)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int areaid)
        {
            var result = _areasService.GetById(areaid);
            if (result.Succes)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(Areas area)
        {
            var result = _areasService.Add(area);
            if (result.Succes)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Areas area)
        {
            var result = _areasService.Update(area);
            if (result.Succes)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(Areas area)
        {
            var result = _areasService.Delete(area);
            if (result.Succes)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
