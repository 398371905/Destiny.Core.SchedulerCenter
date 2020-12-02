using Destiny.Core.SchedulerCenter.Application;
using Destiny.Core.SchedulerCenter.AspNetCore.ApiBase;
using Destiny.Core.SchedulerCenter.Dtos.DataDictionaryDto;
using Destiny.Core.SchedulerCenter.NodeApplication.MessageDto;
using Destiny.Core.SchedulerCenter.Shared.AjaxResult;
using Destiny.Core.SchedulerCenter.Shared.Audit;
using Destiny.Core.SchedulerCenter.Shared.Entity;
using Destiny.Core.SchedulerCenter.Shared.Extensions;
using Destiny.Core.SchedulerCenter.Shared.OperationResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SuperSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.API.Controllers.DataDictionary
{
    [Description("数据字典管理")]
    public class DataDictionaryController : ApiControllerBase
    {
        private readonly IDictionaryContract _dictionary = null;
        private readonly ILogger<DataDictionaryController> _logger = null;
        private readonly IServerInfo _serverInfo;
        public DataDictionaryController(/*IDictionaryContract dictionary,*/ ILogger<DataDictionaryController> logger, IServerInfo serverInfo)
        {
            //_dictionary = dictionary;
            _logger = logger;
            _serverInfo = serverInfo;
        }

        /// <summary>
        /// 添加一个数据字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("创建一个数据字典")]
        [AuditLog]
        public async Task<AjaxResult> CreateAsync(DataDictionaryInputDto input)
        {
            return (await _dictionary.InsertAsync(input)).ToAjaxResult();
        }

        /// <summary>
        /// 修改一个数据字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("修改一个数据字典")]
        [AuditLog]
        public async Task<AjaxResult> UpdateAsync(DataDictionaryInputDto input)
        {
            return (await _dictionary.UpdateAsync(input)).ToAjaxResult();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("分页获取数据字典")]
        public async Task<PageList<DataDictionaryOutDto>> GetPageAsync([FromBody] PageRequest query)
        {
            return (await _dictionary.GetResultAsync(query)).PageList();
        }

        /// <summary>
        /// 删除一个数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("异步删除数据字典")]
        [HttpDelete]
        [AuditLog]
        public async Task<AjaxResult> DeleteAsyc(Guid? id)
        {
            return (await _dictionary.DeleteAsync(id.Value)).ToAjaxResult();
        }
        /// <summary>
        /// Socket服务器发送消息测试
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("Socket服务器发送消息测试")]
        public async Task<string> Socket([FromBody] SocketMsgDto input)
        {
            await Task.CompletedTask;
            //var sessionContainer = _serviceProvider.GetServices<IMiddleware>()
            //    .OfType<ISessionContainer>()
            //    .FirstOrDefault();
            var parmeters = new List<PerformParameter>();
            //根据Id获取客户端主机
            var sessionContainer = _serverInfo.GetSessionContainer()?.GetSessionByID(input.SessionId);
            if (sessionContainer != null)
            {
                var parmeter1 = new PerformParameter
                {
                    FileName = "dotnet",
                    Arguments = "shell\\Test\\ConsoleApp1.dll",

                    TaskInstanceId = Guid.NewGuid()
                };
                parmeters.Add(parmeter1);
                //var parmeter2 = new PerformParameter
                //{
                //    FileName = "dotnet",
                //    Arguments = "shell\\Test\\ConsoleApp1.dll",
                //    TaskType = TaskType.DOTNET,
                //    TaskInstanceId = Guid.NewGuid()
                //};
                //parmeters.Add(parmeter2);
                var msg = JsonConvert.SerializeObject(parmeters);
                //像客户端发送消息
                await sessionContainer.SendAsync(Encoding.UTF8.GetBytes($"ReceiveMsg {msg}\r\n"));

                Console.WriteLine($"像客户端发送消息{input.Msg}成功");
            }
            else
            {
                return "消息发送失败";
            }
            return "消息发送成功";
        }
    }
}
