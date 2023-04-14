using Entities.Common;

namespace Entities.ValiNematan {

    public class FamilyMemberSpecialDisease : BaseEntity {
        public int Order { get; set; }
        public int FamilyMemberSpecialDiseaseSubjectId { get; set; }
        public FamilyMemberSpecialDiseaseSubject FamilyMemberSpecialDiseaseSubject { get; set; }
        public string? Description { get; set; }
    }
}
