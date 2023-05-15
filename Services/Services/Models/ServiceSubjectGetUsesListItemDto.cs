namespace Services.Services.Models {
    public class ServiceSubjectGetUsesListItemDto {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public DateTime Date { get; set; }
        public int ReciversCount { get; set; }
    }
}
