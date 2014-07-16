namespace RobotsRampage.Game
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.SignalR;
    using RobotsRampage.Controllers;
    using RobotsRampage.Hubs;
    using RobotsRampage.Models;
    using WebGrease.Css.Extensions;

    public static class Game
    {
        private static readonly IHubContext RobotsRampageHub = GlobalHost.ConnectionManager.GetHubContext<RobotsRampageHub>();

        private static GameTimer GameTimer;

        public static Map Map = new Map(100, 100);

        public static List<Client> Clients = new List<Client>();

        static Game()
        {
            GameTimer = new GameTimer(Update,
                10);
            GameTimer.Start();
        }

        private static void Update(long elapsed)
        {
            RobotsRampageHub.Clients.All.setRobots(Clients);
            foreach (var client in Clients)
            {
                foreach (var gameAction in client.GameActions)
                {
                    gameAction.Execute(elapsed);
                }
                client.GameActions.RemoveAll(a => a.IsCompleted());
            }
        }
    }
}