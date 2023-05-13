using Common.Utilities;
using Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Entities.Services {
    public class ServiceSubject : BaseEntity {
        [Order]
        [Display(Name = "عنوان")]
        public string Title { get; set; } = "";
        [Order]
        [Display(Name = "ملاحظات")]
        public string Description { get; set; } = "";
    }
}
