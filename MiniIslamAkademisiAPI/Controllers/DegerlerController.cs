using Microsoft.AspNetCore.Mvc;
using MiniIslamAkademisiAPI.Models;
using System.Text.Json;

namespace MiniIslamAkademisiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DegerlerController : ControllerBase
    {
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

    }
}
