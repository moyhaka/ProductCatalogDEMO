$(function () {
    console.log("document ready");
    $(document).on("click", ".edit-product-button", function () {
        console.log("You just clicked button number " + $(this).val());


        //store the product id number
        var productID = $(this).val();

        $.ajax({
            type: 'json',
            data: {
                "id": productID
            },
            url: '/product/ShowOneProductJSON',
            success: function (data) {
                console.log(data)

                //fill in the modal form
                $("#modal-input-id").val(data.id);
                $("#modal-input-name").val(data.name);
                $("#modal-input-price").val(data.price);
                $("#modal-input-description").val(data.description);

            }
        })
    });

    $("#save-button").click(function () {
        //get the values fromthe input fields and create a json object to submit to the controller.

         var Product = {
            "id": $("#modal-input-id").val(),
            "name": $("#modal-input-name").val(),
            "price": $("#modal-input-price").val(),
            "description": $("#modal-input-description").val()
        };

        console.log("saved");
        console.log(Product);


        //save the updated product record in the database using the controller
        $.ajax({
            type: 'json',
            data: Product,
            url: '/product/ProcessEditReturnPartial',
            success: function (data) {
                console.log(data);
                $("#card-number-" + Product.id).html(data).hide().fadeIn(2000);
            }
        })
    });
});
