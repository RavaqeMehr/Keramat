namespace Services.AppUsingLogs.Models {
    public class GetChangesLogQuery {
        public int Page { get; set; } = 1;
        public int? AppSessionId { get; set; }
    }
}
