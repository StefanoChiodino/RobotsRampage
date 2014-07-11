using System.Drawing;

namespace RobotsRampage.Models
{
    using System;
    using System.Runtime.Serialization;
    using SpaceRampage.Game;
    using SpaceRampage.Models;

    [DataContract]
    public class Robot : GameMovable
    {
        [DataMember]
        public Client Client { get; private set; }
        public Robot(Client client)
        {
            this.Client = client;
        }
    }
}