namespace Services.ValiNematan.Models {
    public class GetFamilyNeedsListItemDto {
        public int Id { get; set; }
        public int Order { get; set; }
        public int FamilyNeedSubjectId { get; set; }
        public string? Description { get; set; }
    }
}
