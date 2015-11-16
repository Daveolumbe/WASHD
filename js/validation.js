$().ready(function () {
    $("#form1").validate({
        rule: {
            fnametxt: "required",
            lnametxt: "required",
            passwordtxt: {
                required: true,
                minlenght: 6
            },
            emailtxt: {
                required: true,
                email: true
            },

            message: {
                fnametxt: "Please enter your first name",
                lnametxt: "Please enter your last name",
            }
        }
    });
})