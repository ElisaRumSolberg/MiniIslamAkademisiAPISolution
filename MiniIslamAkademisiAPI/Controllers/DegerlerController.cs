using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using MiniIslamAkademisiAPI.Models;
using System.Text.Json;

namespace MiniIslamAkademisiAPI.Controllers
=======
using System.Text.Json;
using MinislamAkademisiAPI.Models;

namespace MiniislamAkademisiAPI.Controllers
>>>>>>> 6f4a1a0e316bd4bbb940f09e3ccefdeaed0e3989
{
    [ApiController]
    [Route("api/[controller]")]
    public class DegerlerController : ControllerBase
    {
<<<<<<< HEAD
        private readonly string _jsonDosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "degerler-detaylar.json");

        // ✅ GET: /api/degerler - Tüm konuları getir
        [HttpGet]
        public IActionResult GetKonular()
        {
            if (!System.IO.File.Exists(_jsonDosyaYolu))
                return Ok(new Dictionary<string, KonuDetay>());

            var json = System.IO.File.ReadAllText(_jsonDosyaYolu);
            var veriler = JsonSerializer.Deserialize<Dictionary<string, KonuDetay>>(json);

            return Ok(veriler ?? new Dictionary<string, KonuDetay>());
        }

        // ✅ POST: /api/degerler - Yeni konu ekle veya güncelle
        [HttpPost]
        public IActionResult AddKonu([FromBody] KonuDetay yeniKonu)
        {
            if (yeniKonu == null || string.IsNullOrEmpty(yeniKonu.Id))
                return BadRequest("Konu geçerli değil.");

            Dictionary<string, KonuDetay> veri;

            if (System.IO.File.Exists(_jsonDosyaYolu))
            {
                var json = System.IO.File.ReadAllText(_jsonDosyaYolu);
                veri = JsonSerializer.Deserialize<Dictionary<string, KonuDetay>>(json) ?? new Dictionary<string, KonuDetay>();
            }
            else
            {
                veri = new Dictionary<string, KonuDetay>();
            }

            veri[yeniKonu.Id] = yeniKonu;

            var guncellenmisJson = JsonSerializer.Serialize(veri, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_jsonDosyaYolu, guncellenmisJson);

            return Ok("Konu başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKonu(string id)
        {
            if (!System.IO.File.Exists(_jsonDosyaYolu))
                return NotFound();

            var json = System.IO.File.ReadAllText(_jsonDosyaYolu);
            var veri = JsonSerializer.Deserialize<Dictionary<string, KonuDetay>>(json);

            if (veri == null || !veri.ContainsKey(id))
                return NotFound();

            veri.Remove(id);
            var yeniJson = JsonSerializer.Serialize(veri, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_jsonDosyaYolu, yeniJson);

            return Ok();
        }

=======
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
>>>>>>> 6f4a1a0e316bd4bbb940f09e3ccefdeaed0e3989
    }
}
