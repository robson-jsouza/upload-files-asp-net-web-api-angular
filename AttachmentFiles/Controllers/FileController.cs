using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        public FileController()
        {
        }

        [HttpPost]
        public void Send([FromForm] IEnumerable<FileDto> files)
        {
            var emailFromParam = files;
        }
    }
}
