using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.SchedulerCenter.Domain.Models.IdentityServerFour;
using Destiny.Core.SchedulerCenter.Shared;
using System;

namespace Destiny.Core.SchedulerCenter.Domain.Models.SuktIdentityServerFour
{
    public class ClientPropertyConfiguration : EntityMappingConfiguration<ClientProperty, Guid>
    {
        public override void Map(EntityTypeBuilder<ClientProperty> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ClientProperty");
        }
    }
}