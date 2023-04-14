using Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Entities.ValiNematan {
    public class Connector : BaseEntity {
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ObservableCollectionListSource<Family> Families { get; } = new();
    }
}
