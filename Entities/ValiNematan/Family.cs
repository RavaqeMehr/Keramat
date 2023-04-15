using Common.Utilities;
using Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace Entities.ValiNematan {
    public class Family : BaseEntity {
        [Order]
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
        [Order]
        [Display(Name = "آدرس")]
        public string? Address { get; set; }
        [Order]
        [Display(Name = "سطح")]
        public int Level { get; set; }
        [Order]
        [Display(Name = "ملاحظات")]
        public string? Description { get; set; }

        [Order]
        [Display(Name = "نام رابط")]
        public string? ContactPersonName { get; set; }
        [Order]
        [Display(Name = "تلفن رابط")]
        public string? ContactPersonPhone { get; set; }
        [Order]
        [Display(Name = "ملاحظات رابط")]
        public string? ContactPersonDescription { get; set; }

        [Order]
        [Display(Name = "کد معرف")]
        public int? ConnectorId { get; set; }
        [Order]
        [Display(Name = "معرف")]
        public Connector Connector { get; set; }

        [Order]
        [Display(Name = "تاریخ درج")]
        public DateTime AddDate { get; set; }
        [Order]
        [Display(Name = "سال درج")]
        public int AddDateY { get; set; }
        [Order]
        [Display(Name = "ماه درج")]
        public int AddDateM { get; set; }
        [Order]
        [Display(Name = "روز درج")]
        public int AddDateD { get; set; }

        [Order]
        [Display(Name = "نیازها")]
        public virtual ObservableCollectionListSource<FamilyNeed> Needs { get; } = new();
        [Order]
        [Display(Name = "اعضاء")]
        public virtual ObservableCollectionListSource<FamilyMember> Members { get; } = new();
    }
}
