namespace MiniIslamAkademisiAPI.Models
{
    // Represents a blog post with title, content, and optional image
    public class BlogPost
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }  // Optional image path
    }

    // Represents a downloadable PDF document
    public class PdfDocument
    {
        public string Name { get; set; }       // Display name of the PDF
        public string Url { get; set; }        // Path or URL of the file
        public string? Icon { get; set; }      // Optional icon image
    }

    // Represents a single video link
    public class Video
    {
        public string Url { get; set; }        // YouTube or embed link
    }

    // Represents the main topic (e.g., "Prayer", "Patience")
    public class TopicDetail
    {
        public string Id { get; set; }                      // Unique identifier for the topic (used in URL)
        public string Title { get; set; }                   // Title shown to the user
        public string Description { get; set; }             // Short summary or intro
        public List<BlogPost>? BlogPosts { get; set; }      // List of related blog articles
        public List<PdfDocument>? Pdfs { get; set; }        // List of related PDF documents
        public List<string>? Videos { get; set; }           // List of video URLs (YouTube embeds etc.)
    }
}
