using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebApplication1
{
    public class FileDto
    {
        public string Body { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }
        public string Message { get; set; }
    }
}
