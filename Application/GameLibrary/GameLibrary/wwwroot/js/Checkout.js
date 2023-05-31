$(document).ready(function () {
    $('.payment-option').click(function () {
        var method = $(this).data('method');

        $('.payment-details').hide();

        $('.payment-details[data-method=' + method + ']').show();

        $('input[type=radio][name=paymentMethod]').prop('checked
        $('input[type=radio][name=paymentMethod]').prop('checked', false);

        $('input[type=radio][name=paymentMethod][value=' + method + ']').prop('checked', true);
    });
});