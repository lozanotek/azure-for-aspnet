namespace Orwell.Manager
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            OrwellSqlDataSource.ConnectionString = SqlDatabase.GetConnectionString();
        }
    }
}