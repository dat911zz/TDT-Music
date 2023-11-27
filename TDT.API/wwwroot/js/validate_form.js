// Chặn nhập ký tự đặc biệt:
function validateNoSpecialChars(input) {
    const inputValue = input.value;
    const regex = /^[a-zA-Z0-9\s]+$/;
        if (!regex.test(inputValue)) {
            console.log("Script is running! Chặn nhập ký tự đặc biệt:");
            return String("Không được nhập ký tự đặc biệt.");
        }
}

// Số ký tự ít nhất minLength:
function validateMinLength(input, minLength) {
    const inputValue = input.value;
    if (inputValue.length < minLength) {
        return String("Yêu cầu ít nhất " + minLength + " ký tự.");
    }
}

// Chặn nhập số âm:
function validateNonNegative(input) {
    const inputValue = input.value;
    if (parseInt(inputValue) < 0) {
        return String("Không được nhập số âm.");
    }
}

// Chặn nhập khoảng trắng:
function validateNoWhitespace(input) {
    const inputValue = input.value;
    const regex = /^\S+$/;
    if (!regex.test(inputValue)) {
        return String("Không được nhập khoảng trắng.");
    }
}

// Kiểm tra số điện thoại di động Việt Nam:
function validateVnPhoneNumber(input) {
    const inputValue = input.value;
    const regex = /^0\d{9,10}$/;
    if (!regex.test(inputValue)) {
        return String("Số điện thoại không hợp lệ (chỉ dành cho số điện thoại di động Việt Nam).");
    }
}

// Không được để trống
function validateNotEmpty(input) {

    input.setCustomValidity("");
    const inputValue = input.value.trim();  
    if (inputValue.length === 0) {
        return String("Không được để trống trường này.");
    }
}

// Xét date thanh long
function GetTicks(dateTime) {
    var totalSeconds = (dateTime - new Date(1970, 1, 1, 0, 0, 0)) / 1000;
    return Math.round(totalSeconds); // Làm tròn để có giá trị nguyên
}

