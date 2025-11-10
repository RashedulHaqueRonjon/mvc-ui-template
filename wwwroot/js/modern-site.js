document.addEventListener('DOMContentLoaded', function () {
    // Navbar scroll shadow
    const nav = document.querySelector('.navbar');
    function onScroll() {
        if (window.scrollY > 30) nav.classList.add('scrolled'); else nav.classList.remove('scrolled');
    }
    window.addEventListener('scroll', onScroll);

    // Basic form validation bootstrap helper
    (function () {
        const forms = document.querySelectorAll('.needs-validation');
        Array.prototype.slice.call(forms).forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    })();
});
