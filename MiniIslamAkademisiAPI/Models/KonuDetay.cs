<<<<<<< HEAD
﻿namespace MiniIslamAkademisiAPI.Models
{
    public class BlogYazisi
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string? Image { get; set; }
    }

    public class Pdf
    {
        public string Ad { get; set; }
        public string Url { get; set; }
        public string? Icon { get; set; }
    }

    public class Video
    {
        public string Link { get; set; }
    }

    public class KonuDetay
    {
        public string Id { get; set; }  // Örn: "namaz", "sabir"
        public string Title { get; set; }
        public string Description { get; set; }
        public List<BlogYazisi>? Blog { get; set; }
        public List<Pdf>? Pdf { get; set; }
        public List<string>? Video { get; set; }
    }
}
=======
﻿
        namespace MinislamAkademisiAPI.Models
    {
        public class KonuDetay
        {
            public string Ad { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }

            public List<BlogYazisi> Blog { get; set; }
            public List<Video> Video { get; set; }
            public List<Pdf> Pdf { get; set; }
        }

        public class BlogYazisi
        {
            public string Baslik { get; set; }
            public string Icerik { get; set; }
            public string Image { get; set; }
        }

        public class Video
        {
            public string Url { get; set; }
        }

        public class Pdf
        {
            public string Ad { get; set; }
            public string Url { get; set; }
            public string Icon { get; set; }
        }
    }



>>>>>>> 6f4a1a0e316bd4bbb940f09e3ccefdeaed0e3989
