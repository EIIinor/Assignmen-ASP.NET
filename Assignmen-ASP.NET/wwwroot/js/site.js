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
            //StreetName: {
            //    required: true
            //},
            PostalCode: {
                digits: true,
                minlength: 5
            },
            //City: {
            //    required: true
            //},
            Email: {
                required: true,
                email: true
            },
            Password: {
                required: true,
                minlength: 8
            },
            ConfirmPassword: {
                required: true,
                equalTo: "#Password"
            },
            TermsAndAgreement: {
                required: true
            }
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
            //StreetName: {
            //    required: "Street name is required"
            //},
            PostalCode: {
                digits: "Postal code must contain only digits",
                minlength: "Postal code must be at least 5 digits"
            },
            //City: {
            //    required: "City is required"
            //},
            Email: {
                required: "Email is required",
                email: "Email must be a valid email address"
            },
            Password: {
                required: "Password is required",
                minlength: "Password must be at least 8 characters"
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












//try {
//    const footer = document.querySelector('footer')

//    if (document.body.scrollHeight >= window.innerHeight) {
//        footer.classList.remove('position-fixed')
//        footer.classList.add('position.static')
//    } else {
//        footer.classList.remove('position-static')
//        footer.classList.add('position-fixed')
//    }
//}
//catch { }

