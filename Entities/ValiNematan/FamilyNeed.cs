using Entities.Common;

namespace Entities.ValiNematan {
    public class FamilyNeed : BaseEntity {
        public int Order { get; set; }
        public int FamilyNeedSubjectId { get; set; }
        public FamilyNeedSubject FamilyNeedSubject { get; set; }
        public string? Description { get; set; }
    }
}
