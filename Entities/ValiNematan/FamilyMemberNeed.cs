using Common.Utilities;
using Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Entities.ValiNematan {
    public class FamilyMemberNeed : BaseEntity {
        [Order]
        [Display(Name = "ترتیب")]
        public int Order { get; set; }
        [Order]
        [Display(Name = "کد موضوع")]
        public int FamilyMemberNeedSubjectId { get; set; }
        [Order]
        [Display(Name = "موضوع")]
        public FamilyMemberNeedSubject FamilyMemberNeedSubject { get; set; }
        [Order]
        [Display(Name = "ملاحظات")]
        public string? Description { get; set; }
    }
}
