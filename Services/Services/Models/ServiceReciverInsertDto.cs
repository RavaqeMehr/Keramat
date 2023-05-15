namespace Services.Services.Models {
    public class ServiceReciverInsertDto {
        public int FamilyId { get; set; }
        public int ServiceProvidedId { get; set; }
        public string Description { get; set; } = "";
    }
}
