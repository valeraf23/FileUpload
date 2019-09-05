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

            _fileService = fileService
                           ?? throw new ArgumentNullException(nameof(fileService));
            _fileService = fileService;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile uploadedFile)
        {
            var file = uploadedFile.ConvertToFileInfoModel();
            await _fileService.AddAsync(file);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Files()
        {
            var result = await _fileService.GetFilesAsync();
            return Ok(result);

        }
    }
}
