using Common.Utilities;
using Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Entities.ValiNematan {
    public class FamilyNeed : BaseEntity {
        [Order]
        [Display(Name = "کد خانواده")]
        public int FamilyId { get; set; }
        [Order]
        [Display(Name = "خانواده")]
        public Family Family { get; set; }
        [Order]
        [Display(Name = "ترتیب")]
        public int Order { get; set; }
        [Order]
        [Display(Name = "کد موضوع")]
        public int FamilyNeedSubjectId { get; set; }
        [Order]
        [Display(Name = "موضوع")]
        public FamilyNeedSubject FamilyNeedSubject { get; set; }
        [Order]
        [Display(Name = "ملاحظات")]
        public string? Description { get; set; }
    }
}
