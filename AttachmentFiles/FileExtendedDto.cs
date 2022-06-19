using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebApplication1
{
    public class FileExtendedDto : FileDto
    {
        public IEnumerable<IFormFile> Files { get; set; }
    }
}
