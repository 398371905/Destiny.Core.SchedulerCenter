using AutoMapper;
using Destiny.Core.SchedulerCenter.Domain.Models.IdentityServerFour;

namespace Destiny.Core.SchedulerCenter.IdentityServerFourStore.IdentityServerProfile
{
    public class PersistedGrantMapperProfile : Profile
    {
        public PersistedGrantMapperProfile()
        {
            CreateMap<PersistedGrant, IdentityServer4.Models.PersistedGrant>(MemberList.Destination)
                            .ReverseMap();
        }
    }
}
