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
        [Description("Tài khoản hoặc mật khẩu không hợp lệ")]
        Invalid,  
        [Description("Tài khoản không tồn tại")]
        AccountNotFound,
    }
}
