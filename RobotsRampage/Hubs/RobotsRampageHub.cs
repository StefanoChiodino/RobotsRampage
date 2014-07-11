using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using RobotsRampage.Models;

namespace RobotsRampage.Hubs
{
    using Newtonsoft.Json;

    using SpaceRampage.Controllers;
    using SpaceRampage.Models;

    public class RobotsRampageHub : Hub
    {
        public void AddClient()
        {
            var client = new Client(Context.ConnectionId);
            RobotsRampageController.Clients.Add(client);

            var robot = new Robot(client);
            RobotsRampageController.Robots.Add(robot);
        }

        private void SendRobots()
        {
            Clients.All.setRobots(RobotsRampageController.Robots);
        }
        public void GetMap()
        {
            Clients.Caller.setWorld(RobotsRampageController.Map);
        }

        public void Rampage(int x, int y)
        {
            Robot robot = RobotsRampageController.Robots.First(r => r.Client.ConnectionId == Context.ConnectionId);
            robot.X = x;
            robot.Y = y;
        }

        public void Robot(int x, int y)
        {
            var client = RobotsRampageController.Clients.First(c => c.ConnectionId == Context.ConnectionId);
            RobotsRampageController.Robots.Add(new Robot(client));
        }
    }
}