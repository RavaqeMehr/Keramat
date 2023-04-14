using Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static Entities.ValiNematan.Enums;

namespace Entities.ValiNematan {
    public class FamilyMember : BaseEntity {
        public int FamilyId { get; set; }
        public Family Family { get; set; }

        public int FamilyMemberRelationId { get; set; }
        public FamilyMemberRelation FamilyMemberRelation { get; set; }

        public Gender Gender { get; set; } = Gender.NotSet;
        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.NotSet;

        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? NationalCode { get; set; }

        public string? Job { get; set; }
        public string? JobDescription { get; set; }
        public string? JobAdrees { get; set; }
        public string? JobPhone { get; set; }

        public LiveStatus LiveStatus { get; set; } = LiveStatus.NotSet;

        public string? ImpreciseBirthDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? BirthDateY { get; set; }
        public int? BirthDateM { get; set; }
        public int? BirthDateD { get; set; }

        public string? ImpreciseDeathDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public int? DeathDateY { get; set; }
        public int? DeathDateM { get; set; }
        public int? DeathDateD { get; set; }

        public virtual ObservableCollectionListSource<FamilyMemberNeed> Needs { get; } = new();
        public virtual ObservableCollectionListSource<FamilyMemberSpecialDisease> SpecialDiseases { get; } = new();

    }
}
