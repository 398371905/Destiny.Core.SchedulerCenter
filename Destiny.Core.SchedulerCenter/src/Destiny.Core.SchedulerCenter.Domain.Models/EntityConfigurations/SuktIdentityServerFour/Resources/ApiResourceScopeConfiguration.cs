using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.SchedulerCenter.Domain.Models.IdentityServerFour;
using Destiny.Core.SchedulerCenter.Shared;
using System;

namespace Destiny.Core.SchedulerCenter.Domain.Models.SuktIdentityServerFour
{
    internal class ApiResourceScopeConfiguration : EntityMappingConfiguration<ApiResourceScope, Guid>
    {
        public override void Map(EntityTypeBuilder<ApiResourceScope> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ApiResourceScope");
        }
    }
}