namespace Services.Services.Models {
    public class ServiceProvidedGetListByFamilyItemDto {
        public int Id { get; set; }
        public string Description { get; set; } = "";

        public int ServiceSubjectId { get; set; }
        public string ServiceSubjectTitle { get; set; } = "";

        public int ServiceProvidedId { get; set; }
        public string ServiceProvidedDescription { get; set; } = "";
        public DateTime Date { get; set; }
    }
}
