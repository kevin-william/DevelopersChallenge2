using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OFXFileReader.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OFX_CONCILIACAO_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OFXFileController : ControllerBase
    {

        public OFXFileController(IOFXService ofxService)
        {
            OFXService = ofxService ??
                throw new ArgumentNullException(nameof(ofxService));
        }

        public IOFXService OFXService { get; }

        [HttpPost("Salvar")]
        public async Task<IActionResult> ReadFileAsync(IEnumerable<IFormFile> file)
        {

            var fileListAsStream = new List<Stream>();
            foreach (var f in file)
            {
                fileListAsStream.Add(f.OpenReadStream());
            }

            await OFXService.SaveOFXTransactions(fileListAsStream);

            return Ok();
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(OFXService.Get());
        }        
    }
}
