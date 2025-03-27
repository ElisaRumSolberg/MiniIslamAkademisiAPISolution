document.getElementById("dua-form").addEventListener("submit", function (e) {
    e.preventDefault();

    // Formdan verileri al
    const title = document.querySelector('input[name="title"]').value;
    const description = document.querySelector('input[name="description"]').value;
    const audio = document.querySelector('input[name="audio"]').value;
    const pdf = document.querySelector('input[name="pdf"]').value;
    const video = document.querySelector('input[name="video"]').value;

    // JSON formatında veri hazırla
    const yeniDua = {
        title: title,
        description: description,
        audio: audio,
        pdf: pdf,
        video: video
    };

    // API'ye gönder
    fetch("/api/Videos", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(yeniDua)
    })
        .then(res => {
            if (res.ok) {
                document.getElementById("mesaj").textContent = "✅ Dua başarıyla eklendi!";
                e.target.reset(); // Formu temizle
            } else {
                document.getElementById("mesaj").textContent = "⚠️ Ekleme başarısız.";
            }
        })
        .catch(err => {
            console.error(err);
            document.getElementById("mesaj").textContent = "❌ Sunucu hatası!";
        });
});
