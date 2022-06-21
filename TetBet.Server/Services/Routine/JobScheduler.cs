using System;
using Quartz;
using Quartz.Impl;

namespace TetBet.Server.Services.Routine
{
    public class JobScheduler
    {
        public static void Start()
        {

            // IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //
            // scheduler.Start();
            //
            // IJobDetail job = JobBuilder.Create<IDGJob>().Build();
            //
            // ITrigger trigger = TriggerBuilder.Create()
            //
            //     .WithIdentity("IDGJob", "IDG")
            //
            //     .WithCronSchedule("0 0/1 * 1/1 * ? *")
            //
            //     .StartAt(DateTime.UtcNow)
            //
            //     .WithPriority(1)
            //
            //     .Build();
            //
            // scheduler.ScheduleJob(job, trigger);

        }
    }
}