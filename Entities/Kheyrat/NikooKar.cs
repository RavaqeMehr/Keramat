using Common.Utilities;
using Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace Entities.Kheyrat {
    public class NikooKar : BaseEntity {
        [Order]
        [Display(Name = "نام")]
        public string FullName { get; set; } = "";
        [Order]
        [Display(Name = "تلفن")]
        public string Phone { get; set; } = "";
        [Order]
        [Display(Name = "آدرس منزل")]
        public string Address { get; set; } = "";
        [Order]
        [Display(Name = "ملاحظات")]
        public string Description { get; set; } = "";

        [Order]
        [Display(Name = "شغل")]
        public string Job { get; set; } = "";
        [Order]
        [Display(Name = "ملاحظات شغل")]
        public string JobDescription { get; set; } = "";
        [Order]
        [Display(Name = "آدرس محل‌کار")]
        public string JobAddress { get; set; } = "";
        [Order]
        [Display(Name = "تلفن محل‌کار")]
        public string JobPhone { get; set; } = "";

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
        [Display(Name = "خیرات")]
        public virtual ObservableCollectionListSource<Kheyr> Kheyrat { get; } = new();
        [Order]
        [Display(Name = "تعداد دفعات خیرات")]
        public int KheyratCount { get; set; }
    }
}
