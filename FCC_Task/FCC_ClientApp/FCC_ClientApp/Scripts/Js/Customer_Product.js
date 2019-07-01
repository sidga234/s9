$(document).ready(function () {
    $('#txtBoughtPrduct').keypress(function (event) {
        console.log(event.which);
        if (event.which != 8 && isNaN(String.fromCharCode(event.which))) {
            event.preventDefault();
        }
    });
});


function validation() {
    var quantity = null;
    quantity = $('#txtBoughtPrduct').val().trim();
    if (quantity == "") {
        alert("Please enter the  no")
        return false;
    }
}


function myFunction()
{
    var a = $('#txtProductQuantity').val().trim();
    var b = $('#txtBoughtPrduct').val().trim();
    var c = a - b;
    $('#txtProductBalance').val(c);
}