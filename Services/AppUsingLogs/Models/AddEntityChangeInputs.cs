using Entities.AppUsingLogs;

namespace Services.AppUsingLogs.Models {
    public class AddEntityChangeInputs<T> {
        public ChangeType ChangeType { get; set; }
        public EnitityType EnitityType { get; set; }

        public T ObjA { get; set; }
        public T? ObjB { get; set; }

        public int EnitityId { get; set; }
        public int? Root1Id { get; set; }
        public int? Root2Id { get; set; }
        public int? Root3Id { get; set; }
    }
}
