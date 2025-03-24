using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

[ApiController]
[Route("api/videos")]
public class VideosController : ControllerBase
{
    private readonly string jsonFilePath = "wwwroot/data/videos.json";

    [HttpGet]
    public IActionResult GetVideos()
    {
        if (!System.IO.File.Exists(jsonFilePath))
            return Ok(new List<Video>());

        var jsonData = System.IO.File.ReadAllText(jsonFilePath);
        var videos = JsonSerializer.Deserialize<List<Video>>(jsonData);
        return Ok(videos);
    }

    [HttpPost]
    public IActionResult AddVideo([FromBody] Video video)
    {
        var videos = new List<Video>();

        if (System.IO.File.Exists(jsonFilePath))
        {
            var jsonData = System.IO.File.ReadAllText(jsonFilePath);
            videos = JsonSerializer.Deserialize<List<Video>>(jsonData);
        }

        videos.Add(video);
        var updatedJson = JsonSerializer.Serialize(videos, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(jsonFilePath, updatedJson);

        return Ok(video);
    }
}

public class Video
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string YouTubeUrl { get; set; }
    public string UploadDate { get; set; }
}
