namespace RobotsRampage.Hubs
{
    using System.Linq;
    using Microsoft.AspNet.SignalR;
    using RobotsRampage.Controllers;
    using RobotsRampage.Game;
    using RobotsRampage.Game.GameActions;
    using RobotsRampage.Game.Utility;
    using RobotsRampage.Models;

    public class RobotsRampageHub : Hub
    {
        public void AddClient()
        {
            var client = new Client(this.Context.ConnectionId);
            Game.Clients.Add(client);

            var robot = new Robot();
            client.Robots.Add(robot);
        }

        private void SendRobots()
        {
            this.Clients.All.setRobots(Game.Clients);
        }

        public void GetMap()
        {
            this.Clients.Caller.setWorld(Game.Map);
        }

        public void Rampage(int x, int y)
        {
            Client client = Game.Clients.First(c => c.ConnectionId == this.Context.ConnectionId);
            client.GameActions.Add(new MoveAction(0, client, new Vector2(x, y), client.Robots));
        }

        public void Robot(int x, int y)
        {
            var client = Game.Clients.First(c => c.ConnectionId == this.Context.ConnectionId);
            client.Robots.Add(new Robot());
        }
    }
}