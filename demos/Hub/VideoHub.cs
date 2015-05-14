namespace Orwell.Hub
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;
    using API.Client;

    public class VideoHub : Hub
    {
        public Task Play(int index)
        {
            var connectionId = Context.ConnectionId;

            var task = Task.Factory.StartNew(() =>
            {
                var logClient = new LogClient();
                var message = string.Format("Playing Video: {0}", index);
                logClient.LogEvent(message, connectionId, DateTime.UtcNow);
            });

            task.ContinueWith(t => Clients.All.PlayVideo(index));
            return task;
        }

        public override Task OnConnected()
        {
            Task.Factory.StartNew(() =>
            {
                var connectionId = Context.ConnectionId;
                var headers = Context.Request.Headers;

                var buffer = new StringBuilder();
                buffer.AppendLine(string.Format("Connection ID: {0}", connectionId));


                foreach (var header in headers)
                {
                    buffer.AppendLine(string.Format("{0}={1}", header.Key, header.Value));
                }

                var logClient = new LogClient();
                logClient.LogEvent(buffer.ToString(), connectionId, DateTime.UtcNow);
            });

            return base.OnConnected();
        }
    }
}
