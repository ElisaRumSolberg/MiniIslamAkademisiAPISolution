using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

[ApiController]
[Route("api/posts")]
public class PostsController : ControllerBase
{
    private readonly string jsonFilePath = "wwwroot/data/posts.json";

    [HttpGet]
    public IActionResult GetPosts()
    {
        if (!System.IO.File.Exists(jsonFilePath))
            return Ok(new List<Post>());

        var jsonData = System.IO.File.ReadAllText(jsonFilePath);
        var posts = JsonSerializer.Deserialize<List<Post>>(jsonData);
        return Ok(posts);
    }

    [HttpPost]
    public IActionResult AddPost([FromBody] Post post)
    {
        var posts = new List<Post>();

        if (System.IO.File.Exists(jsonFilePath))
        {
            var jsonData = System.IO.File.ReadAllText(jsonFilePath);
            posts = JsonSerializer.Deserialize<List<Post>>(jsonData);
        }

        posts.Add(post);
        var updatedJson = JsonSerializer.Serialize(posts, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(jsonFilePath, updatedJson);

        return Ok(post);
    }
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public string PublishDate { get; set; }
}
