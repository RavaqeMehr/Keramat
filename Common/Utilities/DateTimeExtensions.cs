using System.Globalization;

namespace Common.Utilities {
    public static class DateTimeExtensions {

        public static DateTime ToPersianDateTime(this DateTime dateTime) {
            PersianCalendar pc = new PersianCalendar();
            var persianDate = new DateTime(
                pc.GetYear(dateTime),
                pc.GetMonth(dateTime),
                pc.GetDayOfMonth(dateTime),
                pc.GetHour(dateTime),
                pc.GetMinute(dateTime),
                pc.GetSecond(dateTime)
                );
            return persianDate;
        }

        public static string ToPersianDateTimeString(this DateTime dateTime) {
            var sh = dateTime.ToPersianDateTime();
            return $"{sh.Year:0000}/{sh.Month:00}/{sh.Day:00}-{sh.Hour:00}:{sh.Minute:00}:{sh.Second:00}";
        }

        public static string ToPersianDateString(this DateTime dateTime) {
            var sh = dateTime.ToPersianDateTime();
            return $"{sh.Year:0000}/{sh.Month:00}/{sh.Day:00}";
        }

        private static string[] PersianDays = new string[] { "یک‌شنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه" };
        public static string GetPersianDayString(this DateTime dateTime) => PersianDays[(int)dateTime.DayOfWeek];

        private static string[] PersianMonthes = new string[] { "", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        public static string GetPersianMonthString(this DateTime dateTime) => PersianMonthes[dateTime.Month];
    }
}
