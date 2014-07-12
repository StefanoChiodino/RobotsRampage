namespace RobotsRampage.Hubs
{
    using System.Linq;
    using Microsoft.AspNet.SignalR;
    using RobotsRampage.Controllers;
    using RobotsRampage.Models;

    public class RobotsRampageHub : Hub
    {
        public void AddClient()
        {
            var client = new Client(this.Context.ConnectionId);
            RobotsRampageController.Clients.Add(client);

            var robot = new Robot(client);
            RobotsRampageController.Robots.Add(robot);
        }

        private void SendRobots()
        {
            this.Clients.All.setRobots(RobotsRampageController.Robots);
        }

        public void GetMap()
        {
            this.Clients.Caller.setWorld(RobotsRampageController.Map);
        }

        public void Rampage(int x, int y)
        {
            Robot robot = RobotsRampageController.Robots.First(r => r.Client.ConnectionId == this.Context.ConnectionId);
            robot.Position.X = x;
            robot.Position.Y = y;
        }

        public void Robot(int x, int y)
        {
            var client = RobotsRampageController.Clients.First(c => c.ConnectionId == this.Context.ConnectionId);
            RobotsRampageController.Robots.Add(new Robot(client));
        }
    }
}