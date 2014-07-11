namespace SpaceRampage.Game.GameAction
{
    #region Using
    using System;
    using RobotsRampage.Models;
    using SpaceRampage.Game.Utility;
    using SpaceRampage.Models;

    #endregion

    public class MoveAction : GameAction
    {
        public GameMovable GameMovable { get; set; }
        public Vector2 Position { get; set; }

        public MoveAction(int priority, Client client)
            : base(priority, client)
        {
        }

        public override void Execute(int elapsed)
        {
            throw new NotImplementedException();
        }
    }
}