var Optics = Optics || {};

Optics.validation = $(function () {

    var me = {};

    // Initialize form validation on the registration form.
    // It has the name attribute "registration"
    $("form[name='Diameter']").validate({
        // Specify validation rules
        rules: {
            
            Value: {
                required: true,
                number: true,
                range: [10, 100]
            }
        },
        // Specify validation error messages
        messages: {
            Value: {
                required: "Polje mora biti popunjeno.",
                number: "Morate uneti broj.",
                range: "Unesite broj izmedju 10 i 100."
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
