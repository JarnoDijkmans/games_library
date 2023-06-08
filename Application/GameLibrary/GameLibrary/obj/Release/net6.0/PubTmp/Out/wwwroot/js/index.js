$(document).ready(function () {
    $('#searchInput').autocomplete({
        source: '/Index?handler=Autocomplete',
        minLength: 2,
        select: function (event, ui) {
            window.location.href = '/Details/' + ui.item.id;
        }
    });
});