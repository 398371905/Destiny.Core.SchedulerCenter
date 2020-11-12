using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.SchedulerCenter.Domain.Models.IdentityServerFour;
using Destiny.Core.SchedulerCenter.Shared;
using System;

namespace Destiny.Core.SchedulerCenter.Domain.Models.SuktIdentityServerFour
{
    public class ClientPostLogoutRedirectUriConfiguration : EntityMappingConfiguration<ClientPostLogoutRedirectUri, Guid>
    {
        public override void Map(EntityTypeBuilder<ClientPostLogoutRedirectUri> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ClientPostLogoutRedirectUri");
        }
    }
}