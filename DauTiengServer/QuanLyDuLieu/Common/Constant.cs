using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Library
{
    class Constant
    {
        public const int DEFAULT_ROW = 20;

        public const int DEFAULT_MAX_PERCENT_PROFIT = 999;
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
        public const string DEFAULT_FORMAT_MONEY = "#" + Constant.SYMBOL_LINK_MONEY + "###";
        public const string DEFAULT_MONEY_SUBFIX = "Đ";

        public const string DEFAULT_FIRST_VALUE_COMBOBOX = "Tất cả";

        public const string SORT_ASCENDING = "asc";
        public const string SORT_DESCENDING = "desc";

        public static Color COLOR_NORMAL = Color.Gray;
        public static Color COLOR_MOUSEOVER = Color.Orange;
        public static Color COLOR_DISABLE = Color.LightSlateGray;
        public static Color COLOR_IN_USE = Color.Red;
        public static Color COLOR_CHOOSEN_PRICE = Color.LightBlue;

        public const string PAGE_TEXT = " Trang";
        public const string SEPERATE_STRING = ", ";
        public const string SYMBOL_LINK_STRING = " - ";
        public const string SYMBOL_LINK_PATH = "_";
        public const string SYMBOL_LINK_MONEY = ",";
        public const string SYMBOL_DISCOUNT = "%";

        public const string CAPTION_CONFIRM = "CONFIRM";
        public const string CAPTION_WARNING = "WARNING";
        public const string CAPTION_ERROR = "ERROR";

        public const string MESSAGE_NEW_LINE = "\r\n";
        public const string MESSAGE_EXIT = "Thoát?";
        public const string MESSAGE_EXIT_APP = "Thoát chương trình?";
        public const string MESSAGE_CONTINUE = "Bạn có muốn tiếp tục?";

        public const string MESSAGE_DELETE_CONFIRM = "Xóa dữ liệu đã chọn?";
        public const string MESSAGE_DELETE_SUCCESS = "{0} đã xóa thành công.";
        public const string MESSAGE_DELETE_ERROR = "{0} xóa thất bại!";

        public const string MESSAGE_INSERT_SUCCESS = "{0} đã nhập thành công";
        public const string MESSAGE_INSERT_ERROR = "Quá trình nhập dữ liệu mới thất bại!";
        public const string MESSAGE_INSERT_ERROR_DUPLICATE = "Quá trình nhập dữ liệu mới thất bại!" + MESSAGE_NEW_LINE + "Vui lòng kiểm tra \"{0}\" đã tồn tại.";

        public const string MESSAGE_UPDATE_CONFIRM = "Cập nhật dữ liệu?";
        public const string MESSAGE_UPDATE_SUCCESS = "{0} đã cập nhật thành công.";
        public const string MESSAGE_UPDATE_ERROR = "{0} cập nhật dữ liệu thất bại!";

        public const string MESSAGE_CONFIRM = "Hoàn tất?";
        public const string MESSAGE_CONFIRM_DELETE_ALL = "Xóa hết tất cả các dữ liệu đã chọn?";

        public const string MESSAGE_ERROR = "Có lỗi!";
        public const string MESSAGE_ERROR_NULL_DATA = "Dữ liệu không tồn tại!";
        public const string MESSAGE_ERROR_MISSING_DATA = "Vui lòng nhập dữ liệu {0} trước!";
        public const string MESSAGE_ERROR_DELETE_DATA = "Vui lòng kiểm tra dữ liệu có đang sử dụng hay không!";
        public const string MESSAGE_ERROR_EDIT_DATA = "Không thể thay đổi dữ liệu này!";
    }
}
