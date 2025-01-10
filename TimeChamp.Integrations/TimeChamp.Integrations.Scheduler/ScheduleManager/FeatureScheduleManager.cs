using Hangfire;
using TimeChamp.Integrations.Scheduler.DatabaseCommunicator;
using TimeChamp.Integrations.Scheduler.DatabaseCommunicator.POCO;
using TimeChamp.Integrations.Scheduler.RabbitMQHouse.RabbitMQProducers;

namespace TimeChamp.Integrations.SchedulerManager.Scheduler
{
    public class FeatureScheduleManager
    {
        private MongoDbQuerryEngine _mongoDbQuerryEngine;
        public UpsertUsersI2TProducer _upsertUsersI2TProducer;
        public FeatureScheduleManager(MongoDbQuerryEngine mongoDbQuerryEngine, UpsertUsersI2TProducer upsertUsersI2TProducer)
        {
            _mongoDbQuerryEngine = mongoDbQuerryEngine;
            _upsertUsersI2TProducer = upsertUsersI2TProducer;
        }

        public async void HandleFeatureScheduling()
        {

            List<ScheduledFeatures> scheduledFeatures = new List<ScheduledFeatures>();
            #region comment
            //List<RecurringJobDto> recurringJobs = new List<RecurringJobDto>();
            //JobList<ScheduledJobDto>? scheduledJobs = null;

            //var xnn = await _mongoDbQuerryEngine.GetAllScheduledFeatures();

            // get all jobs when the feature is null(application start time) or when config is changed and it is not beign deleted
            //if (changedFeature == null ||  !changedFeature.IsArchived)
            //{
            //    using(IStorageConnection connection = JobStorage.Current.GetConnection())
            //    {
            //        recurringJobs = connection.GetRecurringJobs();
            //        scheduledJobs = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue);
            //    }
            //}

            // if there is any input for this process it like check for removal
            #endregion

            //RecurringJob.AddOrUpdate("Hello world", () => Console.WriteLine("Hello World"), Cron.Weekly((DayOfWeek)1, 19, 19));
            //await Task.Delay(9000);
            RecurringJob.AddOrUpdate("Hello world",() => Console.WriteLine("Hello World"), Cron.Weekly((DayOfWeek)1, 9, 9));
            //changedFeature = CustomHangFire();

            //if (changedFeature != null)
            //{
            //    if (changedFeature.IsArchived)
            //    {
            //        if (changedFeature.ScheduleDetails.IsRecurring)
            //        {
            //            foreach (string jobId in changedFeature.ScheduledJobIds)
            //                RecurringJob.RemoveIfExists(jobId);
            //        }
            //        else
            //        {
            //            BackgroundJob.Delete(changedFeature.SubscribedIntegrationFeatureId);
            //        }
            //        _mongoDbQuerryEngine.UpdateScheduleTimeForADocument(changedFeature.SubscribedIntegrationFeatureId, null, true);
            //        _mongoDbQuerryEngine.UpdateJobIdsForADocument(new ObjectId(changedFeature.SubscribedIntegrationFeatureId), null);
            //        return;
            //    }
            //    else if (changedFeature.SubscribedIntegrationFeatureId != null)
            //    {
            //        ScheduledFeatures enrichedChangedFeature = await _mongoDbQuerryEngine.GetAScheduledFeature(changedFeature.SubscribedIntegrationFeatureId);

            //        ScheduleDetails existingSchedules = BsonSerializer.Deserialize<ScheduleDetails>(enrichedChangedFeature.ScheduledTime);

            //        List<string> changedFeatureJobIds;

            //        changedFeatureJobIds = GenerateJobIds(changedFeature.ScheduleDetails, enrichedChangedFeature.Id.ToString());

            //        List<string> canDeleteJobIds = CompareAndReturnDeleteJobs(changedFeatureJobIds, enrichedChangedFeature);
            //        if (canDeleteJobIds.Any())
            //        {
            //            foreach (string jobId in canDeleteJobIds)
            //            {
            //                if (existingSchedules.IsRecurring)
            //                {
            //                    RecurringJob.RemoveIfExists(jobId);
            //                }
            //                else
            //                {
            //                    BackgroundJob.Delete(jobId);
            //                }
            //            }
            //            List<string> finalJobIds = RemoveDeletableJobs(canDeleteJobIds, enrichedChangedFeature);
            //            _mongoDbQuerryEngine.UpdateJobIdsForADocument(enrichedChangedFeature.Id, finalJobIds);
            //        }

            //        scheduledFeatures.Add(enrichedChangedFeature);
            //    }


            //}
            //else
            //{
            //    scheduledFeatures = await _mongoDbQuerryEngine.GetAllScheduledFeatures();
            //}



            //foreach (ScheduledFeatures feature in scheduledFeatures)
            //{
            //    string x = JsonConvert.SerializeObject(feature);
            //    SchedulesFeatuersSerializer schedulesFeatuersSerializer = new SchedulesFeatuersSerializer
            //    {
            //        Id = feature.Id,
            //        IntegrationName = feature.IntegrationName,
            //        CompanyId = feature.CompanyId,
            //        IntegrationId = feature.IntegrationId,
            //        BaseUrl = feature.BaseUrl,
            //        AuthKeys = feature.AuthKeys?.ToJson(), // Convert BsonDocument to string
            //        ScheduledTime = feature.ScheduledTime?.ToJson(), // Convert BsonDocument to string
            //        FeatureName = feature.FeatureName,
            //        EndPoint = feature.EndPoint,
            //        HttpMethod = feature.HttpMethod,
            //        TimeChampEndPoint = feature.TimeChampEndPoint,
            //        TimeChampHttpMethod = feature.TimeChampHttpMethod,
            //        DataToTimeChamp = feature.DataToTimeChamp
            //    };
            //    if (feature.EndPoint.ToLower() == "GetTime")
            //    {
            //        //if(true)
            //        //{
            //        //   if( feature.NewJobIds != null)
            //        //    {
            //        //        foreach (jobid in feature.NewJobIds)
            //        //        {
            //        //            if (feature.isrecurring)
            //        //            {

            //        //            }
            //        //        }
            //        //    }

            //        //}
            //        //else
            //        //{
            //        //   // frame a name using the feature and scheduel below  
            //        //    RecurringJob.AddOrUpdate(feature.NewJobIds)
            //        //}

            //        _upsertUsersI2TProducer.UpsertUsersI2T(JsonConvert.SerializeObject(schedulesFeatuersSerializer), feature.IntegrationId + feature.FeatureName);
            //    }

            //}
        }

        //public ScheduleModel CustomHangFire()
        //{
        //    ScheduleModel scheduleModel = new ScheduleModel()
        //    {
        //        SubscribedIntegrationFeatureId = "677cc5d167ec8bcd9b5b1979",
        //        ScheduledJobIds = null,
        //        ScheduleDetails = new ScheduleDetails()
        //        {
        //            IsRecurring = true,
        //            TimeFrequency = 0,
        //            SelectedDays = [0, 1, 2],
        //            DelivaryTime = DateTime.Now
        //        }

        //    };
        //    return scheduleModel;
        //}

        //    public List<string> GenerateJobIds(ScheduleDetails scheduleTime, string featureId)
        //    {
        //        List<string> schedulejobIds = new List<string>();
        //        string hours = scheduleTime.DelivaryTime.TimeOfDay.Hours.ToString("D2");
        //        string minutes = scheduleTime.DelivaryTime.TimeOfDay.Minutes.ToString("D2");
        //        if (scheduleTime.TimeFrequency == 0)// daily
        //        {

        //            foreach (var deliveryDay in scheduleTime.SelectedDays)
        //            {
        //                string Jobid = featureId + scheduleTime.TimeFrequency.ToString() + hours + minutes + (scheduleTime.IsRecurring ? "1" : "0");

        //                schedulejobIds.Add(Jobid);
        //            }

        //        }

        //        else
        //        {
        //            string Jobid = featureId + scheduleTime.TimeFrequency.ToString() + hours + minutes + (scheduleTime.IsRecurring ? "1" : "0");
        //            schedulejobIds.Add(Jobid);
        //        }
        //        return schedulejobIds;
        //    }

        //    public List<string> CompareAndReturnDeleteJobs(List<string> newJobs, ScheduledFeatures enrichedScheduledFeature)
        //    {
        //        List<string> deletableJobs = new List<string>();
        //        List<string> oldJobIds = enrichedScheduledFeature.JobIds;

        //        // Iterate through old jobs and check if they are not in the new jobs
        //        foreach (var oldJob in oldJobIds)
        //        {
        //            if (!newJobs.Contains(oldJob))
        //            {
        //                deletableJobs.Add(oldJob); // Add to deletable jobs
        //            }
        //        }

        //        // Iterate through new jobs and check if they are not in the old jobs
        //        foreach (var newJob in newJobs)
        //        {
        //            if (!oldJobIds.Contains(newJob))
        //            {
        //                enrichedScheduledFeature.NewJobIds.Add(newJob); // Add to enrichedScheduledFeature.NewJobIds
        //            }
        //        }

        //        // Return the list of deletable jobs
        //        return deletableJobs;

        //    }

        //    public List<string> RemoveDeletableJobs(List<string> canDeleteJobIds, ScheduledFeatures enrichedChangedFeature)
        //    {
        //        // Remove jobs that exist in canDeleteJobIds from JobIds
        //        enrichedChangedFeature.JobIds.RemoveAll(job => canDeleteJobIds.Contains(job));

        //        // Return the updated JobIds list
        //        return enrichedChangedFeature.JobIds;
        //    }

        //}


        //public class ScheduleModel
        //{
        //    public string SubscribedIntegrationFeatureId { get; set; }
        //    public List<string> ScheduledJobIds { get; set; }
        //    public ScheduleDetails ScheduleDetails { get; set; }
        //    public bool IsArchived { get; set; }

        //}

        //public class ScheduleDetails
        //{
        //    public bool IsRecurring { get; set; }
        //    public int TimeFrequency { get; set; }
        //    public List<int> SelectedDays { get; set; }
        //    public DateTime DelivaryTime { get; set; }
        //}
    }
}
