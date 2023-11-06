//Chặn nhập ký tự đặc biệt:
function validateNoSpecialChars(input) {
    const inputValue = input.value;
    const regex = /^[a-zA-Z0-9]+$/;
    if (!regex.test(inputValue)) {
        alert("Không được nhập ký tự đặc biệt.");
    }
}
//Số ký tự hơn minLength:
function validateMinLength(input, minLength) {
    const inputValue = input.value;
    if (inputValue.length < minLength) {
        alert("Mật khẩu phải có ít nhất 6 ký tự.");
    }
}
//Chặn nhập số âm:
function validateNonNegative(input) {
    const inputValue = input.value;
    if (parseInt(inputValue) < 0) {
        alert("Không được nhập số âm.");
    }
}
//Chặn nhập khoảng trắng không:
function validateNoWhitespace(input) {
    const inputValue = input.value;
    const regex = /^\S+$/;
    if (!regex.test(inputValue)) {
        alert("Không được nhập khoảng trắng.");
    }
}
//Kiểm tra số điện thoại di động Việt Nam:
function validateVnPhoneNumber(input) {
    const inputValue = input.value;
    const regex = /^0\d{9,10}$/;
    if (!regex.test(inputValue)) {
        ("Số điện thoại không hợp lệ (chỉ dành cho số điện thoại di động Việt Nam).");
    }
}
// Xét date thanh long

function GetTicks(dateTime) {
    var totalSeconds = (dateTime - new Date(1970, 1, 1, 0, 0, 0)) / 1000;
    return Math.round(totalSeconds); // Làm tròn để có giá trị nguyên
}

