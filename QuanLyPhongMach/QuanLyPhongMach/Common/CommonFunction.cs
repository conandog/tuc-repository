using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Input;

namespace QuanLyPhongMach
{
    class CommonFunc
    {
        static bool bEnter = false;

        public static void ValidateNumeric(KeyEventArgs e)
        {
            if (!Char.IsDigit(e.Key.ToString().LastOrDefault()))
            {
                e.Handled = true;
            }
        }

        private static readonly string[] VietNamChar = new string[]
        {
            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string ConvertVietNamToEnglish(string str)
        {     
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }

            return str;
        }

        public static void ValidateSpace(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        public static bool ValidateDOB(DateTime time, int age)
        {
            return time < DateTime.Now.AddYears(-age);
        }

        //public static void MuteEnterPress(KeyEventArgs e)
        //{
        //    if (e.KeyCode == System.Windows.Forms.Keys.Enter)
        //    {
        //        e.SuppressKeyPress = true;
        //        bEnter = false;
        //    }
        //}

        //public static void NextFocus(TextBox tb, KeyEventArgs e)
        //{
        //    if (e.KeyCode == System.Windows.Forms.Keys.Enter && !bEnter)
        //    {
        //        bEnter = true;
        //        tb.Focus();
        //        tb.SelectAll();
        //    }
        //}

        //public static bool tbPass(KeyEventArgs e)
        //{
        //    if (e.KeyCode == System.Windows.Forms.Keys.Enter && !bEnter)
        //    {
        //        bEnter = true;
        //        return true;
        //    }

        //    return false;
        //}

        public static String setSTT(int i)
        {
            if (i < 10)
            {
                return "0" + i.ToString();
            }
            else
            {
                if (i >= 10 && i <= 99)
                {
                    return i.ToString();
                }

                return i.ToString();
            }
        }

        public static string ThemMa3So(int iCount)
        {
            if (iCount < 9)
            {
                return ("00" + (iCount + 1).ToString());
            }

            if (iCount >= 9 && iCount < 99)
            {
                return ("0" + (iCount + 1).ToString());
            }

            if (iCount >= 99)
            {
                return ((iCount + 1).ToString());
            }

            return "00";
        }

        public static string ThemMa4So(int iCount)
        {
            if (iCount < 9)
            {
                return ("000" + (iCount + 1).ToString());
            }

            if (iCount >= 9 && iCount < 99)
            {
                return ("00" + (iCount + 1).ToString());
            }

            if (iCount >= 99 && iCount < 999)
            {
                return ("0" + (iCount + 1).ToString());
            }

            if (iCount >= 999)
            {
                return ((iCount + 1).ToString());
            }

            return "0000";
        }

        public static int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static bool TestInt(string sInt)
        {
            int iTest;
            if (int.TryParse(sInt, out iTest))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsBirthDay(DateTime DOB, int warningDays)
        {
            return (DOB.AddYears(DateTime.Now.Year - DOB.Year) >= DateTime.Now.AddDays(-1) &&
                    DOB.AddYears(DateTime.Now.Year - DOB.Year) <= DateTime.Now.AddDays(warningDays));
        }

        public static DateTime CalculateExpiredDate(DateTime createDate, int value, string typeOfValue)
        {
            DateTime usedDay = createDate;

            switch (typeOfValue)
            {
                case Constant.DEFAULT_TYPE_DAY:
                    usedDay = createDate.AddDays(value);
                    break;

                case Constant.DEFAULT_TYPE_MONTH:
                    usedDay = createDate.AddMonths(value);
                    break;

                case Constant.DEFAULT_TYPE_YEAR:
                    usedDay = createDate.AddYears(value);
                    break;

                default:
                    usedDay = createDate.AddDays(value);
                    break;
            }

            return usedDay;
        }

        //public static string setAvatarPath(string ma, DateTime date)
        //{
        //    string avatarPath = ma + Constant.SYMBOL_LINK_PATH + date.ToString(Constant.DEFAULT_DATE_TIME_AVATAR_FORMAT) + Constant.DEFAULT_AVATAR_EXT;

        //    return avatarPath;
        //}
    }
}
