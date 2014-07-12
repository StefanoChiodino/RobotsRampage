namespace RobotsRampage.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using RobotsRampage.Game;
    using RobotsRampage.Models;

    public class RobotsRampageController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            return this.View();
        }

        public static Map Map = new Map(100,100);

        public static List<Client> Clients = new List<Client>();

        public static List<Robot> Robots = new List<Robot>();

        private static Game Game = new Game();
    }
}