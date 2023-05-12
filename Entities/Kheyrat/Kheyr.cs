using Common.Utilities;
using Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Entities.Kheyrat {
    public class Kheyr : BaseEntity {
        [Order]
        [Display(Name = "کد نیکوکار")]
        public int NikooKarId { get; set; }
        [Order]
        [Display(Name = "نیکوکار")]
        public NikooKar NikooKar { get; set; }

        [Order]
        [Display(Name = "شرح")]
        public string Description { get; set; }
        [Order]
        [Display(Name = "ارزش ریالی")]
        public int Value { get; set; }


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
    }
}
