using Microsoft.AspNetCore.Mvc;
using MiniIslamAkademisiAPI.Models;
using System.Text.Json;

namespace MiniIslamAkademisiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        // 📁 Path to the JSON file that stores topic data
        private readonly string _jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "topics.json");

        // ✅ GET: /api/topics - Return all topics
        [HttpGet]
        public IActionResult GetAllTopics()
        {
            if (!System.IO.File.Exists(_jsonPath))
                return Ok(new Dictionary<string, TopicDetail>());

            var json = System.IO.File.ReadAllText(_jsonPath);
            var data = JsonSerializer.Deserialize<Dictionary<string, TopicDetail>>(json);

            return Ok(data ?? new Dictionary<string, TopicDetail>());
        }

        // ✅ GET: /api/topics/{id} - Return a specific topic by ID
        [HttpGet("{id}")]
        public IActionResult GetTopicById(string id)
        {
            if (!System.IO.File.Exists(_jsonPath))
                return NotFound(new { message = "Topic file not found." });

            var json = System.IO.File.ReadAllText(_jsonPath);
            var data = JsonSerializer.Deserialize<Dictionary<string, TopicDetail>>(json);

            if (data != null && data.ContainsKey(id))
                return Ok(data[id]);

            return NotFound(new { message = "Topic not found." });
        }

        // ✅ POST: /api/topics - Add or update a topic
        [HttpPost]
        public IActionResult AddOrUpdateTopic([FromBody] TopicDetail newTopic)
        {
            if (newTopic == null || string.IsNullOrEmpty(newTopic.Id))
                return BadRequest(new { message = "Invalid topic data." });

            Dictionary<string, TopicDetail> data;

            if (System.IO.File.Exists(_jsonPath))
            {
                var json = System.IO.File.ReadAllText(_jsonPath);
                data = JsonSerializer.Deserialize<Dictionary<string, TopicDetail>>(json) ?? new();
            }
            else
            {
                data = new();
            }

            // Add or update the topic
            data[newTopic.Id] = newTopic;

            // Save the updated data to the file
            var updatedJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_jsonPath, updatedJson);

            return Ok(new { message = "Topic added or updated successfully." });
        }

        // ✅ DELETE: /api/topics/{id} - Delete a topic by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteTopic(string id)
        {
            if (!System.IO.File.Exists(_jsonPath))
                return NotFound(new { message = "Topic file not found." });

            var json = System.IO.File.ReadAllText(_jsonPath);
            var data = JsonSerializer.Deserialize<Dictionary<string, TopicDetail>>(json);

            if (data == null || !data.ContainsKey(id))
                return NotFound(new { message = "Topic not found." });

            // Remove the topic from the dictionary
            data.Remove(id);

            // Save the updated data to the file
            var updatedJson = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_jsonPath, updatedJson);

            return Ok(new { message = "Topic deleted successfully." });
        }
    }
}
