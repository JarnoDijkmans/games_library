$(document).ready(function () {
    $('#removeDiscountCode').click(function () {
        console.log('Remove clicked');
        $('#actionField').val('remove');
        console.log($('#actionField').val());
        $('#discountForm').submit();
    });

    function getSelectedPaymentType() {
        if (document.getElementById('idealRadio').checked) {
            return 'Ideal';
        } else if (document.getElementById('PaypalRadio').checked) {
            return 'Paypal';
        } else if (document.getElementById('CreditcardRadio').checked) {
            return 'Creditcard';
        } else {
            return '';
        }
    }

    document.getElementById('paymentForm').addEventListener('submit', function (e) {
        var selectedPaymentType = getSelectedPaymentType();
        document.querySelector('input[name="checkoutInfo.PaymentType"]').value = selectedPaymentType;
    });
}); 