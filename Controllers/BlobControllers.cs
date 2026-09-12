using System.Reflection.Metadata;
using BuildAPI.services;
using Microsoft.AspNetCore.Mvc;

namespace BuildAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlobController : ControllerBase
    {
        private readonly AzureBlobService _blobService;

        public BlobController(AzureBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                return BadRequest("Please Select a file.");
            }

            await _blobService.UploadFileAsync(file.OpenReadStream(),file.FileName,file.ContentType);
            return Ok(new 
               { message  = "File Upload Successfully",
                filename = file.FileName
            });
        }
    }
}