using Common;
using Common.Utilities;
using Data;
using Entities.AppUsingLogs;
using Entities.Common;
using Services.AppUsingLogs.Models;

namespace Services.AppUsingLogs {
    public interface IAddEntityChangeService : ITransientDependency {
        Task Exe(AddEntityChangeInputs inputs);
    }

    public class AddEntityChangeService : IAddEntityChangeService {
        private readonly IAppSessionService appSessionService;
        private readonly IRepository<EntityChanges> entityChangesRepo;

        public AddEntityChangeService(
            IAppSessionService appSessionService,
            IRepository<EntityChanges> entityChangesRepo
            ) {
            this.appSessionService = appSessionService;
            this.entityChangesRepo = entityChangesRepo;
        }

        public async Task Exe(AddEntityChangeInputs inputs) {
            var now = DateTime.Now;
            var nowFa = now.ToPersianDateTime();
            var diff = inputs.ObjA.Compare(inputs.ObjB, typeof(IEntity));
            var changes = inputs.ChangeType == ChangeType.Edit ? diff.Print() : diff.PrintA();

            var item = new EntityChanges {
                AppSessionId = appSessionService.ThisSession.Id,
                Date = now,
                DateY = nowFa.Year,
                DateM = nowFa.Month,
                DateD = nowFa.Day,
                EnitityType = inputs.EnitityType,
                ChangeType = inputs.ChangeType,
                EnitityId = inputs.EnitityId,
                Root1Id = inputs.Root1Id,
                Root2Id = inputs.Root2Id,
                Root3Id = inputs.Root3Id,
                Changes = changes
            };

            await entityChangesRepo.AddAsync(item);
        }
    }
}
