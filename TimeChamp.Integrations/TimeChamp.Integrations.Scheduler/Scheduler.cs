using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeChamp.Integrations.Scheduler.DatabaseCommunicator;
using TimeChamp.Integrations.Scheduler.DatabaseCommunicator.POCO;
using TimeChamp.Integrations.SchedulerManager.Scheduler;

namespace TimeChamp.Integrations.Scheduler
{
    public class Scheduler : BackgroundService
    {
        private MongoDbQuerryEngine _mongoDbQuerryEngine;
        private FeatureScheduleManager _featureScheduleManager;
        public Scheduler(FeatureScheduleManager featureScheduleManager) 
        {
           _featureScheduleManager = featureScheduleManager;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           _featureScheduleManager.HandleFeatureScheduling();
            await Task.Delay(100);
        }
    }
}