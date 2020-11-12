using System;

namespace Destiny.Core.SchedulerCenter.Shared.Helpers
{
    public static class ArrayHelper
    {
        public static T[] Empty<T>() =>
            Array.Empty<T>()
        ;

    }
}