namespace Orwell.Hub
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;
    using Orwell.API.Client;

    public class DataHub : Hub
    {
        public void SignalUpdate(string title)
        {
            var connectionId = Context.ConnectionId;

            var task = Task.Factory.StartNew(() =>
            {
                var logClient = new LogClient();
                var message = string.Format("New Video: {0}", title);
                logClient.LogEvent(message, connectionId, DateTime.UtcNow);
            });

            task.ContinueWith((Action<Task>)Clients.All.VideoAdded(title));
        }

        public override Task OnConnected()
        {
            Task.Factory.StartNew(() =>
            {
                var connectionId = Context.ConnectionId;

                var buffer = new StringBuilder();
                buffer.AppendLine("Connected to the Data Sync Service");
                buffer.AppendLine(string.Format("Connection ID: {0}", connectionId));

                var logClient = new LogClient();
                logClient.LogEvent(buffer.ToString(), connectionId, DateTime.UtcNow);
            });

            return base.OnConnected();
        }
    }
}