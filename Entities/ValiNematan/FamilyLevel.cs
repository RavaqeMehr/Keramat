using Entities.Common;

namespace Entities.ValiNematan {
    public class FamilyLevel : BaseEntity {
        public int Level { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
