using System;
using Orwell.API.Client;

namespace Orwell.Manager
{
    public partial class NewVideo : System.Web.UI.Page
    {
        protected void AddButton_OnClick(object sender, EventArgs e)
        {
            var parameters = OrwellSqlDataSource.InsertParameters;

            var title = TitleTexBox.Text;
            var key = KeyTextBox.Text;

            parameters["title"].DefaultValue = title;
            parameters["key"].DefaultValue = key;

            OrwellSqlDataSource.Insert();

            var logClient = new LogClient();
            var message = string.Format("Added video {0} with Key {1}", title, key);
            logClient.LogEvent(message, "Data Manager", DateTime.UtcNow);


            Response.Redirect("~/");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            OrwellSqlDataSource.ConnectionString = SqlDatabase.GetConnectionString();
        }
    }
}
