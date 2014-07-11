using System.Drawing;

namespace RobotsRampage.Models
{
    using System;
    using System.Runtime.Serialization;

    using SpaceRampage.Models;

    [DataContract]
    public class Robot
    {
        [DataMember]
        public Client Client { get; private set; }
        [DataMember]
        public double X { get; set; }
        [DataMember]
        public double Y { get; set; }
        public Robot(Client client)
        {
            this.Client = client;
            this.X = 1;
            this.Y = 1;
        }
    }
}