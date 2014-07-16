namespace RobotsRampage.Controllers
{
    using System.Web.Mvc;

    public class RobotsRampageController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            return this.View();
        }
    }
}