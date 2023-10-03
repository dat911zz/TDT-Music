using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Enums
{
    public enum SignInResult
    {
        [Description("Đăng nhập thành công")]
        AccessGranted,
        [Description("Truy cập bị từ chối")]
        AccessDenied,
        [Description("Mật khẩu không hợp lệ")]
        InvalidPassword,  
        [Description("Tài khoản không tồn tại")]
        AccountNotFound,
    }
}
