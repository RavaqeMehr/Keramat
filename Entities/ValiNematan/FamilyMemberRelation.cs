using Entities.Common;

namespace Entities.ValiNematan {
    public class FamilyMemberRelation : BaseEntity {
        public int Order { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
