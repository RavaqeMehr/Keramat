using static Entities.ValiNematan.Enums;

namespace Services.ValiNematan.Models {
    public class GetFamilyMembersItemDto {
        public int Id { get; set; }
        public int FamilyMemberRelationId { get; set; }
        public Gender Gender { get; set; } = Gender.NotSet;
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.NotSet;
        public string Name { get; set; }
        public LiveStatus LiveStatus { get; set; } = LiveStatus.NotSet;
        public int? Age { get; set; }
    }
}
