using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1.Controllers
{
    [ApiController]
    [Route("Upload")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("SetPicture")]
        public async Task<IActionResult> SetPicture(IFormFile file)
        {
            var folder = "Pictures/";

            //  fileName + guid + extension

            var path = Path.Combine(_env.WebRootPath, folder, Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(path);
        }
    }
}
