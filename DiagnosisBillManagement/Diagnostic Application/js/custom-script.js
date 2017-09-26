
$(document).ready(function() {

    //validation testsetup UI from on keyup and submit
    $("#TestSetupUI").validate({
        
        rules: {
            TestTypeTextBox: {
                required: true,
                minlength: 2,
            }
        }

    });
});