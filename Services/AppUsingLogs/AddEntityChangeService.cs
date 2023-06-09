﻿using Common;
using Common.Utilities;
using Data;
using Entities.AppUsingLogs;
using Entities.Common;
using Services.AppUsingLogs.Models;

namespace Services.AppUsingLogs {
    public interface IAddEntityChangeService : IScopedDependency {
        Task Exe<T>(AddEntityChangeInputs<T> inputs);
    }

    public class AddEntityChangeService : IAddEntityChangeService {
        private readonly IRepository<EntityChanges> entityChangesRepo;

        public AddEntityChangeService(
            IRepository<EntityChanges> entityChangesRepo
            ) {
            this.entityChangesRepo = entityChangesRepo;
        }

        public async Task Exe<T>(AddEntityChangeInputs<T> inputs) {
            var now = DateTime.Now;
            var nowFa = now.ToPersianDateTime();
            var diff = inputs.ObjA.Compare(inputs.ObjB, typeof(IEntity));
            var changes = inputs.ChangeType == ChangeType.Edit ? diff.Print() : diff.PrintA();

            if (diff.Count > 0) {
                var item = new EntityChanges {
                    Date = now,
                    DateY = nowFa.Year,
                    DateM = nowFa.Month,
                    DateD = nowFa.Day,
                    EnitityType = inputs.EnitityType,
                    ChangeType = inputs.ChangeType,
                    EntityId = inputs.EntityId,
                    Root1Id = inputs.Root1Id,
                    Root2Id = inputs.Root2Id,
                    Root3Id = inputs.Root3Id,
                    Changes = changes
                };
                await entityChangesRepo.AddAsync(item);
            }
        }
    }
}
