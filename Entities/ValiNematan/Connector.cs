using Common.Utilities;
using Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace Entities.ValiNematan {
    public class Connector : BaseEntity {
        [Order]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Order]
        [Display(Name = "تلفن")]
        public string Phone { get; set; }
        [Order]
        [Display(Name = "ملاحظات")]
        public string? Description { get; set; }

        [Order]
        [Display(Name = "خانواده‌ها")]
        public virtual ObservableCollectionListSource<Family> Families { get; } = new();
    }
}
