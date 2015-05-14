using System;
using System.Configuration;

namespace Orwell.Manager
{
    public static class SqlDatabase 
    {
        public static string GetConnectionString()
        {
            var connString = ConfigurationManager.ConnectionStrings["orwell.Database"];

            return connString == null ? 
                Environment.GetEnvironmentVariable("orwell.Database", EnvironmentVariableTarget.User) : 
                connString.ConnectionString;
        }
    }
}
