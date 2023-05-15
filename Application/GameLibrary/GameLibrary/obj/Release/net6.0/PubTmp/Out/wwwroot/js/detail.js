
    document.addEventListener('DOMContentLoaded', function() {
        var form = document.getElementById('addToCartForm');
    form.addEventListener('submit', function(event) {
        event.preventDefault();
    var formData = new FormData(form);
    fetch('', {
        method: 'POST',
    body: formData
            })
    .then(function(response) {
                if (response.ok) {
                    return response.json();
                } else {
                    throw new Error('Error while adding item to the cart.');
                }
            })
    .then(function(data) {
        console.log("Cart item count: " + data.cartItemCount);
                // Update the cart item count or show a success message
            })
    .catch(function(error) {
        console.error(error);
            });
        });
    });
