
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

[ApiController]
[Route("api/documents")]
public class DocumentsController : ControllerBase
{
    private readonly string jsonFilePath = "wwwroot/data/documents.json";

    [HttpGet]
    public IActionResult GetDocuments()
    {
        if (!System.IO.File.Exists(jsonFilePath))
            return Ok(new List<Document>());

        var jsonData = System.IO.File.ReadAllText(jsonFilePath);
        var documents = JsonSerializer.Deserialize<List<Document>>(jsonData);
        return Ok(documents);
    }

    [HttpPost]
    public IActionResult AddDocument([FromBody] Document document)
    {
        var documents = new List<Document>();

        if (System.IO.File.Exists(jsonFilePath))
        {
            var jsonData = System.IO.File.ReadAllText(jsonFilePath);
            documents = JsonSerializer.Deserialize<List<Document>>(jsonData);
        }

        documents.Add(document);
        var updatedJson = JsonSerializer.Serialize(documents, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(jsonFilePath, updatedJson);

        return Ok(document);
    }
}

public class Document
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FileUrl { get; set; } // Örn: /files/dualar.pdf
    public string UploadDate { get; set; }
}
