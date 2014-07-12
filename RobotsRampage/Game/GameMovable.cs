namespace RobotsRampage.Game
{
    using System.Runtime.Serialization;
    using RobotsRampage.Game.Utility;

    [DataContract]
    public abstract class GameMovable
    {
        [DataMember]
        public Vector2 Position;

        protected GameMovable(Vector2 position)
        {
            this.Position = position;
        }

        protected GameMovable()
        {
            this.Position = new Vector2(0, 0);
        }
    }
}