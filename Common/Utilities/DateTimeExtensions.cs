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
                pc.GetSecond(dateTime),
                calendar: pc
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

        public static int GetAge(this DateTime self) {
            var now = DateTime.Now;
            var days = (now - self).TotalDays;
            return (int)(days / 365.242199);
        }

        public static int GetAgeFromShamsiDateStringOrShamsiYearString(this string self) {
            var date = self.GetDateTimeFromShamsiDateString();
            if (date is null) {
                date = self.GetDateTimeFromShamsiDateString(true);
            }
            if (date is null) {
                return 0;
            }
            return date.Value.GetAge();
        }

        public static DateTime? GetDateTimeFromShamsiDateString(this string self, bool justYear = false) {
            PersianCalendar pc = new PersianCalendar();
            string[] seps = new string[] { "/", "\\", "-", " ", ".", "_" };
            var parts = self.Split(seps, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            try {
                return pc.ToDateTime(int.Parse(parts[0]), justYear ? 1 : int.Parse(parts[1]), justYear ? 1 : int.Parse(parts[2]), 0, 0, 0, 0);
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
