using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceRampage.Controllers
{
    using System.ComponentModel;
    using System.Data.Entity.Migrations.Model;
    using System.Runtime.Remoting.Contexts;
    using System.Timers;

    using RobotsRampage.Models;

    using SpaceRampage.Models;

    public class RobotsRampageController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }

        public static Map Map = new Map(100,100);

        public static List<Client> Clients = new List<Client>();

        public static List<Robot> Robots = new List<Robot>();

        private static Game Game = new Game();
    }
}