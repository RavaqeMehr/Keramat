using Common.Utilities;
using Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Entities.ValiNematan {
    public class FamilyMemberRelation : BaseEntity {
        [Order]
        [Display(Name = "ترتیب")]
        public int Order { get; set; }
        [Order]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Order]
        [Display(Name = "ملاحظات")]
        public string? Description { get; set; }
    }
}
