using AutoMapper;
using Destiny.Core.SchedulerCenter.Domain.Models.SystemFoundation.DataDictionary;

namespace Destiny.Core.SchedulerCenter.Dtos.DataDictionaryDto
{
    public class DictionaryProfile : Profile
    {
        public DictionaryProfile()
        {
            CreateMap<DataDictionaryEntity, TreeDictionaryOutDto>().ForMember(x => x.title, opt => opt.MapFrom(x => x.Title));
        }
    }
}