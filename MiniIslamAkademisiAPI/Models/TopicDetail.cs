namespace MiniIslamAkademisiAPI.Models
{
    //  Represents a blog post with a title, content, and optional image
    public class BlogPost
    {
        public string Title { get; set; } = string.Empty;       // Title of the blog post
        public string Content { get; set; } = string.Empty;     // Main content of the blog post
        public string? ImageUrl { get; set; }                   //  URL or path to the blog image
    }

    //  Represents a downloadable PDF document with a name, file path, and optional icon
    public class PdfDocument
    {
        public string Name { get; set; } = string.Empty;        // Display name of the PDF
        public string Url { get; set; } = string.Empty;         // File path or URL for downloading/viewing
        public string? Icon { get; set; }                       // Icon image path
    }

    //  Represents a video resource, usually a YouTube or embed link
    public class Video
    {
        public string Url { get; set; } = string.Empty;         // URL to the video (YouTube, Vimeo, etc.)
    }

    //  Represents a full topic with ID, title, description, blog posts, PDFs, and videos
    public class TopicDetail
    {
        public string Id { get; set; } = string.Empty;                     // Unique key for identifying the topic (used in routing)
        public string Title { get; set; } = string.Empty;                 // Title of the topic (e.g., Prayer, Patience)
        public string Description { get; set; } = string.Empty;           // Short description or introduction to the topic
        public List<BlogPost> BlogPosts { get; set; } = new();            // List of blog posts related to the topic
        public List<PdfDocument> Pdfs { get; set; } = new();              // List of downloadable PDF files
        public List<string> Videos { get; set; } = new();                 // List of video URLs associated with the topic
    }
}
