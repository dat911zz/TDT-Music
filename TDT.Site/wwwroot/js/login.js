const validateEmail = (email) => {
    return String(email)
        .toLowerCase()
        .match(
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        );
};
const validatePassword = (pass) => {
    return String(pass)
        .match(
            /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$/
        )
}
const validatePhone = (phone) => {
    return String(phone)
        .match(
        /^[0-9]{10,11}$/
    )
}

const validateUsername = (user) => {
    return String(user)
        .match(/^[a-zA-Z0-9]+$/)
}
$().ready(function (){
    $('#btn-login').click(function (e) {
        const email = $(this).parents("#login-form").find('input[name="username"]');
        const password = $(this).parents("#login-form").find('input[name="password"]');
        email[0].setCustomValidity("");
        password[0].setCustomValidity("");

        if (!email[0].checkValidity()) {
            if (!email.val()) {
                email[0].setCustomValidity('Vui lòng nhập trường này!');
            } else {
                if (!validateEmail(email.val())) {
                    email[0].setCustomValidity('Email không đúng!');
                }
            }
        }
        if (!password[0].checkValidity()) {
            if (!password.val()) {
                password[0].setCustomValidity('Vui lòng nhập trường này!');
            } else {
                if (!validatePassword(password.val())) {
                    password[0].setCustomValidity('Mật khẩu không hợp lệ!');
                }
            }
        }
    });
    $('#btn-register').click(function (e) {
        const email = $(this).parents("#register-form").find('input[name="email"]');
        const password = $(this).parents("#register-form").find('input[name="password"]');
        const phone = $(this).parents("#register-form").find('input[name="phone"]');
        const username = $(this).parents("#register-form").find('input[name="username"]');
        username[0].setCustomValidity("");
        phone[0].setCustomValidity("");
        email[0].setCustomValidity("");
        password[0].setCustomValidity("");

        if (!username[0].checkValidity()) {
            if (!username.val()) {
                username[0].setCustomValidity('Vui lòng nhập trường này!');
            } else if (!validateUsername(username.val())) {
                username[0].setCustomValidity('Tên đăng nhập không được chứa kí tự đặc biệt và khoảng trắng!');
            }
        }
        if (!phone[0].checkValidity()) {
            if (!phone.val()) {
                phone[0].setCustomValidity('Vui lòng nhập trường này!');
            } else {
                if (!validatePhone(phone.val())) {
                    phone[0].setCustomValidity('Số điện thoại không đúng!');
                }
            }
        }
        if (!email[0].checkValidity()) {
            if (!email.val()) {
                email[0].setCustomValidity('Vui lòng nhập trường này!');
            } else {
                if (!validateEmail(email.val())) {
                    email[0].setCustomValidity('Email không đúng!');
                }
            }
        }
        if (!password[0].checkValidity()) {
            if (!password.val()) {
                password[0].setCustomValidity('Vui lòng nhập trường này!');
            } else {
                if (!validateEmail(password.val())) {
                    password[0].setCustomValidity('Mật khẩu từ 6 kí tự trở lên bao gồm ít nhất 1 chữ cái hoa, thường, chữ số, kí tự đặc biệt!');
                }
            }
        }
    });
});

