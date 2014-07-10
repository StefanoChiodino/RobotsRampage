using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceRampage.Models
{
    using System.Drawing;
    using System.Runtime.Serialization;

    public class Client
    {
        [DataMember]
        public string ClientID { get; private set; }
        public Color Color { get; private set; }
        [DataMember]
        public string WebColor
        {
            get
            {
                return "#" + Color.R.ToString("X2") + Color.G.ToString("X2") + Color.B.ToString("X2");
            }
        }

        public Client(string clientID)
        {
            this.ClientID = clientID;
            this.Color = GetRandomColor();
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