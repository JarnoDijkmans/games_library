
    document.addEventListener('DOMContentLoaded', function() {
    var carousel = document.getElementById('carouselsliderdemo');
    var trailer = document.getElementById('game-trailer');

    carousel.addEventListener('slid.bs.carousel', function() {
        var src = trailer.src;
    trailer.src = '';
    trailer.src = src;
    });
});
