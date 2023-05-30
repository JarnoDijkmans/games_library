document.addEventListener('DOMContentLoaded', function () {
    var carousel = document.getElementById('carouselsliderdemo');
    var trailer = document.getElementById('game-trailer');

    carousel.addEventListener('slide.bs.carousel', function (event) {
        if (event.from === 0) {
            var src = trailer.src;
            trailer.src = '';
            trailer.src = src;
        }
    });
});