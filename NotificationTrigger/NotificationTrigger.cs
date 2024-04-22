using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs
using Microsoft.Extensions.Logging;

namespace Nimbus.Notifications
{
    public class NotificationTrigger
    {
        private readonly ILogger _logger;

        public NotificationTrigger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<NotificationTrigger>();
        }

        [Function("NotificationTrigger")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
