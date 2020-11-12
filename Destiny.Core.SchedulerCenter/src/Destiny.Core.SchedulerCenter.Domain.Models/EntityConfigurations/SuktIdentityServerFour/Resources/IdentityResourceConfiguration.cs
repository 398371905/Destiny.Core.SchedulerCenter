using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.SchedulerCenter.Domain.Models.IdentityServerFour;
using Destiny.Core.SchedulerCenter.Shared;
using System;

namespace Destiny.Core.SchedulerCenter.Domain.Models.SuktIdentityServerFour
{
    public class IdentityResourceConfiguration : EntityMappingConfiguration<IdentityResource, Guid>
    {
        public override void Map(EntityTypeBuilder<IdentityResource> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("IdentityResource");
        }
    }
}