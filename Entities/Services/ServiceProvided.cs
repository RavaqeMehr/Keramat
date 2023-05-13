using Common.Utilities;
using Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace Entities.Services {
    public class ServiceProvided : BaseEntity {
        [Order]
        [Display(Name = "کد موضوع")]
        public int ServiceSubjectId { get; set; }
        [Order]
        [Display(Name = "موضوع")]
        public ServiceSubject ServiceSubject { get; set; }

        [Order]
        [Display(Name = "ملاحظات")]
        public string Description { get; set; } = "";

        [Order]
        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; }
        [Order]
        [Display(Name = "سال")]
        public int DateY { get; set; }
        [Order]
        [Display(Name = "ماه")]
        public int DateM { get; set; }
        [Order]
        [Display(Name = "روز")]
        public int DateD { get; set; }

        [Order]
        [Display(Name = "دریافت‌کنندگان")]
        public virtual ObservableCollectionListSource<ServiceReciver> Recivers { get; } = new();
    }
}
