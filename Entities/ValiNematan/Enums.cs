using System.ComponentModel.DataAnnotations;

namespace Entities.ValiNematan {
    public class Enums {
        public enum LiveStatus {
            [Display(Name = "نامشخص")] NotSet = -1,
            [Display(Name = "زنده")] Live = 0,
            [Display(Name = "کما")] Coma = 1,
            [Display(Name = "فوت‌شده")] Dead = 2,
            [Display(Name = "شهید")] Martyr = 3,
        }
    }
}
