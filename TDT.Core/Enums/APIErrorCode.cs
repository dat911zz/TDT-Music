using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDT.Core.Enums
{
    public enum APIErrorCode
    {
        [Description("Request đang bỏ trống, xem xét kiểm tra json format/content-length")]
        NullRequest,
        [Description("Các tham số đang bỏ trống")]
        NullParams,
        [Description("Chuỗi xác thực không hợp lệ")]
        InvalidAuthenticationString,
        [Description("Tài khoản không hợp lệ hoặc chưa được kích hoạt")]
        InvalidAccount,
        [Description("Thao tác thêm không hợp lệ")]
        InvalidCreate,
        [Description("Thao tác đọc không hợp lệ")]
        InvalidRead,
        [Description("Thao tác cập nhật không hợp lệ")]
        InvalidUpdate,
        [Description("Thao tác xóa không hợp lệ")]
        InvalidDelete,
        [Description("Có lỗi đã xảy ra")]
        RequestFailed = -1
    }
}
