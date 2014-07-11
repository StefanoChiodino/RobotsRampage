namespace SpaceRampage.Controllers
{
    using System.Threading;

    using Microsoft.AspNet.SignalR;

    using RobotsRampage.Hubs;

    using SpaceRampage.Game;

    internal class Game
    {
        private IHubContext RobotsRampageHub = GlobalHost.ConnectionManager.GetHubContext<RobotsRampageHub>();

        private GameTimer GameTimer;

        public Game()
        {
            GameTimer = new GameTimer(() => this.RobotsRampageHub.Clients.All.setRobots(RobotsRampageController.Robots),
                1000);
            GameTimer.Start();
        }
    }
}