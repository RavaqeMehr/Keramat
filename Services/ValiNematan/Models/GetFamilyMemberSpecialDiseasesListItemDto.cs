namespace Services.ValiNematan.Models {
    public class GetFamilyMemberSpecialDiseasesListItemDto {
        public int Id { get; set; }
        public int Order { get; set; }
        public int FamilyMemberSpecialDiseaseSubjectId { get; set; }
        public string? Description { get; set; }
    }
}
