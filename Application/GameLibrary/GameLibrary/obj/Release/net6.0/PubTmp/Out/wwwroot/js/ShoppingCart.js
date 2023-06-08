function removeFromCart(gameId) {
    var token = $('#RequestVerificationToken').val();

    $.ajax({
        url: `/ShoppingCart?handler=RemoveFromCart&gameId=${gameId}`,
        type: 'POST',
        headers: {
            'RequestVerificationToken': token
        },
        success: function (response) {
            alert(response.message);

            location.reload();
        },
        error: function () {
            alert('Error removing game from cart.');
        }
    });
}


    $(document).ready(function(){
        $('#loginPrompt').click(function () {
            $('#loginModal').modal('show');
        });
    });
