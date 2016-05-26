using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongMach
{
    public class Constant
    {
        public const string DEFAULT_TITLE_ADD = "THÊM";
        public const string DEFAULT_TITLE_EDIT = "SỬA";

        public const string DEFAULT_WELCOME_DATE_TIME_FORMAT = "Hôm nay là {0}, {1}";

        public static DateTime DEFAULT_DATE = new DateTime(2000, 1, 1);
        public const string DEFAULT_DATE_FORMAT = "dd/MM/yyyy";
        public const string DEFAULT_DATE_TIME_FORMAT = "dd/MM/yyyy - HH:mm";
        public const string DEFAULT_DATE_TIME_AVATAR_FORMAT = "ddMMyyyyHHmmss";
        public const string DEFAULT_TYPE_DAY = "Ngày";
        public const string DEFAULT_TYPE_MONTH = "Tháng";
        public const string DEFAULT_TYPE_YEAR = "Năm";

        public const string DEFAULT_FORMAT_ID_PRODUCT = "0000";
        public const string DEFAULT_FORMAT_ID_BILL = "00000";
        public const string DEFAULT_FORMAT_MONEY = "#" + SYMBOL_LINK_MONEY + "###";
        public const string DEFAULT_MONEY_SUBFIX = "Đ";

        public const string DELIMITER_STRING = ", ";
        public const string SYMBOL_LINK_STRING = " - ";
        public const string SYMBOL_LINK_PATH = "_";
        public const string SYMBOL_LINK_MONEY = ",";
        public const string SYMBOL_DISCOUNT = "%";

        public const string CAPTION_CONFIRM = "XÁC NHẬN";
        public const string CAPTION_WARNING = "CẢNH BÁO";
        public const string CAPTION_ERROR = "LỖI";

        public const string MESSAGE_HUY = "Bạn có chắc muốn hủy?";
        public const string MESSAGE_MISSING_REQUIRED_FIELD = "Vui lòng điền đủ thông tin có dấu \"*\"";
        public const string MESSAGE_DUPLICATED_CLIENT_CODE = "Mã khách hàng đã tồn tại!" + MESSAGE_NEW_LINE + "Vui lòng nhập lại mã khác";
        public const string MESSAGE_UPDATE_SUCCESSFUL = "Cập nhật dữ liệu thành công";

        public const string MESSAGE_NEW_LINE = "\r\n";
        public const string MESSAGE_EXIT = "Bạn có muốn thoát?";
        public const string MESSAGE_EXIT_APP = "Thoát chương trình?";
        public const string MESSAGE_CONTINUE = "Bạn có muốn tiếp tục?";

        public const string MESSAGE_ERROR = "Có lỗi!";
        public const string MESSAGE_ERROR_NULL_DATA = "Dữ liệu không tồn tại!";
    }
}
