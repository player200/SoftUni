function validate() {
    let usernamePattern=/^[a-zA-Z0-9]{3,20}$/
    let passwordPattern=/^\w{5,15}$/
    let emailPattern=/^(.+@.*\..*)$/

    let username=$('#username')
    let email=$('#email')
    let password=$('#password')
    let confirmPassword=$('#confirm-password')
    let isCompany=$('#company')
    let companyNumber=$('#companyNumber')
    let btnSubmit=$('#submit')
    let companyField=$('#companyInfo')
    let validDiv=$('#valid')

    isCompany.on('change', function () {
        if ($(this).is(':checked')) {
            companyField.css('display', 'block');
        } else {
            companyField.css('display', 'none');
        }
    })

    $(btnSubmit).on('click',function (event) {
        event.preventDefault()
        let user = username.val()
        let currentEmail = email.val()
        let currentPassword = password.val()
        let currentConfirmPassword = confirmPassword.val()
        let isValid = true

        if (!usernamePattern.test(user)) {
            username.css('border-color', 'red')
            isValid=false
        } else {
            username.css('border-color', '')
        }

        if (!emailPattern.test(currentEmail)) {
            email.css('border-color', 'red')
            isValid=false
        } else {
            email.css('border-color', '')
        }

        if (!emailPattern.test(currentEmail)) {
            email.css('border-color', 'red')
            isValid=false
        } else {
            email.css('border-color', '')
        }

        if (currentPassword !== currentConfirmPassword) {
            password.css('border-color', 'red')
            confirmPassword.css('border-color', 'red')
            isValid=false
        } else {
            if (!passwordPattern.test(currentPassword)) {
                password.css('border-color', 'red')
                isValid=false
            } else {
                password.css('border-color', '')
            }

            if (!passwordPattern.test(currentConfirmPassword)) {
                confirmPassword.css('border-color', 'red')
                isValid=false
            } else {
                confirmPassword.css('border-color', '')
            }
        }

        if (companyField.css('display') === 'block') {
            let number = Number(companyNumber.val());

            if (number >= 1000 && number <= 9999) {
                companyNumber.css('border-color', '');
            } else {
                companyNumber.css('border-color', 'red')
                isValid = false
            }
        }

        if (isValid) {
            validDiv.css('display', 'block');
        }
        else {
            validDiv.css('display','none')
        }
    })
}