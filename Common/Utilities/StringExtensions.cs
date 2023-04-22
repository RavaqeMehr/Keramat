#pragma warning disable CS8603 // Possible null reference return.
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.Utilities {
    public static class StringExtensions {
        public static bool HasValue(this string? value, bool ignoreWhiteSpace = true) {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }

        public static int ToInt(this string value) {
            return Convert.ToInt32(value);
        }

        public static decimal ToDecimal(this string value) {
            return Convert.ToDecimal(value);
        }

        public static string ToNumeric(this int value) {
            return value.ToString("N0"); //"123,456"
        }

        public static string ToNumeric(this decimal value) {
            return value.ToString("N0");
        }

        public static string ToCurrency(this int value) {
            //fa-IR => current culture currency symbol => ریال
            //123456 => "123,123ریال"
            return value.ToString("C0");
        }

        public static string ToCurrency(this decimal value) {
            return value.ToString("C0");
        }

        public static string En2Fa(this string str) {
            return str.Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");
        }

        public static string Fa2En(this string str) {
            return str.Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                //iphone numeric
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");
        }

        public static string FixPersianChars(this string str) {
            return str.Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace(" ", " ")
                //.Replace("‌", " ") // nim Faseleh
                //.Replace("ئ", "ی")
                .Replace("ھ", "ه");
        }

        public static string CleanString(this string str) {
            return str.Trim().FixPersianChars().Fa2En().NullIfEmpty();
        }

        public static string NullIfEmpty(this string str) {
            return str?.Length == 0 ? null : str;
        }

        public static string getNumbers(this string str) {
            string s = "";
            foreach (var ch in str) {
                if (Char.IsNumber(ch)) {
                    s += "" + Char.GetNumericValue(ch);
                }
            }
            return s;
        }


        public static bool isMobile(this string str) {
            string mob = getNumbers(str);

            if (mob.Length == 10 && mob.StartsWith("9")) {
                return true;
            }

            if (mob.Length == 11 && mob.StartsWith("09")) {
                return true;
            }

            if (mob.Length == 12 && mob.StartsWith("989")) {
                return true;
            }

            if (mob.Length == 14 && mob.StartsWith("00989")) {
                return true;
            }

            return false;
        }

        public static string getNormalizeMobileOrEmpty(this string str) {
            if (str is null || str.Trim().Length == 0) {
                return "";
            }

            string mob = getNumbers(str);

            if (mob.isMobile()) {
                if (mob.Length == 10) {
                    return "0" + mob;
                }

                if (mob.Length == 11) {
                    return mob;
                }

                if (mob.Length == 12) {
                    return "0" + mob.Remove(0, 2);
                }

                if (mob.Length == 14) {
                    return "0" + mob.Remove(0, 4);
                }
            }

            return "";
        }

        public static string ToJSON(this object obj, bool Indented = true) {
            try {
                var stringEnumConverter = new JsonStringEnumConverter();
                JsonSerializerOptions opts = new JsonSerializerOptions();
                opts.Converters.Add(stringEnumConverter);
                opts.WriteIndented = Indented;
                opts.ReferenceHandler = ReferenceHandler.IgnoreCycles;

                return JsonSerializer.Serialize(obj, opts);

                //return Newtonsoft.Json.JsonConvert.SerializeObject(obj, new Newtonsoft.Json.JsonSerializerSettings {
                //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                //    Formatting = Indented ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None,
                //});
            }
            catch {
                return null;
            }
        }

        public static T ToObject<T>(this string str) {
            //return JsonSerializer.Deserialize<System.Dynamic.ExpandoObject>(str);
            return System.Text.Json.JsonSerializer.Deserialize<T>(str);
        }

        public static dynamic ToObject(this string str) {
            //return JsonSerializer.Deserialize<System.Dynamic.ExpandoObject>(str);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(str);
        }

        public static int Age(this DateTime birthDate) {
            return Age(birthDate, DateTime.Today);
        }

        public static int Age(this DateTime birthDate, DateTime laterDate) {
            return (int)((laterDate - birthDate).TotalDays / 365.242199);
        }

        public static bool isValueLess(this string str) {
            if (str is null) {
                return true;
            }

            if (str.Trim().Length == 0) {
                return true;
            }

            return false;
        }

        public static string GetSummaryByWordsCount(this string text, int numberWanted = 30) {
            if (string.IsNullOrEmpty(text)) {
                return "";
            }

            var delimiters = new[] {
            '\n',' ',
            '.','!','?',',',';','\'','\"',':',
            '.','!','؟','،','؛',
            '&'
         };

            var count = 0;
            var splitted = text.Split(delimiters);

            if (!splitted.Any()) {
                return "";
            }

            var arr = splitted.Take(numberWanted);
            foreach (var item in arr) {
                count += item.Length + 1;
            }
            return text.Substring(0, count - 1);
        }

        public static string GetSummaryByCharsCount(this string input, int maxLength = 200) {
            if (maxLength <= 0 || maxLength > input.Length) {
                return input;
            }
            else {
                int end = 0;
                for (int i = maxLength - 1; i > maxLength * 3 / 4; i--) {
                    if (" .,:;،؛!؟?".Contains(input[i])) {
                        end = i;
                        break;
                    }
                }
                if (end > 0) {
                    return input.Substring(0, end);
                }
                else {
                    return input.Substring(Math.Min(input.Length - 1, end));
                }
            }
        }


        public static string HashtagCleaner(this string NotClean) {
            var NotAllowed = @" `~!@#$%^&*()-=+|\/{}[];:'""<>.,?";
            NotAllowed += @"÷×‍‌‎؟ةيؤ،؛,ـءإأًٌٍَُِّ";


            NotClean = NotClean.Replace("ء", "")
            .Replace("ئ", "ی")
           .Replace("أ", "ا")
           .Replace("إ", "ا")
           .Replace("ؤ", "و")
           .Replace("ي", "ی")
           .Replace("ة", "ت")

           .Replace("ً", "")
           .Replace("ٌ", "")
           .Replace("ٍ", "")
           .Replace("َ", "")
           .Replace("ُ", "")
           .Replace("ِ", "")
           .Replace("ّ", "")
           .Replace("ـ", "");


            var s = NotClean.CleanString();
            foreach (var item in NotAllowed) {
                s = s.Replace(item.ToString(), "");
            }

            return s.ToLower();
        }

        public static string SlugMaker(this string str, string joinChar = "-") {
            str = "" + str;
            str = str.CleanString();
            str = "" + str;

            str = str.Replace("ء", "")
           .Replace("ئ", "ی")
           .Replace("أ", "ا")
           .Replace("إ", "ا")
           .Replace("ؤ", "و")
           .Replace("ي", "ی")
           .Replace("ة", "ت")

           .Replace("ً", "")
           .Replace("ٌ", "")
           .Replace("ٍ", "")
           .Replace("َ", "")
           .Replace("ُ", "")
           .Replace("ِ", "")
           .Replace("ّ", "")
           .Replace("ـ", "");

            var NotAllowed = @"()[ ]{}<>/|\=+_~?!@#$%^&*:;""'.,÷×";
            NotAllowed += @"،؛,؟‍‌‎";


            foreach (var item in NotAllowed) {
                str = str.Replace(item.ToString(), joinChar);
            }

            var joinChar2 = joinChar + joinChar;
            if (!joinChar2.isValueLess()) {
                while (str.Contains(joinChar2)) {
                    str = str.Replace(joinChar2, joinChar);
                }
            }

            return str.ToLower();
        }

        public static string GetStringValue(this string? self) {
            if (self is null) {
                return "";
            }
            else {
                return self.Trim();
            }
        }

    }
}

#pragma warning restore CS8603 // Possible null reference return.
