using Entities.AppUsingLogs;

namespace Services.AppUsingLogs.Models {
    public class EntityChangesDto {
        public int Id { get; set; }
        public int AppSessionId { get; set; }
        public DateTime Date { get; set; }
        public ChangeType ChangeType { get; set; }
        public EnitityType EnitityType { get; set; }

        public int EntityId { get; set; }
        public int? Root1Id { get; set; }
        public int? Root2Id { get; set; }
        public int? Root3Id { get; set; }

        public string[] ChangedProps { get; set; }
        public int ChangedPropsCount { get; set; }
    }
}
