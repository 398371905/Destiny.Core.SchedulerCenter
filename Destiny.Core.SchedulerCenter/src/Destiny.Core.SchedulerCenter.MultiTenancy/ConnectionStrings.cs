﻿using AutoMapper.Internal;
using System;
using System.Collections.Generic;

namespace Destiny.Core.SchedulerCenter.MultiTenancy
{
    [Serializable]
    public class ConnectionStrings : Dictionary<string, string>
    {
        public const string DefaultConnectionStringName = "Default";

        public string Default
        {
            get => this.GetOrDefault(DefaultConnectionStringName);
            set => this[DefaultConnectionStringName] = value;
        }
    }
}