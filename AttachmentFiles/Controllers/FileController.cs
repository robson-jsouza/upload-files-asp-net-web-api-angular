using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public void Send([FromForm] IEnumerable<FileExtendedDto> files)
        {
            var emailFromParam = files;
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
