using Destiny.Core.SchedulerCenter.Shared.Enums;
using System;

namespace Destiny.Core.SchedulerCenter.Shared.Attributes.AutoMapper
{
    public class SuktAutoMapToAttribute : SuktAutoMapperAttribute
    {
        public override SuktAutoMapDirection MapDirection
        {
            get { return SuktAutoMapDirection.From; }
        }

        public SuktAutoMapToAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {
        }
    }
}