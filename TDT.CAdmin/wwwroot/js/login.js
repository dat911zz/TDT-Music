    $input_name = $('#UserName');
    $input_pass = $('#Password');
    $('#login_btn').on('click', function (e) {
        e.preventDefault()
        if ($input_name.val() == '' || $input_pass.val() == '') {
            Swal.fire({
                icon: 'error',
                title: 'Lỗi!',
                text: 'Vui lòng nhập thông tin!',
                showConfirmButton: true,
                timer: 2500
            })
        }
        else {
            debugger;
            var _url = '/Auth/Login'
            try {
                $.post(_url, { name: $input_name.val(), pass: $input_pass.val() }, function (errData) {
                    if (errData != '') {
                        Swal.fire({
                            icon: 'error',
                            title: 'Lỗi!',
                            text: errData,
                            showConfirmButton: true,
                            timer: 2500
                        })
                    }
                    else {
                        Swal.fire({
                            icon: 'success',
                            title: 'Đăng nhập thành công!',
                            showConfirmButton: true,
                            timer: 2000
                        }).then((result) => {
                            //Redirect after show modal success
                            window.location.href = '/';
                        });
                    }
                });

            } catch (e) {
                new Error(e);
            }
        }
    });