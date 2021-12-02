using Quartz;
using System;
using System.Threading.Tasks;

namespace WebAPI.Schedule
{
    public class QuartzJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("开始任务");
        }
    }
}
