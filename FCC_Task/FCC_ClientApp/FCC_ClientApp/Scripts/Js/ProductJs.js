function validation() {
    var productno = null;
    var  productname = null;
    var quantity = null;


    productno = $('#txtProductNo').val().trim();
    if (productno == "") {
        alert("Please enter the product no")
        return false;
    }


    productname = $('#txtProductName').val().trim();
    if (productname == "") {
        alert("Please enter the product name ")
        return false;
    }

    quantity = $('#txtQuantity').val().trim();
    if (quantity == "") {
        alert("Please enter the quantity")
        return false;
    }

   

}

$(document).ready(function () {
    $('#txtQuantity').keypress(function (event) {
        console.log(event.which);
        if (event.which != 8 && isNaN(String.fromCharCode(event.which))) {
            event.preventDefault();
        }
    });
});