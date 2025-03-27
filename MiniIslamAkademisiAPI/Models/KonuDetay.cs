
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



