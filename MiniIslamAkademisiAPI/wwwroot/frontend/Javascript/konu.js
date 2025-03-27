function getQueryParam(param) {
    const urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(param);
}

const konuAdi = getQueryParam("ad");

fetch("/data/degerler-detaylar.json")
    .then(res => res.json())
    .then(data => {
        const konu = data[konuAdi];

        if (!konu) {
            document.getElementById("konu-baslik").textContent = "Konu bulunamadı";
            return;
        }

        document.getElementById("konu-baslik").textContent = konu.title;
        document.getElementById("konu-aciklama").textContent = konu.description;

        // Blog yazıları
        // Blog yazıları
        if (konu.blog && konu.blog.length > 0) {
            const blogContainer = document.getElementById("konu-blog");
            konu.blog.forEach((yazi, index) => {
                const card = document.createElement("div");
                card.className = "blog-karti";

                card.innerHTML = `
            <h3 class="blog-baslik" onclick="toggleBlog(${index})">${yazi.baslik}</h3>
            ${yazi.image ? `<img src="${yazi.image}" class="blog-resim" alt="Blog Resmi">` : ""}
            <div class="blog-icerik" id="blog-${index}" style="display: none;">
                ${yazi.icerik}
            </div>
        `;
                blogContainer.appendChild(card);
            });
        }

        // PDF'ler
        if (konu.pdf && konu.pdf.length > 0) {
            const pdfContainer = document.getElementById("konu-pdf");
            pdfContainer.innerHTML = `<h3>📄 PDF Dokümanlar</h3>`;
            konu.pdf.forEach(doc => {
                const div = document.createElement("div");
                div.className = "pdf-kutu";
                div.innerHTML = `
            ${doc.icon ? `<img src="${doc.icon}" class="pdf-icon" alt="PDF">` : ""}
            <a href="${doc.url}" target="_blank" class="pdf-link">📎 ${doc.ad}</a>
        `;
                pdfContainer.appendChild(div);
            });
        }

        // Videolar
        if (konu.video && konu.video.length > 0) {
            const videoContainer = document.getElementById("konu-video");
            videoContainer.innerHTML = `<h3>🎥 Videolar</h3>`;
            konu.video.forEach(link => {
                const frame = document.createElement("iframe");
                frame.src = link;
                frame.width = "300";
                frame.height = "170";
                frame.frameBorder = "0";
                frame.allow = "accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture";
                frame.allowFullscreen = true;
                videoContainer.appendChild(frame);
            });
        }

      
function toggleBlog(index) {
    const icerik = document.getElementById(`blog-${index}`);
    icerik.style.display = (icerik.style.display === "none") ? "block" : "none";
}
