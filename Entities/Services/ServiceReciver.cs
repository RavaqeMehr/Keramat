using Common.Utilities;
using Entities.Common;
using Entities.ValiNematan;
using System.ComponentModel.DataAnnotations;

namespace Entities.Services {
    public class ServiceReciver : BaseEntity {
        [Order]
        [Display(Name = "کد خانواده")]
        public int FamilyId { get; set; }
        [Order]
        [Display(Name = "خانواده")]
        public Family Family { get; set; }

        [Order]
        [Display(Name = "کد خدمت ارائه‌شده")]
        public int ServiceProvidedId { get; set; }
        [Order]
        [Display(Name = "خدمت ارائه‌شده")]
        public ServiceProvided ServiceProvided { get; set; }

        [Order]
        [Display(Name = "ملاحظات")]
        public string Description { get; set; } = "";
    }
}
