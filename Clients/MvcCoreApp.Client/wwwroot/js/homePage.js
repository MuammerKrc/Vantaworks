var slides = document.querySelectorAll('.slide');
var btns = document.querySelectorAll('.nvgt-btn');
let currentSlide = 1;
//normal vavigatorla secme
var manualNav = function (manual) {
    slides.forEach((slide) => {
        slide.classList.remove('makeActive');
    });
    btns.forEach((btn) => {
        btn.classList.remove('makeActive');
    })
    slides[manual].classList.add('makeActive');
    btns[manual].classList.add('makeActive');

}
btns.forEach((btn, i) => {
    btn.addEventListener("click", (e) => {
        currentSlide = i;
        manualNav(i);
        console.log(e.target)
        console.log(currentSlide);
    });
});
console.log(slides.length)
console.log(btns.length)
//automatic
var repeat = function (activeClass) {
    var autoNav = function () {
        setTimeout(function () {
            manualNav(currentSlide);
            currentSlide++;
            if (slides.length == currentSlide) {
                currentSlide = 0;
            }
            autoNav();
        }, 3000);
    }
    autoNav();
}
repeat();