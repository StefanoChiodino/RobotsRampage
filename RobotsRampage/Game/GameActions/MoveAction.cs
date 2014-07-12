namespace RobotsRampage.Game.GameActions
{
    using System;
    using RobotsRampage.Game.Utility;
    using RobotsRampage.Models;

    public class MoveAction : GameAction
    {
        public MovementController MovementController { get; set; }
        public Vector2 TargetPosition { get; set; }

        public MoveAction(int priority, Client client, MovementController movementController, Vector2 targetPosition)
            : base(priority, client)
        {
            this.MovementController = movementController;
            this.TargetPosition = targetPosition;
        }

        /// <summary>
        /// Execute the action
        /// </summary>
        /// <param name="elapsed">The ms elapsed</param>
        public override void Execute(int elapsed)
        {
            MovementController.Move(TargetPosition);
        }

        public override bool IsCompleted()
        {
            return TargetPosition == MovementController.Position;
        }
    }
}