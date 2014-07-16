namespace RobotsRampage.Game
{
    using RobotsRampage.Game.Utility;

    public class MovementController
    {
        private double MaxSpeed { get; set; }
        public Vector2 Position { get; set; }

        public MovementController(double maxSpeed, Vector2 position)
        {
            this.MaxSpeed = maxSpeed;
            this.Position = position;
        }

        public void Move(Vector2 targetPosition)
        {
            var vectorToTarget = Position - targetPosition;
            vectorToTarget.Max(MaxSpeed);
            Position.Add(vectorToTarget);
        }
    }
}