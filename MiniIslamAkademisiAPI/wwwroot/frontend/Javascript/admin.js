document.getElementById("admin-form").addEventListener("submit", function (e) {
    e.preventDefault();

    const veri = {
        Id: document.getElementById("ad").value,
        Title: document.getElementById("title").value,
        Description: document.getElementById("description").value,
        Blog: [
            {
                Baslik: "Blog Başlığı",
                Icerik: document.getElementById("blog-content").value
            }
        ],
        Video: [document.getElementById("video").value],
        Pdf: [
            {
                Ad: "PDF Dosyası",
                Url: document.getElementById("pdf").value
            }
        ]
    };

    fetch("/api/degerler", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(veri)
    })
        .then(res => res.ok ? "Başarıyla eklendi!" : "Bir hata oluştu.")
        .then(mesaj => {
            document.getElementById("mesaj").textContent = mesaj;
        })
        .catch(err => {
            console.error(err);
            document.getElementById("mesaj").textContent = "Sunucu hatası!";
        });
});
