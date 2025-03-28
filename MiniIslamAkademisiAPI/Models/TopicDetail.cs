namespace MiniIslamAkademisiAPI.Models
{
    // Represents a blog post with title, content, and optional image
    public class BlogPost
    {
        public string Title { get; set; } = string.Empty;       // Blog post title
        public string Content { get; set; } = string.Empty;     // Blog post content
        public string? ImageUrl { get; set; }                   // Optional image path
    }

    // Represents a downloadable PDF document
    public class PdfDocument
    {
        public string Name { get; set; } = string.Empty;        // Display name of the PDF
        public string Url { get; set; } = string.Empty;         // Path or URL of the file
        public string? Icon { get; set; }                       // Optional icon image
    }

    // Represents a video link
    public class Video
    {
        public string Url { get; set; } = string.Empty;         // YouTube or embed link
    }

    // Represents a full topic (e.g., "Prayer", "Patience") with related resources
    public class TopicDetail
    {
        public string Id { get; set; } = string.Empty;                     // Unique identifier for routing
        public string Title { get; set; } = string.Empty;                 // Main title of the topic
        public string Description { get; set; } = string.Empty;           // Short explanation
        public List<BlogPost> BlogPosts { get; set; } = new();            // List of blog posts
        public List<PdfDocument> Pdfs { get; set; } = new();              // List of PDF documents
        public List<string> Videos { get; set; } = new();                 // List of YouTube links
    }
}
