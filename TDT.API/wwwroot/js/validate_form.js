// Chặn nhập ký tự đặc biệt:
function validateNoSpecialChars(input) {
    input.setCustomValidity("");

    const inputValue = input.value;
    const regex = /^[a-zA-Z0-9\s]+$/;
        if (!regex.test(inputValue)) {
            return String("Không được nhập ký tự đặc biệt.");
        }
}
// Chặn nhập ký tự đặc biệt nhưng được sử dụng tiếng việt:
function validateNoSpecialCharsYesVI(input) {
    input.setCustomValidity("");

    const inputValue = input.value;
    const regex = /^[a-zA-Z0-9\sÀ-ỹĂăÂâĐđÊêÔôƠơƯư]+$/;
    if (!regex.test(inputValue)) {
        return String("Không được nhập ký tự đặc biệt.");
    }
}
// Số ký tự ít nhất minLength:
function validateMinLength(input, minLength) {
    input.setCustomValidity("");

    const inputValue = input.value;
    if (inputValue.length < minLength) {
        return String("Yêu cầu ít nhất " + minLength + " ký tự.");
    }
}

// Chặn nhập số âm:
function validateNonNegative(input) {
    input.setCustomValidity("");

    const inputValue = input.value;
    if (parseInt(inputValue) < 0) {
        return String("Không được nhập số âm.");
    }
}

// Chặn nhập khoảng trắng:
function validateNoWhitespace(input) {
    input.setCustomValidity("");

    const inputValue = input.value;
    const regex = /^\S+$/;
    if (!regex.test(inputValue)) {
        return String("Không được nhập khoảng trắng.");
    }
}

// Kiểm tra số điện thoại di động Việt Nam:
function validateVnPhoneNumber(input) {
    input.setCustomValidity("");

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
/// Không dc nhập mỗi khoảng trắng
function validateNotMoiKhoangTrang(input) {
    input.setCustomValidity("");

    const inputValue = input.value;
    if (/^\s*$/.test(inputValue)) {
        return "Không được nhập mỗi khoảng trắng.";
    }
}
function validatePositiveNumber(input) {
    input.setCustomValidity("");
    const inputValue = input.value;

    // Kiểm tra xem giá trị có phải là số dương hay không
    if (!/^\d*\.?\d+$/.test(inputValue) || parseFloat(inputValue) <= 0) {
        return "Vui lòng nhập một số dương hợp lệ.";
    }
}

// Xét date thanh long
function GetTicks(dateTime) {
    var totalSeconds = (dateTime - new Date(1970, 1, 1, 0, 0, 0)) / 1000;
    return Math.round(totalSeconds); // Làm tròn để có giá trị nguyên
}

