using Common.Utilities;
using Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Entities.ValiNematan {
    public class FamilyLevel : BaseEntity {
        [Order]
        [Display(Name = "سطح")]
        public int Level { get; set; }
        [Order]
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
        [Order]
        [Display(Name = "ملاحظات")]
        public string? Description { get; set; }
    }
}
