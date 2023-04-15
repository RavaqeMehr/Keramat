using Entities.AppUsingLogs;

namespace Services.AppUsingLogs.Models {
    public class AddEntityChangeInputs {
        public ChangeType ChangeType { get; set; }
        public EnitityType EnitityType { get; set; }

        public object ObjA { get; set; }
        public object? ObjB { get; set; }

        public int EnitityId { get; set; }
        public int? Root1Id { get; set; }
        public int? Root2Id { get; set; }
        public int? Root3Id { get; set; }
    }
}
