// Toggle active class on navbar links
document.addEventListener("DOMContentLoaded", () => {
    const currentPath = window.location.pathname;
    const navLinks = document.querySelectorAll(".navbar-nav .nav-link");

    navLinks.forEach(link => {
        if (link.getAttribute("href") === currentPath) {
            link.classList.add("active");
        } else {
            link.classList.remove("active");
        }
    });
});

// Example Alert for Buttons (Remove or Customize)
document.querySelectorAll(".btn-primary").forEach(button => {
    button.addEventListener("click", () => {
        alert("Button clicked!");
    });
});
