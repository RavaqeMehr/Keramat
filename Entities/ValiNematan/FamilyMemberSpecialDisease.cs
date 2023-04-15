using Common.Utilities;
using Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Entities.ValiNematan {

    public class FamilyMemberSpecialDisease : BaseEntity {
        [Order]
        [Display(Name = "ترتیب")]
        public int Order { get; set; }
        [Order]
        [Display(Name = "کد موضوع")]
        public int FamilyMemberSpecialDiseaseSubjectId { get; set; }
        [Order]
        [Display(Name = "موضوع")]
        public FamilyMemberSpecialDiseaseSubject FamilyMemberSpecialDiseaseSubject { get; set; }
        [Order]
        [Display(Name = "ملاحظات")]
        public string? Description { get; set; }
    }
}
