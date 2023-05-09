namespace Services.ValiNematan.Models {
    public class GetFamilyMemberNeedsListItemDto {
        public int Id { get; set; }
        public int Order { get; set; }
        public int FamilyMemberNeedSubjectId { get; set; }
        public string? Description { get; set; }
    }
}
