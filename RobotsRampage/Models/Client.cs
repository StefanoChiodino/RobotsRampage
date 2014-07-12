namespace RobotsRampage.Models
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;

    public class Client
    {
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