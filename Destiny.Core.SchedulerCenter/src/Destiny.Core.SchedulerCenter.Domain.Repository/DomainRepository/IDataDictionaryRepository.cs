using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.SchedulerCenter.Domain.Models.SystemFoundation.DataDictionary;
using Destiny.Core.SchedulerCenter.Shared;
using Destiny.Core.SchedulerCenter.Shared.Attributes.Dependency;
using Destiny.Core.SchedulerCenter.Shared.Entity;
using System;

namespace Destiny.Core.SchedulerCenter.Domain.Repository.DomainRepository
{
    public interface IDataDictionaryRepository : IEFCoreRepository<DataDictionaryEntity, Guid>
    {
    }

    [Dependency(ServiceLifetime.Scoped)]
    public class DataDictionaryRepository : BaseRepository<DataDictionaryEntity, Guid>, IDataDictionaryRepository
    {
        public DataDictionaryRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}