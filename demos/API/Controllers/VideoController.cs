namespace Orwell.API.Controllers
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.Http;
    using Models;

    public class VideoController : ApiController
    {
        public VideoList Get()
        {
            var videoList = new VideoList();
            var connString = SqlDatabase.GetConnectionString();
            var conn = new SqlConnection(connString);

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT [Id], [Title], [Key] FROM Videos";
                conn.Open();

                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        var temp = new Video
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Key = reader.GetString(2)
                        };

                        videoList.Add(temp);
                    }
                }
            }

            return videoList;
        }
    }
}
