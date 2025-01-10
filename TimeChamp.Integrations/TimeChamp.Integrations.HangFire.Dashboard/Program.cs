using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Hangfire.Mongo.Migration.Strategies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var options = new MongoStorageOptions
{
    MigrationOptions = new MongoMigrationOptions
    {
        MigrationStrategy = new DropMongoMigrationStrategy(),
        BackupStrategy = new NoneMongoBackupStrategy()
    },
    CheckQueuedJobsStrategy = CheckQueuedJobsStrategy.TailNotificationsCollection
};
builder.Services.AddHangfire(x => x.UseMongoStorage(connectionString: @"mongodb://localhost:27017/HF", options));
var app = builder.Build();


app.UseHangfireDashboard("/hangfire");
app.UseHangfireDashboard();
app.Run();
