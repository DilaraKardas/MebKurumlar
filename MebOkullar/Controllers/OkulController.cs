using MebOkullar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MebOkullar.ViewModel;
using MebOkullar.Data;
using Microsoft.EntityFrameworkCore;
using MebOkullar.DtoModel;

namespace MebOkullar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OkulController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly MebDbContext _dbContext;
        public OkulController(IHttpClientFactory httpClientFactory, MebDbContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _dbContext = dbContext;
        }

        [HttpPost("okullar/listele")]
        public async Task<IActionResult> OkullarAsync([FromBody] OkulDto okulDto)
        {
            var json = JsonSerializer.Serialize(okulDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            

            var client = _httpClientFactory.CreateClient();
            var okullarTumListe = new List<Okul>();
            int start = 0;
            int length = 100;

            //paging yaparak istek atıyoruz
            while (true)
            {
                var requestUrl = "https://www.meb.gov.tr/baglantilar/okullar/okullar_ajax.php";
                var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);

                //body parametreleri
                var postData = new Dictionary<string, string>
            {
                {"draw", "1"},
                {"start", start.ToString()},
                {"length", length.ToString()},
                {"search[value]", ""},
                {"search[regex]", "false"},
                {"il", ""},
                {"ilce", ""},
            };

                //headers parametreleri 
                request.Content = new FormUrlEncodedContent(postData);
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("Referer", "https://www.meb.gov.tr/baglantilar/okullar/");
                request.Headers.Add("Origin", "https://www.meb.gov.tr");
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/140.0.0.0 Safari/537.36");
                request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");
                request.Headers.Add("accept-encoding", "gzip, deflate, br, zstd");
                request.Headers.Add("Accept-Language", "tr,tr-TR;q=0.9,en-US;q=0.8,en;q=0.7,es;q=0.6");
                request.Headers.Add("Priority", "u=1, i");
                request.Headers.Add("sec-ch-ua", "\"Chromium\";v=\"140\", \"Not=A?Brand\";v=\"24\", \"Google Chrome\";v=\"140\"");
                request.Headers.Add("sec-ch-ua-mobile", "?0");
                request.Headers.Add("sec-ch-ua-platform", "Windows");
                request.Headers.Add("sec-fetch-dest", "empty");
                request.Headers.Add("x-kl-saas-ajax-request", "Ajax_Request");
                request.Headers.Add("sec-fetch-dest", "empty");
                request.Headers.Add("sec-fetch-dest", "empty");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode) break;

                var responseBody = await response.Content.ReadAsStringAsync();
                var dataTableResponse = JsonSerializer.Deserialize<OkulDataVM>(responseBody);

                if (dataTableResponse == null || dataTableResponse.data.Count == 0) break;

                okullarTumListe.AddRange(dataTableResponse.data);
                start += length;

                // Gelen DTO listesini veritabanı modeline çeviriyoruz
                var yeniOkullar = dataTableResponse.data
                    .Select(dto => new Okul
                    {
                        OKUL_ADI = dto.OKUL_ADI,
                        HOST = dto.HOST,
                        YOL = dto.YOL
                    })
                    .ToList();

                // Daha önce eklenmemiş olanları filtreliyoruz
                var eklenecekOkullar = yeniOkullar
                    //.Where(item => !_dbContext.Okullar.Any(o => o.HOST == item.HOST))
                    .ToList();

                if (eklenecekOkullar.Any())
                {
                    _dbContext.Okullar.AddRange(eklenecekOkullar);
                    await _dbContext.SaveChangesAsync();
                }
                await _dbContext.SaveChangesAsync();
            }
            return Ok(okullarTumListe);
        }
      
    }
}