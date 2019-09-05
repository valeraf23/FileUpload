using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using UploadFile.Domain.Models;
using UploadFile.Extensions;

namespace UploadFile.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFileProvider _fileProvider;
        public UploadFileController(IHostingEnvironment environment, IFileProvider fileProvider)
        {
            _hostingEnvironment = environment;
            _fileProvider = fileProvider;
    }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult Files()
        {
            var result = new List<FileInfoModel>();

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (Directory.Exists(uploads))
            {
                foreach (var fileInfo in _fileProvider.GetDirectoryContents("wwwroot/uploads"))
                {
                    var fileInfoModel = fileInfo.ConvertToFileInfoModel();
                    result.Add(fileInfoModel);
                }

            }

            return Ok(result);

        }
    }
}
