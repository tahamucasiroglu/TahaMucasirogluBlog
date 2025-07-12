(function () {
    // Geri sayım elementi
    const countdownEl = document.getElementById('countdown');
    const daysEl = document.getElementById('days');
    const hoursEl = document.getElementById('hours');
    const minutesEl = document.getElementById('minutes');
    const secondsEl = document.getElementById('seconds');

    if (!countdownEl) return;

    // Razor'dan gelen bitiş zamanını al
    const endTime = new Date(countdownEl.dataset.endtime);

    function updateCountdown() {
        const now = new Date();
        const timeRemaining = endTime - now;

        if (timeRemaining <= 0) {
            daysEl.textContent = '00';
            hoursEl.textContent = '00';
            minutesEl.textContent = '00';
            secondsEl.textContent = '00';

            // Bakım tamamlandı mesajı
            document.querySelector('.maintenance-title').textContent = 'Bakım Tamamlandı';
            document.querySelector('.maintenance-text').textContent = 'Sitemiz artık kullanıma hazır. Sayfayı yenileyebilirsiniz.';

            clearInterval(countdownInterval);
            return;
        }

        // Zaman hesaplamaları
        const days = Math.floor(timeRemaining / (1000 * 60 * 60 * 24));
        const hours = Math.floor((timeRemaining % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        const minutes = Math.floor((timeRemaining % (1000 * 60 * 60)) / (1000 * 60));
        const seconds = Math.floor((timeRemaining % (1000 * 60)) / 1000);

        // Değerleri güncelle (2 haneli format)
        daysEl.textContent = String(days).padStart(2, '0');
        hoursEl.textContent = String(hours).padStart(2, '0');
        minutesEl.textContent = String(minutes).padStart(2, '0');
        secondsEl.textContent = String(seconds).padStart(2, '0');

        // Animasyon efekti
        secondsEl.style.transform = 'scale(1.1)';
        setTimeout(() => {
            secondsEl.style.transform = 'scale(1)';
        }, 100);
    }

    // İlk güncelleme
    updateCountdown();

    // Her saniye güncelle
    const countdownInterval = setInterval(updateCountdown, 1000);

    // Çarklar için hover efekti (opsiyonel)
    const gears = document.querySelectorAll('.gear');
    gears.forEach(gear => {
        gear.addEventListener('mouseenter', function () {
            this.style.animationDuration = '2s';
        });

        gear.addEventListener('mouseleave', function () {
            const originalDuration = this.classList.contains('gear-large') ? '8s' :
                this.classList.contains('gear-medium') ? '6s' : '4s';
            this.style.animationDuration = originalDuration;
        });
    });

    // Sayfa görünürlük API'si - sayfa arka planda iken performans optimizasyonu
    document.addEventListener('visibilitychange', function () {
        if (document.hidden) {
            clearInterval(countdownInterval);
        } else {
            updateCountdown();
            setInterval(updateCountdown, 1000);
        }
    });
})();