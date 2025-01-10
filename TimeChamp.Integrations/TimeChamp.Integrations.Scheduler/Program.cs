using TimeChamp.Integrations.Scheduler;
using TimeChamp.Integrations.Scheduler.DatabaseCommunicator;
using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using TimeChamp.Integrations.SchedulerManager.Scheduler;
using TimeChamp.Integrations.Scheduler.RabbitMQHouse.RabbitMQProducers;

var builder = Host.CreateApplicationBuilder(args);

// Hosted Service (Scheduler)
builder.Services.AddHostedService<Scheduler>();

#region Dependency Injection
builder.Services.AddSingleton<MongoDBConnector>();
builder.Services.AddSingleton<MongoDbQuerryEngine>();
builder.Services.AddSingleton<FeatureScheduleManager>();
builder.Services.AddSingleton<UpsertUsersI2TProducer>();

// MongoDB Options for Hangfire
var options = new MongoStorageOptions
{
    MigrationOptions = new MongoMigrationOptions
    {
        MigrationStrategy = new DropMongoMigrationStrategy(),
        BackupStrategy = new NoneMongoBackupStrategy()
    },
    CheckQueuedJobsStrategy = CheckQueuedJobsStrategy.TailNotificationsCollection
};

// Configure Hangfire with MongoDB Storage
builder.Services.AddHangfire(x => x.UseMongoStorage(connectionString: @"mongodb://localhost:27017/HF", options));
builder.Services.AddHangfireServer(serverOptions =>
{
    serverOptions.ServerName = "Inetgration";
});
#endregion

// Build the host
var host = builder.Build();

// Retrieve the MongoDB Query Engine and check if the scheduler can run
MongoDbQuerryEngine querryEngine = host.Services.GetRequiredService<MongoDbQuerryEngine>();
bool canRunScheduler = querryEngine.ConnectToDataBase();

if (canRunScheduler)
{
    host.Run();
}