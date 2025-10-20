using Microsoft.AspNetCore.Mvc;
using MebOkullar.Service;
using HtmlAgilityPack;

namespace MebOkullar.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OzelOkulConroller : ControllerBase
    {
        private readonly OzelOkulService _service;

        public OzelOkulConroller(OzelOkulService service)
        {
            _service = service;
        }

        [HttpPost("scrape-and-save")]
        public async Task<IActionResult> ScrapeAndSave()
        {
            var count = await _service.ScrapeAsync();
            return Ok(new { message = "Veriler kaydedildi", count });
        }


    }
}



