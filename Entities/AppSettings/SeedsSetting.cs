using Entities.Common;

namespace Entities.AppSettings {
    public class SeedsSetting : BaseEntity {
        public string Key { get; set; }
        public int Val { get; set; }
    }
}
