var Optics = Optics || {};

Optics.validation = $(function () {

    var me = {};

    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("form.js-valid").validate({
        // Specify validation rules
        rules: {
            
            Value: {
                required: true,
                number: true,
                range: [10, 100]
            },
            Description: {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            ManufacturerId: {
                required: true
            },
            Name: {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            DisplayName: {
                required: true,
                minlength: 2,
                maxlength: 50
            }
        },
        // Specify validation error messages
        messages: {
            Value: {
                required: Optics.localization.msg.required,
                number: Optics.localization.msg.number,
                range: Optics.localization.msg.range
            },
            Description: {
                required: Optics.localization.msg.required,
                minlength: Optics.localization.msg.minlength,
                maxlength: Optics.localization.msg.maxlength
            },
            ManufacturerId: {
                required: Optics.localization.msg.required
            },
            Name: {
                required: Optics.localization.msg.required,
                minlength: Optics.localization.msg.minlength,
                maxlength: Optics.localization.msg.maxlength
            },
            DisplayName: {
                required: Optics.localization.msg.required,
                minlength: Optics.localization.msg.minlength,
                maxlength: Optics.localization.msg.maxlength
            }
            
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });

    return me;
}(jQuery));
