using Entities.Common;

namespace Entities.ValiNematan {
    public class FamilyMemberNeed : BaseEntity {
        public int Order { get; set; }
        public int FamilyMemberNeedSubjectId { get; set; }
        public FamilyMemberNeedSubject FamilyMemberNeedSubject { get; set; }
        public string? Description { get; set; }
    }
}
