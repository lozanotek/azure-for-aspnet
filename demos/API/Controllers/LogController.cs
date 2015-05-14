namespace Orwell.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.WindowsAzure.Storage.Table;
    using Models;

    public class LogController : ApiController
    {
        public IEnumerable<SystemEvent> Get()
        {
            var currentDate = DateTime.UtcNow;
            var key = currentDate.ToString("yyyy-MM-dd");
            var query = new TableQuery<EventEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, key));

            var table = TableStorage.CreateCloudTable();
            var results = table.ExecuteQuery(query);

            var list = results.Select(result =>
                new SystemEvent
                {
                    Date = result.Date,
                    Message = result.Message,
                    User = result.User
                })
                .OrderByDescending(e => e.Date)
                .ToList();

            return list;
        }

        public void Post(SystemEvent @event)
        {
            var table = TableStorage.CreateCloudTable();

            var entity = new EventEntity(@event.Date)
            {
                Message = @event.Message,
                User = @event.User
            };

            try
            {
                table.CreateIfNotExists();

                var insertOperation = new TableBatchOperation();
                insertOperation.Insert(entity);
                table.ExecuteBatch(insertOperation);
            }
            catch (Exception)
            {
            }
        }

        public void Delete()
        {
            var table = TableStorage.CreateCloudTable();
            table.Delete();
            table.CreateIfNotExists();
        }
    }
}
