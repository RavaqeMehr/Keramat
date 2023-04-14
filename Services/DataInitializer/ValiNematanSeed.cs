using Data;
using Entities.AppSettings;
using Entities.ValiNematan;

namespace Services.DataInitializer {
    public class ValiNematanSeed : IDataInitializer {
        private readonly IRepository<AppSetting> appSettingRepo;
        private readonly IRepository<FamilyLevel> familyLevelRepo;
        private readonly IRepository<FamilyMemberNeedSubject> familyMemberNeedSubjectRepo;
        private readonly IRepository<FamilyNeedSubject> familyNeedSubjectRepo;
        private readonly IRepository<FamilyMemberRelation> familyMemberRelationRepo;
        private readonly IRepository<FamilyMemberSpecialDiseaseSubject> familyMemberSpecialDiseaseSubjectRepo;

        public ValiNematanSeed(
            IRepository<AppSetting> appSettingRepo,
            IRepository<FamilyLevel> familyLevelRepo,
            IRepository<FamilyNeedSubject> familyNeedSubjectRepo,
            IRepository<FamilyMemberNeedSubject> familyMemberNeedSubjectRepo,
            IRepository<FamilyMemberRelation> familyMemberRelationRepo,
            IRepository<FamilyMemberSpecialDiseaseSubject> familyMemberSpecialDiseaseSubjectRepo
            ) {
            this.appSettingRepo = appSettingRepo;
            this.familyLevelRepo = familyLevelRepo;
            this.familyNeedSubjectRepo = familyNeedSubjectRepo;
            this.familyMemberNeedSubjectRepo = familyMemberNeedSubjectRepo;
            this.familyMemberRelationRepo = familyMemberRelationRepo;
            this.familyMemberSpecialDiseaseSubjectRepo = familyMemberSpecialDiseaseSubjectRepo;
        }

        public int Order => 1;

        public void InitializeData() {
            var lastInstalledVerNum = int.Parse("0" + appSettingRepo.TableNoTracking.FirstOrDefault(x => x.Key == AppSettingsKeys.Last_Installed_Version)?.Val);

            var familyLevelAdd = new List<FamilyLevel>();
            var familyNeedSubjectAdd = new List<FamilyNeedSubject>();
            var familyMemberNeedSubjectAdd = new List<FamilyMemberNeedSubject>();
            var familyMemberRelationAdd = new List<FamilyMemberRelation>();
            var familyMemberSpecialDiseaseSubjectAdd = new List<FamilyMemberSpecialDiseaseSubject>();

            if (lastInstalledVerNum <= 3) {
                familyLevelAdd.Add(new FamilyLevel { Level = 1, Title = "نامشخص" });
                familyLevelAdd.Add(new FamilyLevel { Level = 2, Title = "بحرانی" });
                familyLevelAdd.Add(new FamilyLevel { Level = 3, Title = "خیلی محتاج" });
                familyLevelAdd.Add(new FamilyLevel { Level = 4, Title = "محتاج" });

                familyNeedSubjectAdd.Add(new FamilyNeedSubject { Title = "بسته ارزاق" });
                familyNeedSubjectAdd.Add(new FamilyNeedSubject { Title = "کمک‌هزینه اجاره منزل" });
                familyNeedSubjectAdd.Add(new FamilyNeedSubject { Title = "کمک‌هزینه خرید دارو" });
                familyNeedSubjectAdd.Add(new FamilyNeedSubject { Title = "دارو" });
                familyNeedSubjectAdd.Add(new FamilyNeedSubject { Title = "اسباب منزل" });
                familyNeedSubjectAdd.Add(new FamilyNeedSubject { Title = "اسباب کار" });
                familyNeedSubjectAdd.Add(new FamilyNeedSubject { Title = "کمک‌هزینه اجاره محل کار" });

                familyMemberNeedSubjectAdd.Add(new FamilyMemberNeedSubject { Title = "شناسنامه" });
                familyMemberNeedSubjectAdd.Add(new FamilyMemberNeedSubject { Title = "بیمه" });
                familyMemberNeedSubjectAdd.Add(new FamilyMemberNeedSubject { Title = "لوازم‌التحریر" });
                familyMemberNeedSubjectAdd.Add(new FamilyMemberNeedSubject { Title = "لباس" });

                familyMemberRelationAdd.Add(new FamilyMemberRelation { Order = 1, Title = "پدر" });
                familyMemberRelationAdd.Add(new FamilyMemberRelation { Order = 2, Title = "مادر" });
                familyMemberRelationAdd.Add(new FamilyMemberRelation { Order = 3, Title = "فرزند" });
                familyMemberRelationAdd.Add(new FamilyMemberRelation { Order = 4, Title = "پدربزرگ" });
                familyMemberRelationAdd.Add(new FamilyMemberRelation { Order = 5, Title = "مادربزرگ" });
                familyMemberRelationAdd.Add(new FamilyMemberRelation { Order = 6, Title = "عروس" });
                familyMemberRelationAdd.Add(new FamilyMemberRelation { Order = 7, Title = "داماد" });
                familyMemberRelationAdd.Add(new FamilyMemberRelation { Order = 8, Title = "نوه" });
                familyMemberRelationAdd.Add(new FamilyMemberRelation { Order = 9, Title = "بستگان" });

                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "فلج گردن به پائین" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "فلج کمر به پائین" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "فلجی یک پا" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "فلجی یک دست" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "نابینائی کامل" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "نابینائی یک چشم" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "کم‌بینائی" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "ناشنوائی کامل" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "ناشنوائی یک گوش" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "کم‌شنوائی" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "اوتیسم" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "سندروم دان" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "سرع" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "سرطان" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "فشار خون" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "دیابت" });
                familyMemberSpecialDiseaseSubjectAdd.Add(new FamilyMemberSpecialDiseaseSubject { Title = "بیماری نادر" });
            }

            if (familyLevelAdd.Count > 0) {
                familyLevelRepo.AddRange(familyLevelAdd);
            }

            if (familyNeedSubjectAdd.Count > 0) {
                familyNeedSubjectRepo.AddRange(familyNeedSubjectAdd);
            }

            if (familyMemberNeedSubjectAdd.Count > 0) {
                familyMemberNeedSubjectRepo.AddRange(familyMemberNeedSubjectAdd);
            }

            if (familyMemberRelationAdd.Count > 0) {
                familyMemberRelationRepo.AddRange(familyMemberRelationAdd);
            }

            if (familyMemberSpecialDiseaseSubjectAdd.Count > 0) {
                familyMemberSpecialDiseaseSubjectRepo.AddRange(familyMemberSpecialDiseaseSubjectAdd);
            }
        }
    }
}
