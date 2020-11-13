﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.SchedulerCenter.Shared.Attributes.AutoMapper;
using Destiny.Core.SchedulerCenter.Shared.Enums;
using Destiny.Core.SchedulerCenter.Shared.Extensions;
using Destiny.Core.SchedulerCenter.Shared.Modules;
using Destiny.Core.SchedulerCenter.Shared.SuktReflection;
using System;
using System.Linq;
using System.Reflection;

namespace Destiny.Core.SchedulerCenter.AutoMapper
{
    public class SuktAutoMapperModuleBase : SuktAppModule
    {
        /// <summary>
        /// 重写SuktAppModule
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            var assemblyFinder = service.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>();
            var assemblys = assemblyFinder.FindAll();
            var suktAutoMapTypes = assemblys.SelectMany(x => x.GetTypes()).Where(s => s.IsClass && !s.IsAbstract && s.HasAttribute<SuktAutoMapperAttribute>(true)).Distinct().ToArray();
            service.AddAutoMapper(mapper =>
            {
                this.CreateMapping<SuktAutoMapperAttribute>(suktAutoMapTypes, mapper);
            }, assemblys, ServiceLifetime.Singleton);
            var mapper = service.GetBuildService<IMapper>();//获取autoMapper实例
            AutoMapperExtension.SetMapper(mapper);
        }

        /// <summary>
        /// 创建扩展方法
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="sourceTypes"></param>
        /// <param name="mapperConfigurationExpression"></param>
        private void CreateMapping<TAttribute>(Type[] sourceTypes, IMapperConfigurationExpression mapperConfigurationExpression) where TAttribute : SuktAutoMapperAttribute
        {
            foreach (var sourceType in sourceTypes)
            {
                var attribute = sourceType.GetCustomAttribute<TAttribute>();
                if (attribute.TargetTypes?.Count() <= 0)
                {
                    return;
                }
                foreach (var tatgetType in attribute.TargetTypes)
                {
                    ///判断是To
                    if (attribute.MapDirection.HasFlag(SuktAutoMapDirection.To))
                    {
                        mapperConfigurationExpression.CreateMap(sourceType, tatgetType);
                    }
                    ///判断是false
                    if (attribute.MapDirection.HasFlag(SuktAutoMapDirection.From))
                    {
                        mapperConfigurationExpression.CreateMap(tatgetType, sourceType);
                    }
                }
            }
        }
    }
}