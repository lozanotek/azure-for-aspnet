using System;
using System.Configuration;
using Microsoft.AspNet.SignalR;

namespace Orwell.Hub
{
    class SignalRServiceBus
    {
        public static void Bootstrap()
        {
            var serviceBus = GetServiceBusConnection();
            if (!string.IsNullOrWhiteSpace(serviceBus))
            {
                GlobalHost.DependencyResolver.UseServiceBus(serviceBus, "orwell");
            }
        }

        private static string GetServiceBusConnection()
        {
            var serviceBus = ConfigurationManager.AppSettings["orwell.ServiceBus"];
            if (string.IsNullOrWhiteSpace(serviceBus))
            {
                serviceBus = Environment.GetEnvironmentVariable("orwell.ServiceBus", EnvironmentVariableTarget.User);
            }

            return serviceBus;
        }
    }
}
