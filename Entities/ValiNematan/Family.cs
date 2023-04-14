using Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Entities.ValiNematan {
    public class Family : BaseEntity {
        public string? Title { get; set; }
        public string? Address { get; set; }
        public int Level { get; set; }
        public string? Description { get; set; }


        public string? ContactPersonName { get; set; }
        public string? ContactPersonPhone { get; set; }
        public string? ContactPersonDescription { get; set; }

        public int? ConnectorId { get; set; }
        public Connector Connector { get; set; }

        public DateTime AddDate { get; set; }
        public int AddDateY { get; set; }
        public int AddDateM { get; set; }
        public int AddDateD { get; set; }

        public virtual ObservableCollectionListSource<FamilyNeed> Needs { get; } = new();
        public virtual ObservableCollectionListSource<FamilyMember> Members { get; } = new();
    }
}
