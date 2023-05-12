namespace Services.Kheyrat.Models {
    public class NikooKarUpdateDto {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public string Description { get; set; } = "";

        public string Job { get; set; } = "";
        public string JobDescription { get; set; } = "";
        public string JobAddress { get; set; } = "";
        public string JobPhone { get; set; } = "";
    }
}
