namespace Services.AppUsingLogs.Models {
    public class AppSessionDto {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DurationSeconds { get; set; }
        public int ChangesCount { get; set; }
    }
}
