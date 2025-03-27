fetch('/data/degerler.json')
    .then(res => res.json())
    .then(data => {
        // Dinim bölümü
        const dinimContainer = document.getElementById('dinim-listesi');
        data.dinim.forEach(item => {
            const card = createCard(item);
            dinimContainer.appendChild(card);
        });

        // Değerlerim bölümü
        const degerlerimContainer = document.getElementById('degerlerim-listesi');
        data.degerlerim.forEach(item => {
            const card = createCard(item);
            degerlerimContainer.appendChild(card);
        });
    });

function createCard(item) {
    const card = document.createElement('div');
    card.className = 'dua-karti';

    card.innerHTML = `
    <h3>${item.title}</h3>
    <p>${item.description}</p>
    ${item.video ? `
      <div class="video-wrapper">
        <iframe width="250" height="140" src="${item.video}" 
          title="${item.title} Videosu" frameborder="0"
          allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
          allowfullscreen></iframe>
      </div>` : ""}
    ${item.pdf ? `<a href="${item.pdf}" download>📥 PDF İndir</a>` : ""}
  `;

    return card;
}
