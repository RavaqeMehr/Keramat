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

        public enum Gender {
            [Display(Name = "نامشخص")] NotSet = -1,
            [Display(Name = "مذکر")] Male = 0,
            [Display(Name = "مونث")] Female = 1,
            [Display(Name = "دوجنسه")] Intersex = 2,
        }

        public enum MaritalStatus {
            [Display(Name = "نامشخص")] NotSet = -1,
            [Display(Name = "مجرد")] Single = 0,
            [Display(Name = "متاهل")] Married = 1,
            [Display(Name = "بیوه")] Widow = 2,
            [Display(Name = "مطلقه")] Divorced = 3,
        }
    }
}
