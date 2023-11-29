using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Enums
{
    public enum APIStatusCode
    {
        [Description("Có lỗi đã xảy ra")]
        RequestFailed = -1,
        [Description("Request đang bỏ trống, xem xét kiểm tra json format/content-length")]
        NullRequest,
        [Description("Các tham số [{0}] đang bỏ trống")]
        NullParams,
        [Description("Không tìm thấy api này")]
        NotFound,
        [Description("Chuỗi xác thực không hợp lệ")]
        InvalidAuthenticationString,
        [Description("Tài khoản không hợp lệ hoặc chưa được kích hoạt")]
        InvalidAccount,
        [Description("Thao tác {0} thất bại")]
        ActionFailed,
        [Description("Thao tác {0} thành công")]
        ActionSucceeded,
        [Description("Đăng nhập thành công")]
        AccessGranted,
        [Description("Truy cập bị từ chối")]
        AccessDenied,
        [Description("Tài khoản không tồn tại")]
        AccountNotFound,
        [Description("Email không hợp lệ")]
        InvalidEmail,
        [Description("Mật khẩu không đúng định dạng")]
        InvalidPassword,
        [Description("Tên đăng nhập hoặc mail đã tồn tại")]
        ExistingAccount,
        [Description("{0} thành công!")]
        Succeeded,
        [Description("Tài khoản tạm khóa")]
        AccountLockout,
        [Description("Dữ liệu đã tồn tại")]
        Exist,
        [Description("Dữ liệu không tồn tại")]
        NotExist,
    }
}
