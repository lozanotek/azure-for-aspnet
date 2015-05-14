using System;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Orwell.API
{
    public static class TableStorage
    {
        public static void InitializeTables()
        {
            // Create the table if it doesn't exist.
            var table = CreateCloudTable();
            table.CreateIfNotExists();
        }

        public static CloudTable CreateCloudTable()
        {
            var orwellStorage = ConfigurationManager.AppSettings["orwell.Storage"];

            if (string.IsNullOrWhiteSpace(orwellStorage))
            {
                orwellStorage = Environment.GetEnvironmentVariable("orwell.Storage", EnvironmentVariableTarget.User);
            }

            var storageAccount = CloudStorageAccount.Parse(orwellStorage);

            // Create the table client.
            var tableClient = storageAccount.CreateCloudTableClient();

            // Create the table if it doesn't exist.
            return tableClient.GetTableReference("SystemEvents");
        }
    }
}
