fetch('/data/dualar.json')
    .then(res => res.json())
    .then(dualar => {
        const container = document.getElementById('dua-listesi');

        dualar.forEach(dua => {
            const card = document.createElement('div');
            card.className = 'dua-karti';

            card.innerHTML = `
        <h3>${dua.title}</h3>
        <p>${dua.description}</p>
        <audio controls src="${dua.audio}"></audio><br>
        <a href="${dua.pdf}" download>📥 PDF İndir</a>
        ${dua.video ? `
          <iframe 
            src="${dua.video}" 
            title="${dua.title} Videosu" 
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" 
            allowfullscreen>
          </iframe>
        ` : ""}
      `;

            container.appendChild(card);
        });
    });
