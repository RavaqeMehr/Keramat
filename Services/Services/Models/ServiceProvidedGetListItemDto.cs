namespace Services.Services.Models {
    public class ServiceProvidedGetListItemDto {
        public int Id { get; set; }
        public int ServiceSubjectId { get; set; }
        public string ServiceSubjectTitle { get; set; } = "";
        public DateTime Date { get; set; }
        public int ReciversCount { get; set; }
    }
}
