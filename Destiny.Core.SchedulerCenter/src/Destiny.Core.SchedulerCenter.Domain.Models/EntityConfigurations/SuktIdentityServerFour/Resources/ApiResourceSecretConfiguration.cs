using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.SchedulerCenter.Domain.Models.IdentityServerFour;
using Destiny.Core.SchedulerCenter.Shared;
using System;

namespace Destiny.Core.SchedulerCenter.Domain.Models.SuktIdentityServerFour
{
    public class ApiResourceSecretConfiguration : EntityMappingConfiguration<ApiResourceSecret, Guid>
    {
        public override void Map(EntityTypeBuilder<ApiResourceSecret> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ApiResourceSecret");
        }
    }
}