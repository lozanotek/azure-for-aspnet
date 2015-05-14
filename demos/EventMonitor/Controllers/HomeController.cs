namespace Orwell.Monitor.Controllers
{
    using System.Web.Mvc;
    using API.Client;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var logClient = new LogClient();
            var model = logClient.GetEvents();
            return View(model);
        }

    }
}
