namespace Services.Services.Models {
    public class ServiceProvidedUpdateDto {
        public int Id { get; set; }
        public int ServiceSubjectId { get; set; }
        public string Description { get; set; } = "";
    }
}
