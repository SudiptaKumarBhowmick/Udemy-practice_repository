using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route(template: "[Controller]")]
    public class DepartmentController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get ALl Student");
        }

        [HttpGet(template: "{code}")]
        public IActionResult GetA(string code)
        {
            return Ok("Get this " + code + " department data.");
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return Ok("Insert new department.");
        }

        [HttpPut(template: "{code}")]
        public IActionResult Update(string code)
        {
            return Ok("Update this " + code + " department data.");
        }

        [HttpDelete(template: "{code}")]
        public IActionResult Delete(string code)
        {
            return Ok("Delete this " + code + "department data.");
        }
    }
}