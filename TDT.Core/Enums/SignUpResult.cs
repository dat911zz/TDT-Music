using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Enums
{
    public enum SignUpResult
    {
        [Description("Tên đăng nhập không được bỏ trống")]
        NullUserName,
        [Description("Email không được bỏ trống")]
        NullEmail,
        [Description("Mật khẩu không được bỏ trống")]
        NullPassword,
        [Description("Vui lòng xác nhận mật khẩu")]
        NullPasswordConfirm,
        [Description("Email không hợp lệ")]
        InvalidEmail,
        [Description("Mật khẩu không đúng định dạng")]
        InvalidPassword,
        [Description("Tên đăng nhập đã tồn tại")]
        ExistingAccount,
        [Description("Đăng ký thành công!")]
        Ok,
    }
}
