using System.Globalization;

namespace Common.GlobalConfigs {
    public class enUsCulture : CultureInfo {
        private readonly Calendar _calendar;
        private readonly Calendar[] _optionalCalendars;
        private DateTimeFormatInfo _dateTimeFormatInfo;

        public enUsCulture() : base("en-US") {
            _calendar = new GregorianCalendar();

            _optionalCalendars = new List<Calendar>
            {
            new GregorianCalendar(),
            new PersianCalendar()
        }.ToArray();

            var dateTimeFormatInfo = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
            dateTimeFormatInfo.Calendar = _calendar;
            _dateTimeFormatInfo = dateTimeFormatInfo;
        }

        public override Calendar Calendar => _calendar;

        public override Calendar[] OptionalCalendars => _optionalCalendars;

        public override DateTimeFormatInfo DateTimeFormat {
            get => _dateTimeFormatInfo;
            set => _dateTimeFormatInfo = value;
        }
    }
    public static class DateTimeConfig {
        public static void Set() {
            var defaultCulture = new enUsCulture();
            CultureInfo.CurrentCulture = defaultCulture;
            CultureInfo.CurrentUICulture = defaultCulture;
            CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
            CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;
        }
    }
}
