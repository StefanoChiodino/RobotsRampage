namespace SpaceRampage.Game.Utility
{
    public class Vector2
    {
        #region Constructors and Destructors

        public Vector2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region Public Properties

        public double X { get; set; }

        public double Y { get; set; }

        #endregion
    }
}