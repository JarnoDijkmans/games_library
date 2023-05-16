function removeFromCart(gameId) {
    var token = $('#RequestVerificationToken').val();

    $.ajax({
        url: `/ShoppingCart?handler=RemoveFromCart&gameId=${gameId}`,
        type: 'POST',
        headers: {
            'RequestVerificationToken': token
        },
        success: function (response) {
            // Update the cart display or perform any other necessary actions
            alert(response.message);

            // Reload the page or refresh a specific section
            location.reload(); // or update the relevant section using AJAX
        },
        error: function () {
            alert('Error removing game from cart.');
        }
    });
}