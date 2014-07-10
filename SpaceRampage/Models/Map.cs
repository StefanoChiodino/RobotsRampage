using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace RobotsRampage.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Map
    {
        public Map(double width, double heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public double Width { get; private set; }
        public double Heigth { get; private set; }
    }
}