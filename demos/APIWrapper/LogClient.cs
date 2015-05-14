namespace Orwell.API.Client
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class LogClient
    {
        private static HttpClient CreateClient()
        {
            var apiUrl = ConfigurationManager.AppSettings["orwell.ApiUrl"];
            var client = new HttpClient { BaseAddress = new Uri(apiUrl) };

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public IEnumerable<SystemEvent> GetEvents()
        {
            var client = CreateClient();
            var response = client.GetAsync("api/log").Result;
            var asyncResult = response.Content.ReadAsAsync<IEnumerable<SystemEvent>>();
            return asyncResult.Result;
        }

        public void LogEvent(string message, string username, DateTime date)
        {
            var client = CreateClient();
            
            var response = client.PostAsJsonAsync("api/log",
                new
                {
                    Message = message,
                    User = username,
                    Date = date
                }).Result;
        }

        public void Clear()
        {
            var client = CreateClient();
            var response = client.DeleteAsync("api/log").Result;
        }
    }
}
