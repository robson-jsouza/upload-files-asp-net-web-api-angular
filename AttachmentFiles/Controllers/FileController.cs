using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileController(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        [HttpPost]
        public async Task Send([FromForm] IEnumerable<FileExtendedDto> files)
        {
            string uploads = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads");
            Directory.CreateDirectory(uploads);
            foreach (IFormFile file in files.SelectMany(f => f.Files))
            {
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(uploads, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
        }

        [HttpPost]
        [Route("SendFilesSeparately")]
        public void SendFilesSeparately([FromForm] string filesJson, IEnumerable<IFormFile> physicalFiles)
        {
            // string example for the filesJson parameter =
            //              [{"body":"body1", "message":"message1"}, {"body":"body2", "message":"message2"}]
            var files = JsonConvert.DeserializeObject<List<FileDto>>(filesJson);
        }
    }
}
