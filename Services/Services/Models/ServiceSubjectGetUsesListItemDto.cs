namespace Services.Services.Models {
    public class ServiceSubjectGetUsesListItemDto {
        public int ServiceSubjectId { get; set; }
        public string ServiceSubjectTitle { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Date { get; set; }
    }
}
