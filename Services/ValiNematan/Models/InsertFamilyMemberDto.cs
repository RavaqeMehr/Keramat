using static Entities.ValiNematan.Enums;

namespace Services.ValiNematan.Models {
    public class InsertFamilyMemberDto {
        public int FamilyId { get; set; }
        public int FamilyMemberRelationId { get; set; }
        public Gender Gender { get; set; } = Gender.NotSet;
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.NotSet;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public string Phone { get; set; }
        public string NationalCode { get; set; }
        public string Description { get; set; }
        public LiveStatus LiveStatus { get; set; } = LiveStatus.NotSet;
        public string? BirthDateStr { get; set; }
        public bool IsBirthDateImprecise { get; set; }
        public string? DeathDateStr { get; set; }
        public bool IsDeathDateImprecise { get; set; }
    }
}