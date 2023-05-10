using Entities.Common;

namespace Entities.AppUsingLogs {
    public class EntityChanges : BaseEntity<long> {
        public int AppSessionId { get; set; }
        public AppSession AppSession { get; set; }

        public DateTime Date { get; set; }
        public int DateY { get; set; }
        public int DateM { get; set; }
        public int DateD { get; set; }

        public ChangeType ChangeType { get; set; }
        public EnitityType EnitityType { get; set; }

        public int EntityId { get; set; }
        public int? Root1Id { get; set; }
        public int? Root2Id { get; set; }
        public int? Root3Id { get; set; }

        public string? Changes { get; set; }
    }

    public enum ChangeType {
        Add = 1,
        Edit = 2,
        Delete = 3
    }

    public enum EnitityType {
        NotSet = -1,

        Family = 100,
        FamilyLevel = 101,
        FamilyNeed = 102,
        FamilyNeedSubject = 103,
        Connector = 104,

        FamilyMember = 110,
        FamilyMemberNeed = 111,
        FamilyMemberNeedSubject = 112,
        FamilyMemberRelation = 113,
        FamilyMemberSpecialDisease = 114,
        FamilyMemberSpecialDiseaseSubject = 115,
    }
}
