function uchkEmail(MultiemailAddresses) {
    var emailAddresses = '';
    emailAddresses = MultiemailAddresses.replace(/,/g, ";");
    var arrayMailAddress = emailAddresses.split(";");   
    re = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,15}|[0-9]{1,3})(\]?[\s]*)$/;   
    for (var counter = 0; counter < arrayMailAddress.length; counter++) {
        arrayMailAddress[counter] = arrayMailAddress[counter].replace(new RegExp(/^\s+/), ""); // START
        arrayMailAddress[counter] = arrayMailAddress[counter].replace(new RegExp(/\s+$/), ""); // END
        if (arrayMailAddress[counter] != null && arrayMailAddress[counter].trim() != '' && !arrayMailAddress[counter].trim().match(re)) {
            blnReturn = false;

            break;
        }
        else {
            blnReturn = true;
        }
    }
    return blnReturn;
}

function validation()
{
    var customerno = null;
    var customername = null;
    var email = null;
    var phoneno = null;
    var subscription = null;
    var languagecode = null;
    var IsFormatted = true;

    customerno = $('#txtCustomerNo').val().trim();
    if (customerno == "") {
        alert("Please enter the customer no")
        return false;
    }
 

    customername = $('#txtCustomerName').val().trim();
    if (customername == "") {
        alert("Please enter the customer name ")
        return false;
    }
   

    email = $('#txtEmail').val().trim();
    if (email == "") {
        alert("Please enter the email ")
        return false;
    }
    if (email.length > 0) {
        if (!uchkEmail(email)) {
          
            if (IsFormatted)
                IsFormatted = false;
        }
    }
    if (!IsFormatted) {
        alert('Invalid email format');
        return false;
    }

    phoneno = $('#txtMobile').val().trim();
    if (phoneno == "") {
        alert("Please enter the mobile no ")
        return false;
    }
    
    

    subscription = $('#ddlSubcription').val();

    if(subscription == "0")
    {
        alert("Please select the subscription...");
        return false;
    }
   

    languagecode = $('#ddlLanguageCode').val();

    if (languagecode == "0") {
        alert("Please select the language..");
        return false;
    }
   

}

$(document).ready(function () {
    $('#txtMobile').keypress(function (event) {
        console.log(event.which);
        if (event.which != 8 && isNaN(String.fromCharCode(event.which))) {
            event.preventDefault();
        }
    });
});