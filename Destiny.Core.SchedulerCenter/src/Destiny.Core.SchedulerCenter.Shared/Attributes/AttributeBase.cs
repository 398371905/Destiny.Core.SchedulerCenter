using System;

namespace Destiny.Core.SchedulerCenter.Shared.Attributes
{
    public abstract class AttributeBase : Attribute
    {
        public abstract string Description();
    }
}