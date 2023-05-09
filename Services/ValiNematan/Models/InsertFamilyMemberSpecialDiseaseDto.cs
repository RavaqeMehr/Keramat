namespace Services.ValiNematan.Models {
    public class InsertFamilyMemberSpecialDiseaseDto {
        public int FamilyMemberId { get; set; }
        public int FamilyMemberSpecialDiseaseSubjectId { get; set; }
        public string? Description { get; set; }
    }
}
