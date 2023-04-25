using Entities.Common;

namespace Entities.AppUsingLogs {
    public class AppSession : BaseEntity {
        public DateTime StartDate { get; set; }
        public int StartDateY { get; set; }
        public int StartDateM { get; set; }
        public int StartDateD { get; set; }

        public DateTime EndDate { get; set; }
        public int EndDateY { get; set; }
        public int EndDateM { get; set; }
        public int EndDateD { get; set; }

        public int DurationSeconds { get; set; }
    }
}
