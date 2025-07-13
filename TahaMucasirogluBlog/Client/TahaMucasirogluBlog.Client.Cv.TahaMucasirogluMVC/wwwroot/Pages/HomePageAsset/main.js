$(document).ready(function () {
    // Initialize AOS (Animate On Scroll)
    AOS.init({
        duration: 1000,
        easing: 'ease-in-out',
        once: true,
        mirror: false
    });

    // Hide preloader when page is loaded
    $(window).on('load', function () {
        setTimeout(function () {
            $('#preloader').fadeOut(500, function () {
                // Initialize everything after preloader is hidden
                initializeTimeline();
            });
        }, 500); // Reduced timeout
    });

    // Also hide preloader if it takes too long
    setTimeout(function () {
        if ($('#preloader').is(':visible')) {
            $('#preloader').fadeOut(500, function () {
                initializeTimeline();
            });
        }
    }, 3000); // Fallback after 3 seconds

    // Navbar scroll effect
    $(window).scroll(function () {
        if ($(window).scrollTop() > 100) {
            $('#mainNav').addClass('navbar-scrolled');
        } else {
            $('#mainNav').removeClass('navbar-scrolled');
        }
    });

    // Back to top button
    $(window).scroll(function () {
        if ($(window).scrollTop() > 300) {
            $('#backToTop').addClass('show');
        } else {
            $('#backToTop').removeClass('show');
        }
    });

    $('#backToTop').click(function (e) {
        e.preventDefault();
        $('html, body').animate({
            scrollTop: 0
        }, 800);
    });

    // Smooth scrolling for navigation links
    $('a[href^="#"]').on('click', function (e) {
        e.preventDefault();
        var target = this.hash;
        var $target = $(target);

        if ($target.length) {
            $('html, body').animate({
                'scrollTop': $target.offset().top - 80
            }, 800, 'swing');
        }
    });

    // Update active navigation link
    $(window).scroll(function () {
        var scrollPos = $(window).scrollTop() + 100;

        $('.navbar-nav .nav-link').each(function () {
            var currLink = $(this);
            var refElement = $(currLink.attr("href"));

            if (refElement.length) {
                if (refElement.position().top <= scrollPos && refElement.position().top + refElement.height() > scrollPos) {
                    $('.navbar-nav .nav-link').removeClass("active");
                    currLink.addClass("active");
                } else {
                    currLink.removeClass("active");
                }
            }
        });
    });


    // Timeline Animation Variables
    let timelineItems = $('.timeline-item');
    let currentIndex = 0;

    // Initialize timeline
    function initializeTimeline() {
        currentIndex = 0;

        // Show all timeline items
        if (timelineItems.length > 0) {
            timelineItems.addClass('active');
            updateProgress(timelineItems.length - 1);
        }
    }

    // Update progress bar and car position
    function updateProgress(index) {
        const progress = ((index + 1) / timelineItems.length) * 100;
        const progressBarWidth = $('.timeline-progress').width();
        const carPosition = Math.max(0, (progress / 100) * (progressBarWidth - 50));

        $('#timelineProgress').css('width', progress + '%');
        $('#timelineCar').css('left', carPosition + 'px');
    }


    // Initialize timeline will be called after preloader is hidden

    // Skill tag hover effects
    $('.skill-tag').hover(
        function () {
            $(this).addClass('skill-hover');
        },
        function () {
            $(this).removeClass('skill-hover');
        }
    );

    // Skill tag click to show explanation and highlight related experience technologies
    $('.skill-tag').click(function () {
        const skillName = $(this).data('skill');
        const explanation = $(this).data('explanation');

        // Remove active class from all skill tags
        $('.skill-tag').removeClass('active');
        $(this).addClass('active');

        // Show explanation
        showSkillExplanation(explanation, $(this));

        // Highlight related skills
        highlightRelatedSkills(skillName);
    });

    // Highlight related skills in experience section
    function highlightRelatedSkills(skillName) {
        $('.skill-badge').removeClass('highlight');

        $('.skill-badge').each(function () {
            if ($(this).text().toLowerCase().includes(skillName.toLowerCase()) ||
                skillName.toLowerCase().includes($(this).text().toLowerCase())) {
                $(this).addClass('highlight');
            }
        });

        // Add highlight styles
        if (!$('#highlight-styles').length) {
            $('<style id="highlight-styles">')
                .text('.skill-badge.highlight { background: #ff6b6b !important; color: white !important; animation: highlightPulse 2s ease-in-out; }' +
                    '@keyframes highlightPulse { 0%, 100% { transform: scale(1); } 50% { transform: scale(1.1); } }')
                .appendTo('head');
        }

        // Remove highlight after 3 seconds
        setTimeout(function () {
            $('.skill-badge').removeClass('highlight');
        }, 3000);

        // showNotification(`"${skillName}" ile ilgili deneyimler vurgulandı!`, 'info');
    }

    // Show skill explanation function
    function showSkillExplanation(explanation, element) {
        // Find the skill card container
        const skillCard = element.closest('.skill-card');
        let explanationDiv = skillCard.find('.skill-explanation');

        if (explanationDiv.length === 0) {
            explanationDiv = $('<div class="skill-explanation" style="display: none;"><p class="explanation-text"></p></div>');
            skillCard.append(explanationDiv);
        }

        // Update explanation text
        explanationDiv.find('.explanation-text').text(explanation);

        // Show explanation with animation
        explanationDiv.slideDown(300);

        // Hide after 5 seconds
        setTimeout(function () {
            explanationDiv.slideUp(300);
            $('.skill-tag').removeClass('active');
        }, 5000);
    }

    // Experience skill badge click to show explanation
    $(document).on('click', '.skill-badge', function () {
        const skillName = $(this).data('skill');
        const explanation = $(this).data('explanation');

        if (explanation && explanation !== 'Açıklama yok') {
            // Remove active class from all skill badges
            $('.skill-badge').removeClass('active');
            $(this).addClass('active');

            // Show notification with explanation
            showNotification(`${skillName}: ${explanation}`, 'info');

            // Remove active class after 3 seconds
            setTimeout(function () {
                $('.skill-badge').removeClass('active');
            }, 3000);
        } else {
            showNotification(`${skillName}: Açıklama yok`, 'warning');
        }
    });

    // Contact form animation (if needed in future)
    $('.contact-info-item').hover(
        function () {
            $(this).find('i').addClass('fa-bounce');
        },
        function () {
            $(this).find('i').removeClass('fa-bounce');
        }
    );

    // Parallax effect for hero section
    $(window).scroll(function () {
        var scrollTop = $(window).scrollTop();
        var heroHeight = $('.hero-section').outerHeight();

        if (scrollTop < heroHeight) {
            $('.hero-particles').css('transform', 'translateY(' + scrollTop * 0.5 + 'px)');
        }
    });

    // Profile image error handling
    $('.profile-image').on('error', function () {
        $(this).css('opacity', '0');
        console.log('Profile image failed to load, showing fallback');
    });

    // Profile image click effect
    $('.profile-image').click(function () {
        $(this).addClass('profile-clicked');
        setTimeout(() => {
            $(this).removeClass('profile-clicked');
        }, 1000);
    });

    // Add profile click animation styles
    if (!$('#profile-click-styles').length) {
        $('<style id="profile-click-styles">')
            .text('.profile-clicked { animation: profileClick 1s ease-in-out; }' +
                '@keyframes profileClick { 0%, 100% { transform: scale(1) rotate(0deg); } 25% { transform: scale(1.1) rotate(5deg); } 75% { transform: scale(1.1) rotate(-5deg); } }')
            .appendTo('head');
    }

    // Lazy loading for images (if more images added)
    if ('IntersectionObserver' in window) {
        const imageObserver = new IntersectionObserver((entries, observer) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const img = entry.target;
                    img.src = img.dataset.src;
                    img.classList.remove('lazy');
                    imageObserver.unobserve(img);
                }
            });
        });

        document.querySelectorAll('img[data-src]').forEach(img => {
            imageObserver.observe(img);
        });
    }

    // Add mouse trail effect
    let mouseTrail = [];
    const maxTrailLength = 20;

    $(document).mousemove(function (e) {
        mouseTrail.push({
            x: e.pageX,
            y: e.pageY,
            time: Date.now()
        });

        if (mouseTrail.length > maxTrailLength) {
            mouseTrail.shift();
        }

        // Create trail effect on hero section
        if ($(e.target).closest('.hero-section').length > 0) {
            createTrailParticle(e.pageX, e.pageY);
        }
    });

    // Create trail particle
    function createTrailParticle(x, y) {
        const particle = $('<div class="trail-particle"></div>');
        particle.css({
            position: 'fixed',
            left: x - 2,
            top: y - 2,
            width: '4px',
            height: '4px',
            background: 'rgba(246, 146, 30, 0.7)',
            borderRadius: '50%',
            pointerEvents: 'none',
            zIndex: 1000
        });

        $('body').append(particle);

        // Animate and remove particle
        particle.animate({
            opacity: 0,
            width: 0,
            height: 0
        }, 800, function () {
            particle.remove();
        });
    }

    // Easter egg: Konami code
    let konamiCode = [38, 38, 40, 40, 37, 39, 37, 39, 66, 65];
    let konamiIndex = 0;

    $(document).keydown(function (e) {
        if (e.keyCode === konamiCode[konamiIndex]) {
            konamiIndex++;
            if (konamiIndex === konamiCode.length) {
                activateEasterEgg();
                konamiIndex = 0;
            }
        } else {
            konamiIndex = 0;
        }
    });

    // Easter egg activation
    function activateEasterEgg() {
        showNotification('🎉 Easter Egg Activated! 🎉', 'success');

        // Add rainbow effect to profile image
        $('.profile-image').addClass('rainbow-effect');

        // Add rainbow CSS if not exists
        if (!$('#rainbow-styles').length) {
            $('<style id="rainbow-styles">')
                .text('.rainbow-effect { animation: rainbow 2s linear infinite; border: 5px solid transparent; background: linear-gradient(white, white) padding-box, linear-gradient(45deg, red, orange, yellow, green, blue, indigo, violet, red) border-box; }' +
                    '@keyframes rainbow { 0% { filter: hue-rotate(0deg); } 100% { filter: hue-rotate(360deg); } }')
                .appendTo('head');
        }

        // Remove effect after 5 seconds
        setTimeout(function () {
            $('.profile-image').removeClass('rainbow-effect');
        }, 5000);
    }

    // Notification system
    function showNotification(message, type = 'info') {
        const notification = $(`
            <div class="custom-notification notification-${type}">
                <i class="fas fa-${getNotificationIcon(type)}"></i>
                <span>${message}</span>
                <button class="notification-close">&times;</button>
            </div>
        `);

        // Add notification styles if not exists
        if (!$('#notification-styles').length) {
            $('<style id="notification-styles">')
                .text(`
                    .custom-notification {
                        position: fixed;
                        top: 100px;
                        right: 20px;
                        background: white;
                        border-radius: 10px;
                        padding: 15px 20px;
                        box-shadow: 0 5px 20px rgba(0,0,0,0.2);
                        z-index: 10000;
                        display: flex;
                        align-items: center;
                        gap: 10px;
                        max-width: 350px;
                        transform: translateX(400px);
                        transition: transform 0.3s ease;
                    }
                    .custom-notification.show { transform: translateX(0); }
                    .notification-success { border-left: 5px solid #28a745; }
                    .notification-info { border-left: 5px solid #17a2b8; }
                    .notification-warning { border-left: 5px solid #ffc107; }
                    .notification-error { border-left: 5px solid #dc3545; }
                    .notification-close {
                        background: none;
                        border: none;
                        font-size: 1.2rem;
                        cursor: pointer;
                        padding: 0;
                        margin-left: auto;
                    }
                `)
                .appendTo('head');
        }

        $('body').append(notification);

        // Show notification
        setTimeout(() => notification.addClass('show'), 100);

        // Auto hide after 4 seconds
        setTimeout(() => hideNotification(notification), 4000);

        // Close button handler
        notification.find('.notification-close').click(() => hideNotification(notification));
    }

    function hideNotification(notification) {
        notification.removeClass('show');
        setTimeout(() => notification.remove(), 300);
    }

    function getNotificationIcon(type) {
        switch (type) {
            case 'success': return 'check-circle';
            case 'warning': return 'exclamation-triangle';
            case 'error': return 'exclamation-circle';
            default: return 'info-circle';
        }
    }

    // Performance optimization: Throttle scroll events
    function throttle(func, wait) {
        let timeout;
        return function executedFunction(...args) {
            const later = () => {
                clearTimeout(timeout);
                func(...args);
            };
            clearTimeout(timeout);
            timeout = setTimeout(later, wait);
        };
    }

    // Apply throttling to scroll events
    $(window).scroll(throttle(function () {
        // Existing scroll handlers are already defined above
    }, 16)); // ~60fps


    // Intersection Observer for timeline items (visual feedback only)
    if ('IntersectionObserver' in window) {
        const timelineObserver = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const index = $(entry.target).data('index');
                    if (typeof index !== 'undefined') {
                        // Update the progress bar based on visible timeline items
                        updateProgress(index);
                        currentIndex = index;
                    }
                }
            });
        }, {
            threshold: 0.3,
            rootMargin: '-50px 0px'
        });

        timelineItems.each(function () {
            timelineObserver.observe(this);
        });
    }
});

// Additional utility functions
window.scrollToSection = function (sectionId) {
    const section = document.getElementById(sectionId);
    if (section) {
        section.scrollIntoView({
            behavior: 'smooth',
            block: 'start'
        });
    }
};

// Print CV functionality (could be added to navbar)
window.printCV = function () {
    window.print();
};

// Download CV as PDF (requires additional library)
window.downloadCV = function () {
    // This would require html2pdf or similar library
    console.log('Download CV functionality would be implemented here');
};