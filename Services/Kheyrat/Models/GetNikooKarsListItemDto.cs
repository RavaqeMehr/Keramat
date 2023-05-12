namespace Services.Kheyrat.Models {
    public class GetNikooKarsListItemDto {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Phone { get; set; } = "";
        public int KheyratCount { get; set; }
        public string AddDateStr { get; set; }
    }
}
