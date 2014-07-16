namespace RobotsRampage.Game.GameActions
{
    using System.Collections.Generic;
    using System.Linq;
    using RobotsRampage.Game.Utility;
    using RobotsRampage.Models;

    public class MoveAction : GameAction
    {
        public List<Robot> Robots { get; set; }
        public Vector2 TargetPosition { get; set; }

        public MoveAction(int priority, Client client, Vector2 targetPosition, List<Robot> robots)
            : base(priority, client)
        {
            this.TargetPosition = targetPosition;
            this.Robots = robots;
        }

        /// <summary>
        ///     Execute the action
        /// </summary>
        /// <param name="elapsed">The ms elapsed</param>
        public override void Execute(long elapsed)
        {
            foreach (var robot in Robots)
            {
                robot.RobotMovementController.Move(this.TargetPosition);
            }
        }

        public override bool IsCompleted()
        {
            return this.Robots.All(r=> this.TargetPosition == r.RobotMovementController.Position);
        }
    }
}