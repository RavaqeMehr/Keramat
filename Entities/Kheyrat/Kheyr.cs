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
        [Display(Name = "پرداخت نقدی")]
        public bool HasCash { get; set; }
        [Order]
        [Display(Name = "ارزش ریالی پرداخت نقدی")]
        public int CashValue { get; set; }
        [Order]
        [Display(Name = "شرح پرداخت نقدی")]
        public string CashDescription { get; set; }

        [Order]
        [Display(Name = "پرداخت غیر نقدی")]
        public bool HasNotCash { get; set; }
        [Order]
        [Display(Name = "ارزش ریالی پرداخت غیر نقدی")]
        public int NotCashValue { get; set; }
        [Order]
        [Display(Name = "شرح پرداخت غیر نقدی")]
        public string NotCashDescription { get; set; }

        [Order]
        [Display(Name = "ارزش ریالی کل")]
        public int CashAndNotCashValues { get; set; }

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
