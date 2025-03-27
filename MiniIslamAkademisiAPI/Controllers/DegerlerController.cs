using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using MinislamAkademisiAPI.Models;

namespace MiniislamAkademisiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DegerlerController : ControllerBase
    {
        private readonly string _jsonPath = "wwwroot/data/degerler-detaylar.json";

        // GET: api/Degerler
        [HttpGet]
        public IActionResult GetAll()
        {
            if (!System.IO.File.Exists(_jsonPath))
                return NotFound("Veri dosyası bulunamadı.");

            var json = System.IO.File.ReadAllText(_jsonPath);
            var data = JsonSerializer.Deserialize<Dictionary<string, KonuDetay>>(json);
            return Ok(data);
        }

        // GET: api/Degerler/namaz
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var json = System.IO.File.ReadAllText(_jsonPath);
            var data = JsonSerializer.Deserialize<Dictionary<string, KonuDetay>>(json);

            if (data != null && data.ContainsKey(id))
                return Ok(data[id]);

            return NotFound("Konu bulunamadı.");
        }

        // POST: api/Degerler
        [HttpPost]
        public IActionResult Add([FromBody] KeyValuePair<string, KonuDetay> yeniKonu)
        {
            var json = System.IO.File.ReadAllText(_jsonPath);
            var data = JsonSerializer.Deserialize<Dictionary<string, KonuDetay>>(json) ?? new();

            data[yeniKonu.Key] = yeniKonu.Value;

            var updatedJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_jsonPath, updatedJson);

            return Ok(new { message = "Konu başarıyla eklendi.", key = yeniKonu.Key });
        }
    }
}
