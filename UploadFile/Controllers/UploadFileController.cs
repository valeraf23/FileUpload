using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFile.Data.Services;
using UploadFile.Extensions;

namespace UploadFile.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public UploadFileController(IFileService fileService)
        {
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _fileService = fileService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest();
            }

            var uploadFile = file.ConvertToFileInfoModel();
            await _fileService.AddAsync(uploadFile);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Files()
        {
            var result = await _fileService.GetFilesAsync();
            return Ok(result);
        }
    }
}