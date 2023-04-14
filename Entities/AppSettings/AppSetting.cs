using Entities.Common;

namespace Entities.AppSettings {
    public class AppSetting : BaseEntity {
        public string Key { get; set; }
        public string Val { get; set; }
    }
}
