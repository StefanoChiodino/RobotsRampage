namespace RobotsRampage.Models
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.Serialization;
    using RobotsRampage.Game;

    [DataContract]
    public class Client
    {
        public List<GameAction> GameActions = new List<GameAction>();
        [DataMember]
        public List<Robot> Robots = new List<Robot>();
        [DataMember]
        public string ConnectionId { get; private set; }
        public Color Color { get; private set; }
        [DataMember]
        public string WebColor
        {
            get
            {
                return "#" + this.Color.R.ToString("X2") + this.Color.G.ToString("X2") + this.Color.B.ToString("X2");
            }
        }

        public Client(string connectionId)
        {
            this.ConnectionId = connectionId;
            this.Color = this.GetRandomColor();
        }

        private Color GetRandomColor()
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            return Color.FromKnownColor(randomColorName);
        }
    }
}