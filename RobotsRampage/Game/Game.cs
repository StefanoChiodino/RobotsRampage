namespace RobotsRampage.Game
{
    using Microsoft.AspNet.SignalR;
    using RobotsRampage.Controllers;
    using RobotsRampage.Hubs;

    internal class Game
    {
        private IHubContext RobotsRampageHub = GlobalHost.ConnectionManager.GetHubContext<RobotsRampageHub>();

        private GameTimer GameTimer;

        public Game()
        {
            this.GameTimer = new GameTimer(() => this.RobotsRampageHub.Clients.All.setRobots(RobotsRampageController.Robots),
                10);
            this.GameTimer.Start();
        }
    }
}