namespace RobotsRampage.Models
{
    using System.Runtime.Serialization;
    using RobotsRampage.Game.Controllers;
    using RobotsRampage.Game.Utility;

    [DataContract]
    public class Robot
    {
        public RobotMovementController RobotMovementController = new RobotMovementController(new Vector2());
        [DataMember]
        public double X
        {
            get
            {
                return this.RobotMovementController.Position.X;
            }
        }
        [DataMember]
        public double Y
        {
            get
            {
                return this.RobotMovementController.Position.Y;
            }
        }
    }
}