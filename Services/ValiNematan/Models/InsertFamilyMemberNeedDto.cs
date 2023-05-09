namespace Services.ValiNematan.Models {
    public class InsertFamilyMemberNeedDto {
        public int FamilyMemberId { get; set; }
        public int FamilyMemberNeedSubjectId { get; set; }
        public string? Description { get; set; }
    }
}
