namespace Services.Kheyrat.Models {
    public class KheyrUpdateDto {
        public int Id { get; set; }
        public int CashValue { get; set; }
        public string CashDescription { get; set; }
        public int NotCashValue { get; set; }
        public string NotCashDescription { get; set; }
    }
}
