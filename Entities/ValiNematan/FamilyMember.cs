using Common.Utilities;
using Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;
using static Entities.ValiNematan.Enums;

namespace Entities.ValiNematan {
    public class FamilyMember : BaseEntity {
        [Order]
        [Display(Name = "کد خانواده")]
        public int FamilyId { get; set; }
        [Order]
        [Display(Name = "خانواده")]
        public Family Family { get; set; }

        [Order]
        [Display(Name = "کد نسبت")]
        public int FamilyMemberRelationId { get; set; }
        [Order]
        [Display(Name = "نسبت")]
        public FamilyMemberRelation FamilyMemberRelation { get; set; }

        [Order]
        [Display(Name = "جنسیت")]
        public Gender Gender { get; set; } = Gender.NotSet;
        [Order]
        [Display(Name = "وضعیت تاهل")]
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.NotSet;

        [Order]
        [Display(Name = "نام")]
        public string? Name { get; set; }
        [Order]
        [Display(Name = "تلفن")]
        public string? Phone { get; set; }
        [Order]
        [Display(Name = "کد ملی")]
        public string? NationalCode { get; set; }

        [Order]
        [Display(Name = "شغل")]
        public string? Job { get; set; }
        [Order]
        [Display(Name = "ملاحظات شغل")]
        public string? JobDescription { get; set; }
        [Order]
        [Display(Name = "آدرس محل‌کار")]
        public string? JobAdrees { get; set; }
        [Order]
        [Display(Name = "تلفن محل‌کار")]
        public string? JobPhone { get; set; }

        [Order]
        [Display(Name = "وضعیت حیات")]
        public LiveStatus LiveStatus { get; set; } = LiveStatus.NotSet;

        [Order]
        [Display(Name = "تاریخ غیر دقیق تولد")]
        public string? ImpreciseBirthDate { get; set; }
        [Order]
        [Display(Name = "تاریخ تولد")]
        public DateTime? BirthDate { get; set; }
        [Order]
        [Display(Name = "سال تولد")]
        public int? BirthDateY { get; set; }
        [Order]
        [Display(Name = "ماه تولد")]
        public int? BirthDateM { get; set; }
        [Order]
        [Display(Name = "روز تولد")]
        public int? BirthDateD { get; set; }

        [Order]
        [Display(Name = "تاریخ غیر دقیق وفات/شهادت")]
        public string? ImpreciseDeathDate { get; set; }
        [Order]
        [Display(Name = "تاریخ وفات/شهادت")]
        public DateTime? DeathDate { get; set; }
        [Order]
        [Display(Name = "سال وفات/شهادت")]
        public int? DeathDateY { get; set; }
        [Order]
        [Display(Name = "ماه وفات/شهادت")]
        public int? DeathDateM { get; set; }
        [Order]
        [Display(Name = "روز وفات/شهادت")]
        public int? DeathDateD { get; set; }

        [Order]
        [Display(Name = "نیازها")]
        public virtual ObservableCollectionListSource<FamilyMemberNeed> Needs { get; } = new();
        [Order]
        [Display(Name = "بیماری‌های خاص")]
        public virtual ObservableCollectionListSource<FamilyMemberSpecialDisease> SpecialDiseases { get; } = new();

    }
}
