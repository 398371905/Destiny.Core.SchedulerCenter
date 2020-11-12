using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.SchedulerCenter.Domain.Models.IdentityServerFour;
using Destiny.Core.SchedulerCenter.Shared;
using System;

namespace Destiny.Core.SchedulerCenter.Domain.Models.SuktIdentityServerFour
{
    public class ApiResourceClaimConfiguration : EntityMappingConfiguration<ApiResourceClaim, Guid>
    {
        public override void Map(EntityTypeBuilder<ApiResourceClaim> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ApiResourceClaim");
        }
    }
}