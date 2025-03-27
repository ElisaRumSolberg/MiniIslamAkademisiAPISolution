// ✅ API endpoint
const apiUrl = "/api/degerler";

// ✅ Form gönderimi
document.getElementById("admin-form").addEventListener("submit", function (e) {
    e.preventDefault();

    const veri = {
        id: document.getElementById("ad").value.trim(),
        title: document.getElementById("title").value.trim(),
        description: document.getElementById("description").value.trim(),
        blog: [
            {
                baslik: "Varsayılan Başlık",
                icerik: document.getElementById("blog-content").value.trim()
            }
        ],
        video: [document.getElementById("video").value.trim()],
        pdf: [
            {
                ad: "PDF 1",
                url: document.getElementById("pdf").value.trim()
            }
        ]
    };

    fetch(apiUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(veri)
    })
        .then(res => {
            if (!res.ok) throw new Error("Sunucu hatası");
            return res.text();
        })
        .then(msg => {
            document.getElementById("mesaj").textContent = msg;
            document.getElementById("admin-form").reset();
            konulariGetir();
        })
        .catch(err => {
            console.error("Hata:", err);
            document.getElementById("mesaj").textContent = "❌ Veri eklenemedi.";
        });
});

// ✅ Konuları çek ve listele
function konulariGetir() {
    fetch("/data/degerler-detaylar.json")
        .then(res => res.json())
        .then(data => {
            const liste = document.getElementById("konu-listesi");
            liste.innerHTML = "";

            for (let key in data) {
                const konu = data[key];
                const item = document.createElement("div");
                item.className = "konu-karti";

                item.innerHTML = `
                    <strong>${konu.title || "Başlık Yok"}</strong><br>
                    ${konu.description || "Açıklama yok"}<br>
                    <button onclick="duzenleKonu('${key}')">✏️ Düzenle</button>
                    <button onclick="silKonu('${key}')">🗑️ Sil</button>
                `;

                liste.appendChild(item);
            }
        })
        .catch(err => {
            console.error("Veri alınamadı:", err);
            document.getElementById("konu-listesi").innerHTML = "<em>❗ Veri yüklenemedi.</em>";
        });
}

// ✅ Silme işlemi
function silKonu(id) {
    if (!confirm("Silmek istediğinizden emin misiniz?")) return;

    fetch(`/api/degerler/${id}`, {
        method: "DELETE"
    })
        .then(res => {
            if (res.ok) {
                alert("✅ Başarıyla silindi!");
                konulariGetir();
            } else {
                alert("❌ Silme başarısız!");
            }
        })
        .catch(err => {
            console.error("Silme hatası:", err);
        });
}

// ✅ Düzenleme için formu doldur
function duzenleKonu(id) {
    fetch("/data/degerler-detaylar.json")
        .then(res => res.json())
        .then(data => {
            const konu = data[id];
            if (!konu) return;

            document.getElementById("ad").value = id;
            document.getElementById("title").value = konu.title || "";
            document.getElementById("description").value = konu.description || "";
            document.getElementById("blog-content").value = konu.blog?.[0]?.icerik || "";
            document.getElementById("video").value = konu.video?.[0] || "";
            document.getElementById("pdf").value = konu.pdf?.[0]?.url || "";
        });
}

// ✅ Sayfa yüklendiğinde konuları getir
window.addEventListener("DOMContentLoaded", konulariGetir);
