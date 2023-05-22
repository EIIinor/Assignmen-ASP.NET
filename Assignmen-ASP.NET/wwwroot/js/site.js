/*user registration validation */

$(document).ready(function () {
    $("form").validate({
        onkeyup: function (element) {
            this.element(element);
        },
        rules: {
            FirstName: {
                required: true,
                minlength: 2
            },
            LastName: {
                required: true,
                minlength: 2
            },
            PostalCode: {
                digits: true,
                minlength: 5
            },
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: true,
                minlength: 8,
            },
            ConfirmPassword: {
                required: true,
                equalTo: "#Password"
            },
            TermsAndAgreement: {
                required: true
            },


            Name: {
                required: true,
                minlength: 2
            },
            Text: {
                required: true,
                minlength: 5,
                maxlength: 200
            },
        },
        messages: {
            FirstName: {
                required: "First name is required",
                minlength: "First name must be at least 2 characters"
            },
            LastName: {
                required: "Last name is required",
                minlength: "Last name must be at least 2 characters"
            },
            PostalCode: {
                digits: "Postal code must contain only digits",
                minlength: "Postal code must be at least 5 digits"
            },
            Email: {
                required: "Email is required",
                email: "Email must be a valid email address"
            },
            Password: {
                required: "Password is required",
                minlength: "*Password must be at least 8 characters *Contain at least one uppercase and one lowercase letter *Contain at least one digit *Contains at least one of the specified special characters"
            },
            ConfirmPassword: {
                required: "Confirm password is required",
                equalTo: "Passwords do not match"
            },
            TermsAndAgreement: {
                required: "You need to accept the terms and agreements"
            }
        }
    });

    $("form").submit(function (event) {
        if (!$("form").valid()) {
            event.preventDefault(); // hindra standarduppförande av formuläret
        }
    });

});








//footer placement 

function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element)
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

        _element.classList.toggle('position-fixed', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }

}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)


function toggleMenu(attribute) {
    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }

}
toggleMenu('[data-option="toggle"]')

